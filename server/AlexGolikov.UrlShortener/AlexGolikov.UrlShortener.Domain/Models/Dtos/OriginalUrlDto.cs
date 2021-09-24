using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;

namespace AlexGolikov.UrlShortener.Domain.Models.Dtos
{
    public class OriginalUrlDto : BaseDto
    {
        public string Url { get; set; }
    }
}
