using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.Domain.Models.Entities
{
    [Index(nameof(Url), IsUnique = true)]
    public class OriginalUrl : BaseEntity
    {
        [Url]
        [Required]
        public string Url { get; set; }
    }
}
