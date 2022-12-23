using Infrastructure;
using MediatR;

namespace Application.User.Queries;

public record GetUserByIdQuery(int Id) : IRequest<Domain.Entities.User>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Domain.Entities.User>
{
    readonly ApplicationDbContext _context;

    public GetUserByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Users.FindAsync(request.Id))!;
    }
}
