using Schedulify.Application.Dtos.Users;

namespace Schedulify.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
    Task<LoginResultDto> LoginAsync(LoginDto login, CancellationToken cancellationToken = default);
}