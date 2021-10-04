using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Helpers;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;

namespace AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Fixtures
{
    public static class UnitOfWorkFixture
    {
        public static IUnitOfWork Create()
        {
            var mock = UnitOfWorkHelper.GetMock();
            return mock.Object;
        }
    }
}