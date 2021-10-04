using AlexGolikov.UrlShortener.Data.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers
{
    public class UrlShortenerContextHelper
    {
        public UrlShortenerContext Context { get; set; }

        public UrlShortenerContextHelper()
        {
            var builder = new DbContextOptionsBuilder<UrlShortenerContext>();
            builder.UseInMemoryDatabase("UrlShortenerTests")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;
            Context = new UrlShortenerContext(options);
            Context.AddRange(EntityHelper.GetManyOriginalUrls());
            Context.AddRange(EntityHelper.GetManyShortUrls());
            Context.SaveChanges();
        }
    }
}
