using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Fixtures
{
    class UrlShortenerServiceFixture
    {
        public IUrlShortenerService Create()
        {
            var uow = new UnitOfWorkFixture().Create();
            var mapper = MapperHelper.GetInstance();
            var logger = LoggerHelper<UrlShortenerService>.GetMock().Object;
            var urlShortenerService = new UrlShortenerService(mapper, uow, logger);
            return urlShortenerService;
        }
    }
}
