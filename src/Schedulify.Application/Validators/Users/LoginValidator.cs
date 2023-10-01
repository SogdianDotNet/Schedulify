using FluentValidation;
using Schedulify.Application.Dtos.Users;

namespace Schedulify.Application.Validators.Users;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}