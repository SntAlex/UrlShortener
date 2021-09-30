using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.WebApi.Models
{
    /// <summary>
    /// Short url request
    /// </summary>
    public class ShortUrlRequestModel
    {
        /// <summary>
        /// Short url path
        /// </summary>
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The {0} value must be {1} characters.")]
        public string ShortUrlPath { get; set; }
    }
}
