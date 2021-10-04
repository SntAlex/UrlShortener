using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Fixtures
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