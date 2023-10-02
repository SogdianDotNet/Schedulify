using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulify.Application.Dtos.Users;
using Schedulify.Application.Services.Interfaces;

namespace Schedulify.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
    {
        var result = await _userService.LoginAsync(dto, cancellationToken);

        return Ok(result);
    }

    [Authorize(Roles = Admins)]
    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Create(CreateUserDto dto, CancellationToken cancellationToken)
    {
        await _userService.CreateAsync(dto, cancellationToken);

        return Accepted();
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(void), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(UpdateUserDto dto, CancellationToken cancellationToken)
    {
        await _userService.UpdateAsync(dto, cancellationToken);

        return Accepted();
    }

    [Authorize(Roles = Admins)]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userService.GetAsync(id, cancellationToken);

        return Ok(user);
    }
}