using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;

namespace AlexGolikov.UrlShortener.Domain.Models.Dtos
{
    public class ShortUrlDto : BaseDto
    {
        public string Url { get; set; }

        public OriginalUrlDto OriginalUrl { get; set; }
    }
}
