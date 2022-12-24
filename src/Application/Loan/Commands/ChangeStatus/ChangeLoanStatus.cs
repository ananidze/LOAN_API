using Domain.Enums;
using Infrastructure;
using MediatR;

namespace Application.Loan.Commands.ChangeStatus;

public record UpdateLoanStatusCommand(int Id) : IRequest
{
    public int Id { get; init; }
    public LoanStatus Status { get; init; }
};

public class ChangeLoanStatusHandler : IRequestHandler<UpdateLoanStatusCommand>
{
    readonly ApplicationDbContext _context;
    
    public ChangeLoanStatusHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Task<Unit> Handle(UpdateLoanStatusCommand request, CancellationToken cancellationToken)
    {
        var loan = _context.Loans.Find(request.Id);
        
        loan.LoanStatus = request.Status;
        
        _context.Loans.Update(loan);
        _context.SaveChanges();
        return Unit.Task;
    }
}
