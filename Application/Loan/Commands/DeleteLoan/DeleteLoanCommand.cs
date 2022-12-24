using MediatR;

namespace Application.Loan.Commands.DeleteLoan;

public record DeleteLoanCommand(int Id) : IRequest;