using Application.Common.Exceptions;
using Domain.Enums;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Loan.Commands.ChangeStatus;

public class ChangeLoanStatusHandler : IRequestHandler<UpdateLoanStatusCommand>
{
    readonly ApplicationDbContext _context;
    
    public ChangeLoanStatusHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(UpdateLoanStatusCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Id : {request.Id}");
        var loan = await _context.Loans.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (loan == null)
        {
            throw new NotFoundException(nameof(Loan), request.Id);
        }
        
        if (loan.LoanStatus != LoanStatus.Processing)
        {
            throw new BadRequestException("Loan status can only be changed when it is in processing state");
        }
        
        loan.LoanStatus = request.Status;
        
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync(cancellationToken);
        return await Unit.Task;
    }
}