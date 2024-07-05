namespace BlackFinchChallenge;

public record LoanApplicationResult(LoanApplication LoanApplication, bool Pass);

public class LoanApplicationStore
{
    private readonly List<LoanApplicationResult> _applications  = new();
    public void AddApplicationResult(LoanApplicationResult result) => _applications.Add(result);
    public int TotalApplications => _applications.Count;
    public int FailedApplications => _applications.Count(x => !x.Pass);
    public int SuccessfulApplications => _applications.Count(x => x.Pass);
    // presuming this is what loans written to date means ?
    public decimal TotalSuccessfulLoansValue => _applications.Where(x => x.Pass).Sum(x => x.LoanApplication.LoanAmount);
    public decimal MeanAverageLoanToValue => _applications.Select(x => x.LoanApplication.LoanToValueRatio).Average();
}
