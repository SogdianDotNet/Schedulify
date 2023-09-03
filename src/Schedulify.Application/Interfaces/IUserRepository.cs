using Schedulify.Domain.Dtos.Users;
using Schedulify.Domain.Enums;

namespace Schedulify.Application.Interfaces;

public interface IUserRepository
{
    Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<UserDto>> GetByCompanyAsync(Guid companyId, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<UserDto>> GetAllAsync(bool includeDeleted = false, CancellationToken cancellationToken = default);
    Task<bool> CheckPasswordAsync(UserDto dto, string password);
    Task ResetAccessFailedCountAsync(UserDto dto);
    Task AccessFailedAsync(UserDto dto);
    Task<UserDto> CreateAsync(CreateUserDto dto, string password);
    Task<UserDto> UpdateAsync(UserDto dto);
    Task AssignToRoleAsync(Guid userId, ApplicationRole role);
    Task RemoveFromRoleAsync(Guid userId, ApplicationRole role);
    Task DeleteAsync(Guid id);
    Task<string> GenerateEmailConfirmationTokenAsync(UserDto dto);
}