using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.WebApi.Models
{
    public class ShortUrlModel
    {
        [Url]
        public string Url { get; set; }
    }
}
