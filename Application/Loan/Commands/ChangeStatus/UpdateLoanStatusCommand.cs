using Domain.Enums;
using MediatR;

namespace Application.Loan.Commands.ChangeStatus;

public record UpdateLoanStatusCommand() : IRequest
{
    public int Id { get; init; }
    public LoanStatus Status { get; init; }
};