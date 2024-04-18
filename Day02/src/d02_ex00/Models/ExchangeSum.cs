public struct ExchangeSum
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public override string ToString()
    {
        return $"{Amount:N2} {Currency}";
    }

    static public bool TryParse(string input, out ExchangeSum exchangeSum)
    {
        exchangeSum = default;
        var tokens = input.Split(' ');
        if (tokens.Length == 2 && decimal.TryParse(tokens[0], out var amount))
        {
            var currency = tokens[1];
            exchangeSum = new ExchangeSum { Amount = amount, Currency = currency };
            return true;
        }
        return false;
    }
}