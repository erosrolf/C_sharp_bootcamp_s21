public interface IConfigurationSource
{
    int Priority { get; }
    Dictionary<string, object> GetParameters();
}
