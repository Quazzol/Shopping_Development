namespace Quadro.Account.API.Application.Validations;

public class SignUpValidator : AbstractValidator<SignUpModel>
{

    public SignUpValidator()
    {
        RuleFor(x => x.UserName).NotNull().NotEmpty().Length(5, 10);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotNull().Length(8, 12);
    }
}