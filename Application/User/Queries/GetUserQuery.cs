using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries;

public record GetUserQuery : IRequest<IEnumerable<Domain.Entities.User>>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<Domain.Entities.User>>
{
    readonly ApplicationDbContext _context;

    public GetUserQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Entities.User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Users.ToListAsync(cancellationToken))!;
    }
}
