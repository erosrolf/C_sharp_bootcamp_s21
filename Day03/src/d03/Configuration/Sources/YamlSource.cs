using YamlDotNet.Serialization;

public class YamlSource : IConfigurationSource
{
    public int Priority { get; }
    private readonly string _filePath;

    public YamlSource(string filePath, int priority)
    {
        Priority = priority;
        _filePath = filePath;
    }

    public Dictionary<string, object> GetParameters()
    {
        try
        {
            string yamlContent = File.ReadAllText(_filePath);
            var yamlSerializer = new DeserializerBuilder().Build();
            return yamlSerializer.Deserialize<Dictionary<string, object>>(yamlContent);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid data. Check your input and try again.");
            return new Dictionary<string, object>();
        }
    }
}
