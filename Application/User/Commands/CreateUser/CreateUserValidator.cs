using FluentValidation;

namespace Application.User.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required");
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required");
        
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("Username is required");
        
        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18)
            .WithMessage("Age must be at least 18");
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email address");
        
        RuleFor(x => x.MonthlyIncome)
            .GreaterThan(0)
            .WithMessage("Monthly income must be greater than 0");
    }
}