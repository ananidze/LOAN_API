using Domain.Enums;
using MediatR;
namespace Application.Loan.Commands.UpdateLoan;

public record UpdateLoanCommand() : IRequest
{
    public LoanType LoanType { get; set; }
    public decimal LoanAmount { get; set; }
    public string LoanCurrency { get; set; }
    public DateTime LoanStartDate { get; set; }
    public DateTime LoanEndDate { get; set; }
    public LoanStatus LoanStatus { get; set; }
    public int Id { get; set; }
}