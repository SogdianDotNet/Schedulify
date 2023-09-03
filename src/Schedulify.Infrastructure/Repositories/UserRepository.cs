using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schedulify.Domain.Dtos.Users;
using Schedulify.Domain.Enums;
using Schedulify.Infrastructure.Data;
using Schedulify.Infrastructure.Data.Entities.Users;

namespace Schedulify.Infrastructure.Repositories;

internal class UserRepository
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SchedulifyDbContext _dbContext;

    public UserRepository(UserManager<User> userManager, IMapper mapper, SchedulifyDbContext dbContext)
    {
        _userManager = userManager;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .Include(x => x.UserRoles)!
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .SingleAsync(x => x.Id == id, cancellationToken);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<IReadOnlyCollection<UserDto>> GetByCompanyAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var users = await _dbContext.Users
            .Include(x => x.Company)
            .Where(x => x.Company!.Id == companyId && !x.IsDeleted)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IReadOnlyCollection<UserDto>>(users);
    }

    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var users = await _dbContext.Users
            .Include(x => x.Company)
            .Where(x => includeDeleted ? x.IsDeleted : !x.IsDeleted)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IReadOnlyCollection<UserDto>>(users);
    }

    public async Task<UserDto> CreateAsync(UserDto dto, string password)
    {
        var user = _mapper.Map<User>(dto);
        user.CreatedOnUtc = DateTime.UtcNow;
        user.ModifiedOnUtc = DateTime.UtcNow;
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException();
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateAsync(UserDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());

        ArgumentNullException.ThrowIfNull(user);

        user!.Firstname = dto.Firstname;
        user.Lastname = dto.Lastname;
        user.UserName = dto.UserName;
        user.Email = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;
        user.IsAllowedToLogin = dto.IsAllowedToLogin;

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task AssignToRoleAsync(Guid userId, ApplicationRole role)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        ArgumentNullException.ThrowIfNull(user);

        var newRole = _mapper.Map<string>(role);
        if (await _userManager.IsInRoleAsync(user, newRole))
        {
            return;
        }

        var result = await _userManager.AddToRoleAsync(user, newRole);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException();
        }
    }

    public async Task RemoveFromRoleAsync(Guid userId, ApplicationRole role)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        ArgumentNullException.ThrowIfNull(user);

        var newRole = _mapper.Map<string>(role);
        if (!await _userManager.IsInRoleAsync(user, newRole))
        {
            return;
        }

        var result = await _userManager.RemoveFromRoleAsync(user, newRole);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        ArgumentNullException.ThrowIfNull(user);

        user!.IsDeleted = true;
        user.DeletedOnUtc = DateTime.UtcNow;
        user.IsAllowedToLogin = false;
        user.LockoutEnabled = true;
        user.LockoutEnd = DateTimeOffset.Now.AddYears(99);
        user.CreatedOnUtc = DateTime.UtcNow;
        user.ModifiedOnUtc = DateTime.UtcNow;
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException();
        }
    }
}