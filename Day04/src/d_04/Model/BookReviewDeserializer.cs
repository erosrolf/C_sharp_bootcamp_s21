using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class BookReviewDeserializer
{
    private NamingStrategy _namingStrategy;

    public BookReviewDeserializer(NamingStrategy namingStrategy)
    {
        _namingStrategy = namingStrategy;
    }

    public BookReview Deserialize(string json)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = _namingStrategy
            }
        };
        return JsonConvert.DeserializeObject<BookReview>(json, settings);
    }
}