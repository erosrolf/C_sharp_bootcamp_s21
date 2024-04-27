using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class BookReview
{
    public string? Status { get; set; }
    public string? Copyright { get; set; }
    public int NumResults { get; set; }
    public string? LastModified { get; set; }
    [JsonProperty("results")]
    public List<Book>? Books { get; set; }
}

public class Book
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

    public override string ToString()
    {
        var bookDetail = BookDetails?.FirstOrDefault();
        return $"{bookDetail?.Title} by {bookDetail?.Author} [{Rank} on NYT's {ListName}]\n" +
               $"{bookDetail?.SummaryShort}\n" +
               $"{AmazonProductUrl}";
    }
}