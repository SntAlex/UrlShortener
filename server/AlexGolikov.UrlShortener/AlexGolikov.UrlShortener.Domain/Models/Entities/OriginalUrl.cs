using System.ComponentModel.DataAnnotations;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace AlexGolikov.UrlShortener.Domain.Models.Entities
{
    [Index(nameof(Url), IsUnique = true)]
    public class OriginalUrl : BaseEntity
    {
        [Url]
        public string Url { get; set; }
    }
}
