using Shouldly;
using Xunit.Abstractions;

namespace BlackFinchChallenge.Tests;

public class RulesTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public RulesTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(1500001, 1000000, 900, false)]
    [InlineData(99000, 1000000, 900, false)]
    [InlineData(1000000, 600000, 949, false)]
    [InlineData(999999, 500000, 700, false)]
    [InlineData(1000000, 1700000, 950, true)]
    // more exhaustive list probably required
    public void Loan_Rule_Tests(decimal loanAmount, decimal assetAmount, int creditScore, bool expectedPass)
    {
        var loanApplication = new LoanApplication(loanAmount, assetAmount, creditScore);

        var loanApplicationResult = LoanApplicationScorer.Score(loanApplication);
        loanApplicationResult.Item1.ShouldBe(expectedPass);
        _testOutputHelper.WriteLine(loanApplicationResult.Item2);
    }
}
