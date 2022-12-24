using Application.Common.Exceptions;
using Domain.Enums;
using Infrastructure;
using MediatR;

namespace Application.Loan.Commands.DeleteLoan;

public record DeleteLoanCommand(int Id) : IRequest;

public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand>
{
    readonly ApplicationDbContext _context;
    
    public DeleteLoanCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = _context.Loans.FirstOrDefault(x => x.Id == request.Id);
        if (loan == null)
        {
            throw new NotFoundException(nameof(Loan), request.Id);
        }

        if (loan.LoanStatus != LoanStatus.Processing)
        {
            throw new BadRequestException("Loan status is not processing");
        }

        _context.Loans.Remove(loan);
        _context.SaveChanges();
        
        return Unit.Task;
    }
};
