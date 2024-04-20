try
{
    var jsonSource = new JsonSource(args[0], int.Parse(args[1]));
    var yamlSource = new YamlSource(args[2], int.Parse(args[3]));

    Configuration conf = new Configuration(new List<IConfigurationSource> { jsonSource, yamlSource });
    Console.WriteLine("Configuration:");
    foreach (var param in conf.Params)
    {
        Console.WriteLine($"{param.Key} : {param.Value}");
    }
}
catch
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}
