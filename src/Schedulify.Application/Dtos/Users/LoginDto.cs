﻿namespace Schedulify.Application.Dtos.Users;

public class LoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}