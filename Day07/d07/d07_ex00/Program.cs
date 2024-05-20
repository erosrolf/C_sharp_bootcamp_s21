using System.Reflection;
using Microsoft.AspNetCore.Http;

Type type = typeof(DefaultHttpContext);
Console.WriteLine($"Type: {type.FullName}");
Console.WriteLine($"Assembly: {type.Assembly.FullName}");
Console.WriteLine($"Based on: {type.BaseType}");

var allFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
var fieldInfo = type.GetFields(allFlags);
var propertyInfo = type.GetProperties(allFlags);
var methodsInfo = type.GetMethods(allFlags);

Console.WriteLine("\nFields:");
foreach (var field in fieldInfo)
{
    Console.WriteLine($"{field.FieldType.FullName} {field.Name}");
}

Console.WriteLine("\nProperties:");
foreach (var property in propertyInfo)
{
    Console.WriteLine($"{property.PropertyType.FullName} {property.Name}");
}

Console.WriteLine("\nMethods:");
foreach (var method in methodsInfo)
{
    var parameters = string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{method.ReturnType.Name} {method.Name} ({parameters})");
}
