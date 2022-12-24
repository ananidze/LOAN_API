using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Loan.Queries;

public record GetLoanByUserId(int Id) : IRequest<IEnumerable<Domain.Entities.Loan>>;

public class GetLoanByUserIdHandler : IRequestHandler<GetLoanByUserId, IEnumerable<Domain.Entities.Loan>>
{
    readonly ApplicationDbContext _context;
    
    public GetLoanByUserIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Entities.Loan>> Handle(GetLoanByUserId request, CancellationToken cancellationToken)
    {
        var loans = await _context.Users
            .Where(x => x.Id == request.Id)
            .SelectMany(x => x.Loans)
            .ToListAsync(cancellationToken);
        
        return loans;
    }
}
