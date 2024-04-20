using System.Text.Json;

public class JsonSource : IConfigurationSource
{
    public int Priority { get; }
    private readonly string _filePath;

    public JsonSource(string filePath, int priority)
    {
        Priority = priority;
        _filePath = filePath;
    }

    public Dictionary<string, object> GetParameters()
    {
        try
        {
            var jsonContent = File.ReadAllText(_filePath);
            var result = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent);
            return result ?? new Dictionary<string, object>();
        }
        catch
        {
            Console.WriteLine("Invalid data. Check your input and try again.");
            return new Dictionary<string, object>();
        }
    }
}
