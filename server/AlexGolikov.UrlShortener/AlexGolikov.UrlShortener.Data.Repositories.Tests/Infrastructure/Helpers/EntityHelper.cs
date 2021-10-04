using AlexGolikov.UrlShortener.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Helpers
{
    public static class EntityHelper
    {
        public static OriginalUrl GetOneOriginalUrl(string id = "af7079f2-27ea-4d33-863d-e5f64a154d5a")
        {
            return new OriginalUrl
            {
                Id = Guid.Parse(id),
                CreationDate = DateTime.Now,
                Url = "https://www.google.com/"
            };
        }

        public static ShortUrl GetOneShortUrl(
            string id = "f6f33f79-ce98-4f88-8ec9-b0c6b2061a3d",
            string originalUrlId = "af7079f2-27ea-4d33-863d-e5f64a154d5a")
        {
            return new ShortUrl
            {
                Id = Guid.Parse(id),
                CreationDate = DateTime.Now,
                OriginalUrlId = Guid.Parse(originalUrlId)
            };
        }

        public static IEnumerable<OriginalUrl> GetManyOriginalUrls()
        {
            yield return GetOneOriginalUrl();
        }

        public static IEnumerable<ShortUrl> GetManyShortUrls()
        {
            yield return GetOneShortUrl();
        }
    }
}
