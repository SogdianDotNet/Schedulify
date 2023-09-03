using Microsoft.AspNetCore.Mvc;
using Schedulify.Domain.Constants;

namespace Schedulify.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected const string Admins = $"{ApplicationRoles.Admin},{ApplicationRoles.SuperAdmin},{ApplicationRoles.CompanyAdmin}";
    
    protected BaseController(){}
}