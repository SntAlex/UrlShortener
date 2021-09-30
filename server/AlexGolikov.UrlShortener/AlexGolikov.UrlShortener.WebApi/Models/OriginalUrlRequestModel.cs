using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.WebApi.Models
{
    /// <summary>
    /// Original url request model
    /// </summary>
    public class OriginalUrlRequestModel
    {
        /// <summary>
        /// Original url
        /// </summary>
        [Url]
        [Required]
        public string Url { get; set; }
    }
}
