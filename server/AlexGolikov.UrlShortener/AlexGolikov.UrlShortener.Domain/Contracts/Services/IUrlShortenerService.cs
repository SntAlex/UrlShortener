using AlexGolikov.UrlShortener.Domain.Contracts.Services.Base;
using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Services
{
    public interface IUrlShortenerService : IBaseService<BaseDto, BaseEntity>
    {
        IServiceResult<ShortUrlDto> CreateShortUrl(OriginalUrlDto originalUrl);
        IServiceResult<OriginalUrlDto> GetOriginalUrl(ShortUrlDto shortUrl);
    }
}
