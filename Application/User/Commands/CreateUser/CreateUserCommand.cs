using Infrastructure;
using MediatR;

namespace Application.User.Commands;

public record CreateUserCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public decimal MonthlyIncome { get; set; }
}

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