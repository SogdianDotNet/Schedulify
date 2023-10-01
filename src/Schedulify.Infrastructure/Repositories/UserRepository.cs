using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schedulify.Application.Dtos.Users;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Entities.Users;
using Schedulify.Domain.Enums;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
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

    public async Task<User> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .Include(x => x.UserRoles)!
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .SingleAsync(x => x.Id == id, cancellationToken);

        return user;
    }

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .Include(x => x.UserRoles)!
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .SingleAsync(x => x.Email!.ToLower() == email.ToLower(), cancellationToken);

        return user;
    }

    public async Task<bool> CheckPasswordAsync(User dto, string password)
    {
        var user = _mapper.Map<User>(dto);

        return await _userManager.CheckPasswordAsync(user, password);
    }

    public Task ResetAccessFailedCountAsync(User dto)
    {
        return _userManager.ResetAccessFailedCountAsync(_mapper.Map<User>(dto));
    }

    public Task AccessFailedAsync(User dto)
    {
        return _userManager.AccessFailedAsync(_mapper.Map<User>(dto));
    }

    public async Task<IReadOnlyCollection<User>> GetByCompanyAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var users = await _dbContext.Users
            .Include(x => x.Company)
            .Where(x => x.Company!.Id == companyId && !x.IsDeleted)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users.AsReadOnly();
    }

    public async Task<IReadOnlyCollection<User>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var users = await _dbContext.Users
            .Include(x => x.Company)
            .Where(x => includeDeleted ? x.IsDeleted : !x.IsDeleted)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users.AsReadOnly();
    }

    public async Task<User> CreateAsync(CreateUserDto dto, string password)
    {
        var user = _mapper.Map<User>(dto);
        user.CreatedOnUtc = DateTime.UtcNow;
        user.ModifiedOnUtc = DateTime.UtcNow;
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException();
        }
        
        await _userManager.AddToRolesAsync(user, dto.Roles);
        return user;
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        return _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        var entity = await _userManager.FindByIdAsync(user.Id.ToString());

        ArgumentNullException.ThrowIfNull(entity);

        entity!.Firstname = user.Firstname;
        entity.Lastname = user.Lastname;
        entity.UserName = user.UserName;
        entity.Email = user.Email;
        entity.PhoneNumber = user.PhoneNumber;
        entity.IsAllowedToLogin = user.IsAllowedToLogin;

        await _dbContext.SaveChangesAsync();

        return entity;
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