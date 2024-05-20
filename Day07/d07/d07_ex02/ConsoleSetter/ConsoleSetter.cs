using System.ComponentModel;
using System.Reflection;
using d07_ex02.Attributes;

namespace d07_ex02.ConsoleSetter;

public class ConsoleSetter
{
    public static void SetValues<T>(T input)
        where T : class
    {
        var type = typeof(T);
        var propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine($"Let's set {typeof(T).Name}!");

        foreach (var property in propertyInfo)
        {
            if (Attribute.IsDefined(property, typeof(NoDisplayAttribute)))
            {
                continue; 
            }

            var descriptionAttribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute));
            var defaultValueAttribute =
                (DefaultValueAttribute)Attribute.GetCustomAttribute(property, typeof(DefaultValueAttribute));

            var description = descriptionAttribute != null ? descriptionAttribute.Description : property.Name;
            
            Console.WriteLine($"Set {description}:");
            var str = Console.ReadLine();
            
            if (String.IsNullOrEmpty(str) && defaultValueAttribute != null)
            {
                str = defaultValueAttribute.Value?.ToString();
            }
            property.SetValue(input, str);
        }
        
        Console.WriteLine("\nWe've set our instance!");
    }
}