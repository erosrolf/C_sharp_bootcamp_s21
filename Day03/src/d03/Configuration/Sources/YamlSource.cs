using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using YamlDotNet.RepresentationModel;

public class YamlSource : IConfigurationSource
{
    private readonly string _filePath;

    public YamlSource(string filePath)
    {
        _filePath = filePath;
    }

    public Dictionary<string, string> GetParameters()
    {
        var yaml = new YamlStream();
    }
}
