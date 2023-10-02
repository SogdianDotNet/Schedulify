using Schedulify.Application.Dtos.Users;
using Schedulify.Domain.Entities.Users;
using Schedulify.Domain.Enums;

namespace Schedulify.Application.Interfaces;

internal interface IUserRepository
{
    Task<User> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<User>> GetByCompanyAsync(Guid companyId, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<User>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task ResetAccessFailedCountAsync(User user);
    Task AccessFailedAsync(User user);
    Task<User> CreateAsync(CreateUserDto dto, string password);
    Task<User> UpdateAsync(UpdateUserDto dto);
    Task AssignToRoleAsync(Guid userId, ApplicationRole role);
    Task RemoveFromRoleAsync(Guid userId, ApplicationRole role);
    Task DeleteAsync(Guid id);
    Task<string> GenerateEmailConfirmationTokenAsync(User user);
}