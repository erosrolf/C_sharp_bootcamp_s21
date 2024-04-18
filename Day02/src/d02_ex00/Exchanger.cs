using System.Diagnostics.CodeAnalysis;
using System.Globalization;

public class Exchanger
{
    private Dictionary<string, ExchangeRate> rates = new Dictionary<string, ExchangeRate>();

    public Exchanger(string directoryWithRates)
    {
        var files = Directory.GetFiles(directoryWithRates, "*.txt");
        foreach (var file in files)
        {
            var fromCurrency = Path.GetFileNameWithoutExtension(file);
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                var toCurrency = parts[0];
                decimal.TryParse(parts[1], new CultureInfo("fr-FR"), out var rate);
                ExchangeRate exchangeRate = new ExchangeRate { FromCurrency = fromCurrency, ToCurrency = toCurrency, Rate = rate };
                rates.Add($"{fromCurrency}-{toCurrency}", exchangeRate);
            }
        }
    }

    public IEnumerable<ExchangeSum> Convert(ExchangeSum sum)
    {
        foreach (var rate in rates.Values)
        {
            if (rate.FromCurrency == sum.Currency)
            {
                yield return new ExchangeSum
                {
                    Amount = sum.Amount * rate.Rate,
                    Currency = rate.ToCurrency
                };
            }
        }
    }
}