using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public decimal MonthlyIncome { get; set; }
    [JsonIgnore]
    public List<Loan> Loans { get; set; } = new();
}
