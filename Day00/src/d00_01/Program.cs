int LevensteinDistance(string a, string b)
{
    if (string.IsNullOrEmpty(a))
    {
        return string.IsNullOrEmpty(b) ? 0 : b.Length;
    }
    if (string.IsNullOrEmpty(b))
    {
        return string.IsNullOrEmpty(a) ? 0 : b.Length;
    }
    if (string.Equals(a, b))
    {
        return 0;
    }

    var distances = new int[a.Length + 1, b.Length + 1];
    for (int i = 0; i <= a.Length; distances[i, 0] = i++) ;
    for (int i = 0; i <= b.Length; distances[0, i] = i++) ;
    for (int i = 1; i <= a.Length; i++)
    {
        for (int j = 1; j <= b.Length; j++)
        {
            if (a[i - 1] == b[j - 1])
            {
                distances[i, j] = distances[i - 1, j - 1];
            }
            else
            {
                distances[i, j] = 1 + Math.Min(Math.Min(distances[i - 1, j],
                                                        distances[i, j - 1]),
                                                        distances[i - 1, j - 1]);
            }
        }
    }
    return distances[a.Length, b.Length];
}

Console.WriteLine("Enter name:");
string clientName = new string(Console.ReadLine());

if (string.IsNullOrEmpty(clientName))
{
    Console.WriteLine("Your name was not found.");
    Environment.Exit(0);
}

var file = File.ReadLines("../materials/us_names.txt");
bool nameIsFound = false;

foreach (var line in file)
{
    if (LevensteinDistance(line, clientName) == 0)
    {
        Console.WriteLine($"Hello, {line}!");
        Environment.Exit(0);
    }
    else if (LevensteinDistance(line, clientName) < 2)
    {
        Console.WriteLine($"Did you mean \"{line}\"? Y/N");
        ConsoleKeyInfo choice = Console.ReadKey();
        if (choice.KeyChar == 'Y')
        {
            Console.WriteLine($"Hello, {line}!");
            Environment.Exit(0);
        }
        else
        {
            continue;
        }
    }
    else
    {
        Console.WriteLine("Your name was not found.");
    }
}