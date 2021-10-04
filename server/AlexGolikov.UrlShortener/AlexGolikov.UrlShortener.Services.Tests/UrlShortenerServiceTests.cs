using AlexGolikov.UrlShortener.Data.Repositories.Tests.Infrastructure;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.Services.Exceptions;
using AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Fixtures;
using NUnit.Framework;
using System.Linq;

namespace AlexGolikov.UrlShortener.Services.Tests
{
    public class UrlShortenerServiceTests
    {
        private IUrlShortenerService _urlShortenerService;

        [SetUp]
        public void SetUp()
        {
            _urlShortenerService = UrlShortenerServiceFixture.Create();
        }

        [TearDown]
        public void TearDown()
        {
            DbContextDatabaseCleaner.ClearDatabase();
        }

        [Test]
        public void UrlShortenerService_CreatedInstance_NotNull()
        {
            //Assert
            Assert.NotNull(_urlShortenerService);
        }

        [Test]
        public void GetOriginalUrl_WithNullParameter_ShouldReturnIServiceResultWithInternalError()
        {
            //Act
            var result = _urlShortenerService.GetOriginalUrl(null).Exception;

            //Assert
            Assert.IsInstanceOf<InternalServerException>(result);
        }

        [Test]
        public void CreateShortUrl_WithNullParameter_ShouldReturnIServiceResultWithInternalError()
        {
            //Act
            var result = _urlShortenerService.CreateShortUrl(null).Exception;

            //Assert
            Assert.IsInstanceOf<InternalServerException>(result);
        }

        [Test]
        public void CreateShortUrl_WithRightUrl_ShouldReturnIServiceResultWithStringWithSixSymbols()
        {
            //Arrange
            var originalUrl = new OriginalUrlDto
            {
                Url = "https://www.google.com/"
            };

            //Act
            var result = _urlShortenerService.CreateShortUrl(originalUrl).Data.FirstOrDefault()?.Url.Length;

            //Assert
            Assert.IsTrue(result == 6);
        }

        [Test]
        public void CreateShortUrl_WithNotUrl_ShouldReturnIServiceResultWithInternalServerError()
        {
            //Arrange
            var originalUrl = new OriginalUrlDto
            {
                Url = "aaa"
            };

            //Act
            var result = _urlShortenerService.CreateShortUrl(originalUrl).Exception;

            //Assert
            Assert.IsInstanceOf<ValidationException>(result);
        }

        [Test]
        public void CreateShortUrl_WithNullUrl_ShouldReturnIServiceResultWithInternalServerError()
        {
            //Arrange
            var originalUrl = new OriginalUrlDto
            {
                Url = null
            };

            //Act
            var result = _urlShortenerService.CreateShortUrl(originalUrl).Exception;

            //Assert
            Assert.IsInstanceOf<InternalServerException>(result);
        }

        [Test]
        public void GetOriginalUrl_WithNotExistedShortUrlEntity_ShouldReturnIServiceResultWithNotFoundException()
        {
            //Arrange
            var shortUrl = new ShortUrlDto
            {
                Url = "123456"
            };

            //Act
            var result = _urlShortenerService.GetOriginalUrl(shortUrl).Exception;

            //Assert
            Assert.IsInstanceOf<NotFoundException>(result);
        }

        [Test]
        public void GetOriginalUrl_WithNullShortUrlPath_ShouldReturnIServiceResultWithInternalServiceError()
        {
            //Arrange
            var shortUrl = new ShortUrlDto
            {
                Url = null
            };

            //Act
            var result = _urlShortenerService.GetOriginalUrl(shortUrl).Exception;

            //Assert
            Assert.IsInstanceOf<InternalServerException>(result);
        }

        [Test]
        public void GetOriginalUrl_WithExistedShortUrlEntity_ShouldReturnIServiceResultWithOriginalUrl()
        {
            //Arrange
            var shortUrl = new ShortUrlDto
            {
                Url = "qweewq"
            };

            const string expected = "https://www.google.com/";

            //Act
            var result = _urlShortenerService.GetOriginalUrl(shortUrl);

            //Assert
            Assert.NotNull(result.Data.FirstOrDefault());
            Assert.AreEqual(expected, result.Data.FirstOrDefault()?.Url);
        }
    }
}