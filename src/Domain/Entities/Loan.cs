using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities;

public class Loan
{
    public int Id { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    public LoanType LoanType { get; set; }
    public decimal LoanAmount { get; set; }
    public string LoanCurrency { get; set; }
    public DateTime LoanStartDate { get; set; }
    public DateTime LoanEndDate { get; set; }
    public LoanStatus LoanStatus { get; set; } = LoanStatus.Processing;
}
