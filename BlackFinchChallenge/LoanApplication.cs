namespace BlackFinchChallenge;

public record LoanApplication(decimal LoanAmount, decimal AssetValue, int CreditScore)
{
    public decimal LoanToValueRatio => this.CalculateLoanToValueRatio();
}
