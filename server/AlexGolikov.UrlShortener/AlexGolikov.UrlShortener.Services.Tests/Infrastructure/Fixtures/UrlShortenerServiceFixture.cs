using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Fixtures;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Fixtures
{
    public static class UrlShortenerServiceFixture
    {
        public static IUrlShortenerService Create()
        {
            var uow = UnitOfWorkFixture.Create();
            var mapper = MapperHelper.GetInstance();
            var logger = LoggerHelper<UrlShortenerService>.GetMock().Object;
            var urlShortenerService = new UrlShortenerService(mapper, uow, logger);
            return urlShortenerService;
        }
    }
}
