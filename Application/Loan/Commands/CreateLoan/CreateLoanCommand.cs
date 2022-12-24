using Domain.Enums;
using MediatR;

namespace Application.Loan.Commands.CreateLoan;

public record CreateLoanCommand : IRequest
{
    public int UserId { get; set; }
    public LoanType LoanType { get; set; }
    public decimal LoanAmount { get; set; }
    public string LoanCurrency { get; set; }
    public DateTime LoanStartDate { get; set; }
    public DateTime LoanEndDate { get; set; }
    public LoanStatus LoanStatus { get; set; } = LoanStatus.Processing;
}