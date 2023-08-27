using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Schedulify.Application.Providers;

internal class ClaimsProvider
{
    private readonly IHttpContextAccessor _httpContext;

    public ClaimsProvider(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public Guid? UserId
    {
        get
        {
            var id = Guid.TryParse(LoggedInUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId) ? userId : Guid.Empty;

            if (id == Guid.Empty)
            {
                return null;
            }

            return id;
        }
    }

    private ClaimsPrincipal? LoggedInUser => _httpContext?.HttpContext?.User;
}