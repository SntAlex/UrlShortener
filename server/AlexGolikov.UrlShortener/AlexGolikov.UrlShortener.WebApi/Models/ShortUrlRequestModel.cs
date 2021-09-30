using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.WebApi.Models
{
    public class ShortUrlRequestModel
    {
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The {0} value must be {1} characters.")]
        public string ShortUrlPath { get; set; }
    }
}
