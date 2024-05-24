using System.Reflection;
using Microsoft.AspNetCore.Http;

var httpContext = new DefaultHttpContext();
Console.WriteLine($"Old Response value: {httpContext.Response}");
var fieldInfo = typeof(DefaultHttpContext).GetField("_response", BindingFlags.NonPublic | BindingFlags.Instance);
fieldInfo?.SetValue(httpContext, null);
Console.WriteLine($"New Response value: {httpContext.Response}");
