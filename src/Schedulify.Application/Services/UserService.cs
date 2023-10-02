using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using AutoMapper;
using FluentValidation;
using Schedulify.Application.Configurations;
using Schedulify.Application.Dtos.Users;
using Schedulify.Application.Dtos.Users.Enums;
using Schedulify.Application.Exceptions;
using Schedulify.Application.Interfaces;
using Schedulify.Application.Providers;
using Schedulify.Application.Services.Interfaces;
using Schedulify.Domain.Commands;
using Schedulify.Domain.Entities.Users;

namespace Schedulify.Application.Services;

internal sealed class UserService : IUserService
{
    private readonly IValidator<LoginDto> _loginValidator;
    private readonly IValidator<CreateUserDto> _createUserValidator;
    private readonly IValidator<UpdateUserDto> _updateUserValidator;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IQueueClient _queueClient;
    private readonly IMapper _mapper;
    private readonly WebFrontendConfiguration _webFrontendConfiguration;

    public UserService(
        IValidator<LoginDto> loginValidator, 
        IValidator<CreateUserDto> createUserValidator,
        IValidator<UpdateUserDto> updateUserValidator,
        IUserRepository userRepository,
        IJwtProvider jwtProvider, 
        IQueueClient queueClient,
        IMapper mapper,
        WebFrontendConfiguration webFrontendConfiguration)
    {
        _loginValidator = loginValidator;
        _createUserValidator = createUserValidator;
        _updateUserValidator = updateUserValidator;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _queueClient = queueClient;
        _webFrontendConfiguration = webFrontendConfiguration;
        _mapper = mapper;
    }

    public async Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<UserDto>(await _userRepository.GetAsync(id, cancellationToken));
    }

    public async Task<UserDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<UserDto>(await _userRepository.GetByEmailAsync(email, cancellationToken));
    }

    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<IReadOnlyCollection<UserDto>>(await _userRepository.GetAllAsync(includeDeleted, cancellationToken));
    }

    public async Task<IReadOnlyCollection<UserDto>> GetByCompanyAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<IReadOnlyCollection<UserDto>>(await _userRepository.GetByCompanyAsync(companyId, cancellationToken));
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        await _createUserValidator.ValidateAndThrowAsync(dto, cancellationToken);
        var password = GeneratePassword();
        var user = await _userRepository.CreateAsync(dto, password);

        var token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        var link = $"{_webFrontendConfiguration.BaseUrl}/confirmemail/{HttpUtility.UrlEncode(user.Email)}/{HttpUtility.UrlEncode(token)}";

        await _queueClient.SendMessage(new SendEmailCommand
        {
            To = new[] { user.Email }!,
            Subject = "Activate your account",
            Body = $"Your password is {password}" +
                   $"<br/><br/>Activate your account with the provided link. The link is active for 4 days. <br><br><strong>Link</strong>: {link}"
        });

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        await _updateUserValidator.ValidateAndThrowAsync(dto, cancellationToken);
        var user = await _userRepository.UpdateAsync(dto);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<LoginResultDto> LoginAsync(LoginDto login, CancellationToken cancellationToken = default)
    {
        await _loginValidator.ValidateAndThrowAsync(login, cancellationToken);

        var user = await _userRepository.GetByEmailAsync(login.Email, cancellationToken);
        var loginResult = await LoginAsync(user, login);
        
        if (loginResult is not LoginResult.Success)
        {
            return new()
            {
                Result = loginResult,
                Token = null
            };
        }

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Email, user!.Email!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
        
        claims.AddRange(user.UserRoles.Select(r => new Claim(ClaimTypes.Role, r.Role.Name)));

        return new()
        {
            Result = loginResult,
            Token = _jwtProvider.Generate(claims)
        };
    }

    #region Helpers

    private static string GeneratePassword()
    {
        var password = new StringBuilder("", 16);

        for (var i = 0; i < 5; i++)
        {
            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(48, 58))); // digits

            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(97, 123)));  // lowercase

            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(65, 91)));  // uppercase

            password.Append(Convert.ToChar(RandomNumberGenerator.GetInt32(33, 48)));  // symbols
        }

        return password.ToString();
    }

    private async Task<LoginResult> LoginAsync(User user, LoginDto login)
    {
        if (!user.EmailConfirmed)
        {
            return LoginResult.EmailUnconfirmed;
        }

        if (user is { LockoutEnabled: true, LockoutEnd: not null } && user.LockoutEnd.Value > DateTime.UtcNow)
        {
            throw new UserLockoutException(user.LockoutEnd.Value.DateTime);
        }

        if (user.LockoutEnd.HasValue && DateTime.UtcNow <= user.LockoutEnd.Value)
        {
            throw new UserLockoutException(user.LockoutEnd.Value.DateTime);
        }

        if (user.LastAccessFailedUtc.HasValue && DateTime.UtcNow.Subtract(user.LastAccessFailedUtc.Value).TotalHours >= 1)
        {
            user.LastAccessFailedUtc = null;
            await _userRepository.ResetAccessFailedCountAsync(user);
        }

        var isValidPassword = await _userRepository.CheckPasswordAsync(user, login.Password);

        if (isValidPassword)
        {
            if (user.LockoutEnabled || user.LockoutEnd.HasValue)
            {
                user.LockoutEnabled = false;
                user.LockoutEnd = null;
                await _userRepository.ResetAccessFailedCountAsync(user);
            }

            return LoginResult.Success;
        }

        user.LastAccessFailedUtc = DateTime.UtcNow;
        await _userRepository.AccessFailedAsync(user);

        return LoginResult.Failed;
    }

    #endregion
}