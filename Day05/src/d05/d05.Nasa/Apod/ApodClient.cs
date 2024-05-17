using System.Net.Http.Json;
using d05.Nasa.Apod.Models;

namespace d05.Nasa.Apod
{
    public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
    {
        private readonly string _apiKey;
        private const string ApiUrl = "https://api.nasa.gov/planetary/apod";
        
        public ApodClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<MediaOfToday[]> GetAsync(int resultCount)
        {
            using HttpClient client = new HttpClient();
            string requestUrl = $"{ApiUrl}?api_key={_apiKey}&count={resultCount}";

            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<MediaOfToday[]>().ConfigureAwait(false);
                return content ?? Array.Empty<MediaOfToday>();
            }
            else
            {
                Console.WriteLine($"GET \"{requestUrl}\" returned {response.StatusCode}:");
                Console.WriteLine(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return Array.Empty<MediaOfToday>();
        }
    }
}
