namespace d07_ex03;

public class TypeFactory
{
    public static T CreateWithConstructor<T>()
        where T : class, new()
    {
        var type = typeof(T);
        var constructor = type.GetConstructor(Type.EmptyTypes);
        if (constructor == null)
        {
            throw new InvalidOperationException($"Type {type.Name} does not have a prameterless constructor.");
        }
        return (T)constructor.Invoke(null);
    }

    public static T CreateWithActivator<T>()
        where T : class, new()
    {
        return Activator.CreateInstance<T>();
    }
    
    public static T CreateWithParameters<T>(params object[] args) where T : class
    {
        return (T)Activator.CreateInstance(typeof(T), args);
    }
}