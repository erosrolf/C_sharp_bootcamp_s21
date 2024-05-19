using d05.Nasa.Apod;
using Newtonsoft.Json.Linq;

if (args is ["apod", _] && int.TryParse(args[1], out int count))
{
    var json = File.ReadAllText("appsettings.json");
    var jsonObj = JObject.Parse(json);

    string apiKey = (string?)jsonObj["ApiKey"] ?? throw new Exception("ApiKey not found");
    // string apiKey = "DEMO_KEY";
    
    var apodClient = new ApodClient(apiKey);
    var result = await apodClient.GetAsync(count);
    foreach (var item in result)
    {
        Console.WriteLine(item);
        Console.WriteLine();
    }
}
else
{
    Console.WriteLine("enter the input parameters \"apod + {count}\"");
}
