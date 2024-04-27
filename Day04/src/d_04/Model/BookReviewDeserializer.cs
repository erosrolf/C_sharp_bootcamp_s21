using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.XPath;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class BookReviewDeserializer
{
    private NamingStrategy _namingStrategy;

    public BookReviewDeserializer(NamingStrategy namingStrategy)
    {
        _namingStrategy = namingStrategy;
    }

    public IEnumerable<BookReview> Deserialize(string json)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = _namingStrategy
            }
        };
        var root = JsonConvert.DeserializeObject<BookJsonStruct.BookReview>(json, settings);

        if (root?.Results != null)
        {
            foreach (var result in root.Results)
            {
                var bookDetail = result.BookDetails?.FirstOrDefault();
                if (bookDetail != null)
                {
                    yield return new BookReview
                    {
                        Title = bookDetail.Title ?? "",
                        Author = bookDetail.Author ?? "",
                        Rank = result.Rank,
                        ListName = result.ListName ?? "",
                        SummaryShort = bookDetail.SummaryShort ?? "",
                        Url = result.AmazonProductUrl ?? ""
                    };
                }
            }
        }
    }
}

namespace BookJsonStruct
{
    public class BookReview
    {
        public string? Status { get; set; }
        public string? Copyright { get; set; }
        public int NumResults { get; set; }
        public string? LastModified { get; set; }
        public List<Result>? Results { get; set; }

        public class Result
        {
            public string? ListName { get; set; }
            public int Rank { get; set; }
            public string? AmazonProductUrl { get; set; }
            public List<BookDetail>? BookDetails { get; set; }

            public class BookDetail
            {
                public string? Title { get; set; }
                [JsonProperty("description")]
                public string? SummaryShort { get; set; }
                public string? Author { get; set; }
            }
        }
    }
}