namespace d05.Nasa;

public class Ex01_00 : INasaClient<object, string>
{
    public string GetAsync(object _)
    {
        return string.Empty;
    }
}

public class Ex01_01 : INasaClient<int, char>
{
    public char GetAsync(int input)
    {
        return (char)input;
    }
}

public class Ex01_02 : INasaClient<string[], string>
{
    public string GetAsync(string[] input)
    {
        if (input.Length == 2)
        {
            return input[0] + input[1];
        }

        return string.Empty;
    }
}
