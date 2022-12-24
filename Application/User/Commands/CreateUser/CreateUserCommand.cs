using MediatR;

namespace Application.User.Commands.CreateUser;

public record CreateUserCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public decimal MonthlyIncome { get; set; }
}