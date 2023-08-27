using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Schedulify.Infrastructure.Data.Entities.Users;

namespace Schedulify.Infrastructure.Data;

public class SchedulifyDbContext : IdentityDbContext<ApplicationUser>
{
    
}