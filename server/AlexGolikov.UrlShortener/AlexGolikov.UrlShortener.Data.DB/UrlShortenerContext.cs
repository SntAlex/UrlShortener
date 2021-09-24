using AlexGolikov.UrlShortener.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlexGolikov.UrlShortener.Data.DB
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<OriginalUrl> OriginalUrls { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { }
    }
}
