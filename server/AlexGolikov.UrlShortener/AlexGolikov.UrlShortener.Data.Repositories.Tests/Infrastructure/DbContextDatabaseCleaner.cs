using AlexGolikov.UrlShortener.Data.DB;

namespace AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure
{
    public static class DbContextDatabaseCleaner
    {
        public static UrlShortenerContext Context { private get; set; }

        public static void ClearDatabase()
        {
            Context.Database.EnsureDeleted();
        }

    }
}
