using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.Domain.Models.Entities;
using AlexGolikov.UrlShortener.Services.Base;
using AlexGolikov.UrlShortener.Services.Exceptions;
using AlexGolikov.UrlShortener.Services.Helpers;
using AlexGolikov.UrlShortener.Services.Result;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AlexGolikov.UrlShortener.Services
{
    /// <summary>
    /// Url shortener service
    /// </summary>
    public class UrlShortenerService : BaseService<UrlShortenerService>, IUrlShortenerService
    {
        #region constructor
        public UrlShortenerService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UrlShortenerService> logger) 
            : base(mapper, unitOfWork, logger) { }
        #endregion

        public IServiceResult<ShortUrlDto> CreateShortUrl(OriginalUrlDto originalUrl)
        {
            try
            {
                var isUrl = Uri.TryCreate(originalUrl.Url, UriKind.Absolute, out var uriResult)
                             && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (!isUrl)
                {
                    throw new Exception("It is not url");
                }

                var originalUrlEntity = UnitOfWork.GetRepository<OriginalUrl>()
                    .Get(url => url.Url == originalUrl.Url)
                    .FirstOrDefault();

                if (originalUrlEntity == null)
                {
                    originalUrlEntity = Mapper.Map<OriginalUrl>(originalUrl);
                    UnitOfWork.GetRepository<OriginalUrl>().Add(originalUrlEntity);
                }

                var md5 = originalUrl.Url.ToMd5();
                var base64Url = Convert.ToBase64String(md5);

                var shortUrlEntity = new ShortUrl
                {
                    OriginalUrlId = originalUrlEntity.Id,
                    Url = base64Url.TakeRandomSymbols(6)
                };

                UnitOfWork.GetRepository<ShortUrl>().Add(shortUrlEntity);
                UnitOfWork.Commit();
                return new ServiceResult<ShortUrlDto>(Mapper.Map<ShortUrlDto>(shortUrlEntity));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Logger.LogError(e, e.Message);
                return new ServiceResult<ShortUrlDto>(e);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new ServiceResult<ShortUrlDto>(new InternalServerException());
            }

        }

        public IServiceResult<OriginalUrlDto> GetOriginalUrl(ShortUrlDto shortUrl)
        {
            try
            {
                var shortUrlEntity = UnitOfWork.GetRepository<ShortUrl>()
                    .Get(url => url.Url == shortUrl.Url)
                    .FirstOrDefault();

                if (shortUrlEntity == null)
                {
                    throw new NotFoundException(shortUrl.Url);
                }

                var originalUrlEntity = UnitOfWork.GetRepository<OriginalUrl>().Get(shortUrlEntity.OriginalUrlId);
                return new ServiceResult<OriginalUrlDto>(Mapper.Map<OriginalUrlDto>(originalUrlEntity));
            }
            catch (NotFoundException e)
            {
                Logger.LogError(e, e.Message);
                return new ServiceResult<OriginalUrlDto>(e);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new ServiceResult<OriginalUrlDto>(new InternalServerException());
            }
        }
    }
}
