﻿if (ExchangeSum.TryParse(args[0], out var inputSum) && Directory.Exists(args[1]))
{
    Console.WriteLine($"Amount in the original currency: {inputSum}");
    Exchanger exchanger = new Exchanger(args[1]);
    foreach (var convertedSum in exchanger.Convert(inputSum))
    {
        Console.WriteLine($"Amount in {convertedSum.Currency}: {convertedSum:N2}");
    }
}
else
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
}