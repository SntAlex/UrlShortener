using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;

namespace AlexGolikov.UrlShortener.Domain.Models.Dtos
{
    /// <summary>
    /// Original url Dto model
    /// </summary>
    public class OriginalUrlDto : BaseDto
    {
        /// <summary>
        /// Original url
        /// </summary>
        public string Url { get; set; }
    }
}
