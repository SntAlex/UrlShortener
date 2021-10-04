using AlexGolikov.UrlShortener.Data.Repositories.Base;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Models.Entities;
using Moq;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers
{
    public static class UnitOfWorkHelper
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var context = new UrlShortenerContextHelper().Context;
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(m => m.GetRepository<OriginalUrl>()).Returns(new Repository<OriginalUrl>(context));
            unitOfWork.Setup(m => m.GetRepository<ShortUrl>()).Returns(new Repository<ShortUrl>(context));

            unitOfWork.Setup(m => m.Commit()).Callback(() => context.SaveChanges(true));

            return unitOfWork;
        }
    }
}
