namespace BlackFinchChallenge;

public static class LoanToValueCalculator {

    public static decimal CalculateLoanToValueRatio(this LoanApplication loanApplication)
    {
        return (loanApplication.LoanAmount / loanApplication.AssetValue) * 100;
    }
}
