using Infrastructure;
using MediatR;

namespace Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    readonly ApplicationDbContext _context;

    public CreateUserCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Age = request.Age,
            Email = request.Email,
            MonthlyIncome = request.MonthlyIncome
        };

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
