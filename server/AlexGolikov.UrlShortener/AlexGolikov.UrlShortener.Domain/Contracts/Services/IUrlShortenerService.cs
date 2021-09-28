using AlexGolikov.UrlShortener.Domain.Contracts.Services.Base;
using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Services
{
    /// <summary>
    /// Url shortener service interface
    /// </summary>
    public interface IUrlShortenerService : IBaseService<BaseDto, BaseEntity>
    {
        /// <summary>
        /// Create short url
        /// </summary>
        /// <param name="originalUrl">Original url Dto model</param>
        /// <returns>Service result with short url Dto data</returns>
        IServiceResult<ShortUrlDto> CreateShortUrl(OriginalUrlDto originalUrl);

        /// <summary>
        /// Ger original url
        /// </summary>
        /// <param name="shortUrl">Short url Dto model</param>
        /// <returns>Service result with original url Dto data</returns>
        IServiceResult<OriginalUrlDto> GetOriginalUrl(ShortUrlDto shortUrl);
    }
}
