using AlexGolikov.UrlShortener.Data.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Helpers
{
    public class UrlShortenerContextHelper
    {
        public UrlShortenerContext Context { get; }

        public UrlShortenerContextHelper()
        {
            var builder = new DbContextOptionsBuilder<UrlShortenerContext>();
            builder.UseInMemoryDatabase("UrlShortenerTests")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;
            Context = new UrlShortenerContext(options);
            DbContextDatabaseCleaner.Context = Context;
            Context.AddRange(EntityHelper.GetManyOriginalUrls());
            Context.AddRange(EntityHelper.GetManyShortUrls());
            Context.SaveChanges();
        }
    }
}
