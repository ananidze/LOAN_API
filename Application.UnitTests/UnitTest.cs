using Domain.Entities;
using Domain.Enums;

namespace Application.UnitTests;

public class Tests
{
    [Test]
    public void TestLoanIdProperty()
    {
        var loan = new Loan();
        var expectedId = 1;
        
        loan.Id = expectedId;
        var actualId = loan.Id;
        
        Assert.AreEqual(expectedId, actualId);
    }

    [Test]
    public void TestLoanUserProperty()
    {
        var loan = new Loan();
        var expectedUser = new User();
        
        loan.User = expectedUser;
        var actualUser = loan.User;
        
        Assert.AreEqual(expectedUser, actualUser);
    }
    
    [Test]
    public void TestLoanTypeProperty()
    {
        var loan = new Loan();
        var expectedLoanType = LoanType.Express;
        
        loan.LoanType = expectedLoanType;
        var actualLoanType = loan.LoanType;
    
        // Assert
        Assert.AreEqual(expectedLoanType, actualLoanType);
    }
    
    [Test]
    public void TestLoanAmountProperty()
    {
        var loan = new Loan();
        var expectedLoanAmount = 1000;
        
        loan.LoanAmount = expectedLoanAmount;
        var actualLoanAmount = loan.LoanAmount;
        
        Assert.AreEqual(expectedLoanAmount, actualLoanAmount);
    }
    
    [Test]
    public void TestLoanCurrencyProperty()
    {
        var loan = new Loan();
        var expectedLoanCurrency = "USD";
        
        loan.LoanCurrency = expectedLoanCurrency;
        var actualLoanCurrency = loan.LoanCurrency;
        
        Assert.AreEqual(expectedLoanCurrency, actualLoanCurrency);
    }
}
