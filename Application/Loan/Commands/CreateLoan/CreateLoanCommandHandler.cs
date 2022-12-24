using Infrastructure;
using MediatR;

namespace Application.Loan.Commands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand>
{
    readonly ApplicationDbContext _context;

    public CreateLoanCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.UserId);
        var loan = new Domain.Entities.Loan
        {
            LoanType = request.LoanType,
            LoanAmount = request.LoanAmount,
            LoanCurrency = request.LoanCurrency,
            LoanStartDate = request.LoanStartDate,
            LoanEndDate = request.LoanEndDate,
        };
        
        user?.Loans.Add(loan);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}