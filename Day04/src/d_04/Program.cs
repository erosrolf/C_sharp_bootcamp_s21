using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

string jsonPath = "../book_reviews.json";
BookReviewDeserializer bookDeserializer = new BookReviewDeserializer(new SnakeCaseNamingStrategy());
List<BookReview> bookReviews = bookDeserializer.Deserialize(jsonPath).ToList();
foreach (var book in bookReviews)
{
    Console.WriteLine(book);
    Console.WriteLine();
}