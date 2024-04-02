using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

static bool ArgsValidate(string[] args, ref double loanAmounth, ref double percentRate, ref int numberOfPeriods)
{
    bool inputIsValid = false;
        if (args.Length == 3) {
            if (double.TryParse(args[0], out loanAmounth) && loanAmounth >= 0 &&
                double.TryParse(args[1], out percentRate) && percentRate >= 0 &&
                int.TryParse(args[2], out numberOfPeriods) && numberOfPeriods >= 0) {
                    inputIsValid = true;
                }
        }
    return inputIsValid;
}
static DateTime BeginOfNextMonth(DateTime currentDate) {
    DateTime beginOfNextMonth;
    if (currentDate.Month == 12) {
        beginOfNextMonth = new DateTime(currentDate.Year + 1, 1, 1);
    } else {
        beginOfNextMonth = new DateTime(currentDate.Year, currentDate.Month + 1, 1);
    }
    return beginOfNextMonth;
}

static double MonthlyRate(double percentRate) {
    return percentRate / 12 / 100;
}

static double TotalMonthlyPayment(double loanAmounth, double percentRate, int numberOfPeriods) {
    double monthlyRate = MonthlyRate(percentRate);
    return loanAmounth * monthlyRate * Math.Pow(1 + monthlyRate, numberOfPeriods) /
                 (Math.Pow(1 + monthlyRate, numberOfPeriods) - 1);
}

static double InterestMonthlyPayment(double totalDeptBalance, double percentRate, DateTime nextPaymentDate) {
    int daysInYear = DateTime.IsLeapYear(nextPaymentDate.Year) ? 366 : 365;
    DateTime previousMonth = nextPaymentDate.AddMonths(-1);
    int daysInMonth = DateTime.DaysInMonth(nextPaymentDate.Year, previousMonth.Month);
    return totalDeptBalance * percentRate * daysInMonth / (100 * daysInYear);
}

static void MakeCreditTable(double loanAmounth, double percentRate, int numberOfPeriods) {
    double payment, interest, principalDept, remainingDept;
    DateTime currentDate = DateTime.Now;
    // currentDate = new DateTime(2021, 5, 5);
    DateTime nextPaymentDate = BeginOfNextMonth(currentDate);

    remainingDept = loanAmounth;
    payment = TotalMonthlyPayment(loanAmounth, percentRate, numberOfPeriods);
    for (int i = 0; i < numberOfPeriods; ++i) {
        interest = InterestMonthlyPayment(remainingDept, percentRate, nextPaymentDate);
        principalDept = payment - interest;
        remainingDept -= principalDept;
        if (i+1 == numberOfPeriods) {
            principalDept += remainingDept;
            payment += remainingDept;
            remainingDept = 0;
        }
        Console.Write($"{i + 1, -7}{nextPaymentDate,-15:MM/dd/yyyy}");
        Console.Write($"{payment,-20:N2}");
        Console.Write($"{principalDept,-20:N2}");
        Console.Write($"{interest,-20:N2}");
        Console.Write($"{remainingDept,-20:N2}");
        Console.WriteLine();
        nextPaymentDate = nextPaymentDate.AddMonths(1);
    }
}

double loanAmounth = 0.0, percentRate = 0.0;
int numberOfPeriods = 0;
bool argsIsValid = ArgsValidate(args, ref loanAmounth, ref percentRate, ref numberOfPeriods);

if(argsIsValid)
{
    MakeCreditTable(loanAmounth, percentRate, numberOfPeriods);
    return 0;
}
else
{
    Console.WriteLine("Something went wrong. Check your input and retry.");
    return 1;
}