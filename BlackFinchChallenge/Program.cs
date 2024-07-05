using BlackFinchChallenge;

// todo abstract out into proper persistence layer 
var loanApplicationStore = new LoanApplicationStore();

Console.WriteLine("Loan application");

while (true)
{
    var loanAmount = RequestDecimal("Please enter your desired loan amount:");
    var assetAmount = RequestDecimal("Please enter your asset value:");
    var creditScore = RequestInt("Please enter your credit score:");
    // todo input validation goes here

    var loanApplication = new LoanApplication(loanAmount, assetAmount, creditScore);

    var loanApplicationResult = LoanApplicationScorer.Score(loanApplication);

    // todo might be advisable to raise an event here in a distributed context
    loanApplicationStore.AddApplicationResult(new LoanApplicationResult(loanApplication, loanApplicationResult.Passed));

    Console.WriteLine($"Loan Application Result: {(loanApplicationResult.Passed ? "Passed" : "Failed")}");

    if (!loanApplicationResult.Passed)
        Console.WriteLine($"Failure reason: {loanApplicationResult.Message}");

    Console.WriteLine("Create another application? Y/N");

    if (Console.ReadLine()?.ToLower() == "y") continue;

    OutputMetrics();
    return;
}

void OutputMetrics()
{
    Console.WriteLine(" - - ");
    Console.WriteLine(" - - ");
    Console.WriteLine($"Total applications to date: {loanApplicationStore.TotalApplications}");
    Console.WriteLine(" - - ");
    Console.WriteLine($"Failures count: {loanApplicationStore.FailedApplications}");
    Console.WriteLine(" - - ");
    Console.WriteLine($"Success count: {loanApplicationStore.SuccessfulApplications}");
    Console.WriteLine(" - - ");
    Console.WriteLine($"Total value of loans written to date: {loanApplicationStore.TotalSuccessfulLoansValue}");
    Console.WriteLine(" - - ");
    Console.WriteLine($"Mean average loan to value of all applications received: {loanApplicationStore.MeanAverageLoanToValue}%");
    Console.WriteLine(" - - ");
    Console.WriteLine(" - - ");
}


static decimal RequestDecimal(string message)
{
    Console.WriteLine(message);
    if (!decimal.TryParse(Console.ReadLine(), out var result))
    {
        throw new ArgumentException();
        //todo, change to a message and a retry
    }

    return result;
}

static int RequestInt(string message)
{
    Console.WriteLine(message);
    if (!int.TryParse(Console.ReadLine(), out var result))
    {
        throw new ArgumentException();
        //todo, change to a message and a retry
    }

    return result;
}
