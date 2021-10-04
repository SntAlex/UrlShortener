using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure;
using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Fixtures;
using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure.Helpers;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Models.Entities;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using NUnit.Framework;
using System;
using System.Linq;

namespace AlexGolikov.UrlShortener.Data.Repositories.Tests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private IUnitOfWork _uow;

        [SetUp]
        public void Setup()
        {
            _uow = UnitOfWorkFixture.Create();
        }

        [TearDown]
        public void TearDown()
        {
            DbContextDatabaseCleaner.ClearDatabase();
        }

        [Test]
        public void UnitOfWork_CreatedInstance_ShouldNotBeNull()
        {
            //Assert
            Assert.NotNull(_uow);
        }

        [Test]
        public void GetOriginalUrlRepository_ShouldNotBeNull()
        {
            //Act
            var result = _uow.GetRepository<OriginalUrl>();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetShortUrlRepository_ShouldNotBeNull()
        {
            //Act
            var result = _uow.GetRepository<ShortUrl>();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetBaseEntityRepository_ShouldBeNull()
        {
            //Act
            var result = _uow.GetRepository<BaseEntity>();

            //Assert
            Assert.Null(result);
        }

        [Test]
        public void Commit_AfterAddingAndCommitInOriginalUrlRepository_ShouldReturnListWithNewEntity()
        {
            //Arrange
            const string newOriginalUrlEntityId = "a3fd8cf7-d35f-4aa0-b36a-1029c98709b9";
            var newOriginalUrlEntity = new OriginalUrl
            {
                Id = Guid.Parse(newOriginalUrlEntityId),
                CreationDate = DateTime.Now,
                Url = "https://www.google.com/"
            };

            //Act
            _uow.GetRepository<OriginalUrl>().Add(newOriginalUrlEntity);
            _uow.Commit();
            var entities = _uow.GetRepository<OriginalUrl>().Get();

            //Assert
            Assert.IsTrue(entities.Contains(newOriginalUrlEntity));
        }

        [Test]
        public void UnitOfWork_WithOriginalUrlId_ShouldReturnEntityWithSameIdAndUrl()
        {
            //Arrange
            var expected = EntityHelper.GetOneOriginalUrl();

            //Act
            var result = _uow.GetRepository<OriginalUrl>().Get(expected.Id);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Url, result.Url);
        }
    }
}