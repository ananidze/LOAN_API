using FluentValidation;

namespace Application.Loan.Commands.UpdateLoan;

public class UpdateLoanValidator : AbstractValidator<UpdateLoanCommand>
{
    public UpdateLoanValidator()
    {
        RuleFor(x => x.LoanAmount)
            .NotEmpty()
            .WithMessage("The Amount field is required.")
            .GreaterThan(0)
            .WithMessage("The Amount field must be greater than 0.");
        
        // RuleFor(x => x.LoanCurrency)
        //     .NotEmpty()
        //     .WithMessage("The Currency field is required.")
        //     .Length(3)
        //     .WithMessage("The Currency field must be 3 characters long.");
        //
        // RuleFor(x => x.LoanEndDate)
        //     .NotEmpty()
        //     .WithMessage("The Period field is required.")
        //     .GreaterThan(DateTime.Now)
        //     .WithMessage("The Period field must be greater than 0.");
        //
        // RuleFor(x => x.LoanType)
        //     .NotEmpty()
        //     .WithMessage("The Type field is required.")
        //     .IsInEnum()
        //     .WithMessage("The Type field must be a valid type.");
    }
}
