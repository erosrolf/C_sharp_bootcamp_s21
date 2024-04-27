using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

string json = File.ReadAllText("../book_reviews.json");
BookReviewDeserializer bookDeserializer = new BookReviewDeserializer(new SnakeCaseNamingStrategy());
BookReview bookReview = bookDeserializer.Deserialize(json);
foreach (var book in bookReview.Books)
{
    Console.WriteLine(book);
    Console.WriteLine();
}