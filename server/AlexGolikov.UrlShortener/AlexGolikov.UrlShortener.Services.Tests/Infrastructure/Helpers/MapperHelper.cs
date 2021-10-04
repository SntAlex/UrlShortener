using AlexGolikov.UrlShortener.WebApi.Configuration;
using AutoMapper;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers
{
    public static class MapperHelper
    {
        public static IMapper GetInstance()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ShortUrlProfile());
                cfg.AddProfile(new OriginalUrlProfile());
            });
            return config.CreateMapper();
        }
    }
}
