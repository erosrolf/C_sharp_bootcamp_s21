public class Configuration
{
    public Dictionary<string, string> Params { get; private set; }

    public Configuration(IEnumerable<IConfigurationSource> sources)
    {
        Params = new Dictionary<string, string>();

        foreach (var source in sources)
        {
            var parameters = source.GetParameters();
            foreach (var parameter in parameters)
            {
                Params[parameter.Key] = parameter.Value;
            }
        }
    }
}
