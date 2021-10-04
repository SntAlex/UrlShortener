using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Helpers;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;

namespace AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Fixtures
{
    public class UnitOfWorkFixture
    {
        public IUnitOfWork Create()
        {
            var mock = UnitOfWorkHelper.GetMock();
            return mock.Object;
        }
    }
}