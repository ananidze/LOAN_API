using Application.Common.Exceptions;
using Domain.Enums;
using Infrastructure;
using MediatR;

namespace Application.Loan.Commands.UpdateLoan;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand>
{
    readonly ApplicationDbContext _context;

    public UpdateLoanCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans.FindAsync(request.Id);
        if (loan == null)
        {
            throw new NotFoundException("Loan not found");
        }
        
        if (loan.LoanStatus != LoanStatus.Processing)
        {
            throw new BadRequestException("Loan status is not processing");
        }
        
        loan.LoanType = request.LoanType;
        loan.LoanAmount = request.LoanAmount;
        loan.LoanCurrency = request.LoanCurrency;
        loan.LoanStartDate = request.LoanStartDate;
        loan.LoanEndDate = request.LoanEndDate;
        loan.LoanStatus = request.LoanStatus;
        
        _context.Loans.Update(loan);
        
        _context.SaveChanges();
        return Unit.Value;
    }
}
