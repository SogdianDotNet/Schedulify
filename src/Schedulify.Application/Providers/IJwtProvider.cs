using System.Buffers.Text;
using System.Security.Claims;
using Schedulify.Domain.Dtos.Users;

namespace Schedulify.Application.Providers;

public interface IJwtProvider
{
    TokenDto Generate(List<Claim> claims);
}