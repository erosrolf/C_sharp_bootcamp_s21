public class Configuration
{
    public Dictionary<string, object> Params { get; private set; }

    public Configuration(IEnumerable<IConfigurationSource> sources)
    {
        Params = new Dictionary<string, object>();

        foreach (var source in sources.OrderBy(s => s.Priority))
        {
            var parameters = source.GetParameters();
            foreach (var parameter in parameters)
            {
                Params[parameter.Key] = parameter.Value;
            }
        }
    }
}
