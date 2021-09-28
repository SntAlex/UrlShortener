using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;

namespace AlexGolikov.UrlShortener.Domain.Models.Dtos
{
    /// <summary>
    /// Short url Dto model
    /// </summary>
    public class ShortUrlDto : BaseDto
    {
        /// <summary>
        /// Short url
        /// </summary>
        public string Url { get; set; }
    }
}
