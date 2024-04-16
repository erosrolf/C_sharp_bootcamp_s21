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

bool FullMatchSearch(string fileWithValidNames, string userName)
{
    var file = File.ReadLines(fileWithValidNames);
    foreach (var line in file)
    {
        if (LevensteinDistance(line, userName) == 0)
        {
            return true;
        }
    }
    return false;
}

bool MatchWithTypo(string fileWithValidNames, string userName, int typoDistance)
{
    var file = File.ReadLines(fileWithValidNames);
    foreach (var line in file)
    {
        if (LevensteinDistance(line, userName) < 2)
        {
            if (FixTypo(line))
            {
                return true;
            }
        }
    }
    return false;
}

bool FixTypo(string name)
{
    Console.WriteLine($"Did you mean {name}? Y/N");
    char choice = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (choice == 'Y')
    {
        Console.WriteLine($"Hello, {name}!");
        return true;
    }
    else if (choice == 'N')
    {
        return false;
    }
    else
    {
        Console.WriteLine("Something went wrong. Check your input and retry");
        return FixTypo(name);
    }
}

bool UserNameValidation(string userName)
{
    if (userName.All(c => char.IsLetter(c) || c == ' ' || c == '-'))
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool SearchUserName(string fileWithValidNames, string userName)
{
    if (FullMatchSearch(fileWithValidNames, userName))
    {
        Console.WriteLine($"Hello, {userName}!");
        return true;
    }
    else if (MatchWithTypo(fileWithValidNames, userName, 1))
    {
        return true;
    }
    else
    {
        Console.WriteLine("Your name was not found.");
        return false;
    }
}

string InputUserName()
{
    Console.WriteLine("Enter name:");
    string userName = new string(Console.ReadLine());

    if (string.IsNullOrEmpty(userName) || UserNameValidation(userName) == false)
    {
        Console.WriteLine("Something went wrong. Check your input and retry.");
        userName = InputUserName();
    }
    return userName;
}

string userName = InputUserName();
if (string.IsNullOrEmpty(userName))
{
    Console.WriteLine("Your name was not found.");
}
string fileName = "../materials/us_names.txt";
return Convert.ToByte(SearchUserName(fileName, userName));