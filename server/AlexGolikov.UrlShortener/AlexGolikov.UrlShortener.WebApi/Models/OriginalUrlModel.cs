using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.WebApi.Models
{
    /// <summary>
    /// Original url model
    /// </summary>
    public class OriginalUrlModel
    {
        /// <summary>
        /// Original url
        /// </summary>
        [Url]
        public string Url { get; set; }
    }
}
