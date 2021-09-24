using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.WebApi.Models
{
    public class OriginalUrlModel
    {
        [Url]
        public string Url { get; set; }
    }
}
