using System.Text;

namespace d05.Nasa.Apod.Models
{
    public class MediaOfToday
    {
        public string Copyright { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public string Explanation { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Url { get; set; } = String.Empty;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Date}\n{Title}");
            if (!string.IsNullOrWhiteSpace(Copyright))
            {
                sb.Append($" by {Copyright}\n");
            }
            sb.Append($"\n{Explanation}\n{Url}\n");
            return sb.ToString();
        }
    }
}
