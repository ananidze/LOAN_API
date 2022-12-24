using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Loan.Queries;

public record GetLoanQuery : IRequest<IEnumerable<Domain.Entities.Loan>>;

public class GetLoanQueryHandler : IRequestHandler<GetLoanQuery, IEnumerable<Domain.Entities.Loan>>
{
    readonly ApplicationDbContext _context;
    
    public GetLoanQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Domain.Entities.Loan>> Handle(GetLoanQuery request, CancellationToken cancellationToken)
    {
        return await _context.Loans.ToListAsync(cancellationToken);
    }
}