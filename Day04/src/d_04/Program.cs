using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

string json = File.ReadAllText("../book_reviews.json");
BookReviewDeserializer bookDeserializer = new BookReviewDeserializer(new SnakeCaseNamingStrategy());
List<BookReview> bookReviews = bookDeserializer.Deserialize(json).ToList();
foreach (var book in bookReviews)
{
    Console.WriteLine(book);
    Console.WriteLine();
}