namespace BlackFinchChallenge;

public static class LoanApplicationScorer
{
    // note
    // if we
    public static (bool Passed, string Message) Score(LoanApplication loanApplication) =>
        loanApplication switch
        {
            // todo, messaging + proper try catch handling in main program
            _ when loanApplication.CreditScore is < 1 or > 999 => throw new ArgumentOutOfRangeException(),
            { LoanAmount: > 1500000 } => (false, "Loan amount greater than 1500000"),
            { LoanAmount: < 100000 } => (false, "Loan amount less than 100,000"),
            { LoanToValueRatio: >= 90 } => (false, "Loan To Value Ratio greater or equal to 90%"),
            { LoanAmount: >= 1000000, LoanToValueRatio: > 60 } => (false, "Loan Amount greater or equal to 1000000 and Loan to Value Ratio greater than 60"),
            { LoanAmount: > 1000000, LoanToValueRatio: < 60, CreditScore: < 750 } => (false, "Loan Amount greater than 1000000 and Loan to Value Ratio less than 60 and credit score less than 750"),
            { LoanAmount: > 1000000, LoanToValueRatio: < 80, CreditScore: < 800 } => (false, "Loan Amount greater than 1000000 and Loan to Value Ratio less than 60 and credit score less than 800"),
            { LoanAmount: > 1000000, LoanToValueRatio: < 90, CreditScore: < 900 } => (false, "Loan Amount greater than 1000000 and Loan to Value Ratio less than 60 and credit score less than 900"),
            _ => (true, "Application passed")
        };
}
