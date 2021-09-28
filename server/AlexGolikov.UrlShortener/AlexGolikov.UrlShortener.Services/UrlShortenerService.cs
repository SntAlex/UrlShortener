using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.Domain.Models.Entities;
using AlexGolikov.UrlShortener.Services.Base;
using AlexGolikov.UrlShortener.Services.Helpers;
using AutoMapper;
using System;
using System.Linq;
using System.Text;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.Services.Exceptions;
using AlexGolikov.UrlShortener.Services.Result;
using Microsoft.Extensions.Logging;

namespace AlexGolikov.UrlShortener.Services
{
    public class UrlShortenerService : BaseService<UrlShortenerService>, IUrlShortenerService
    {
        #region constructor
        public UrlShortenerService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UrlShortenerService> logger) : base(mapper, unitOfWork, logger) { }
        #endregion

        public IServiceResult<ShortUrlDto> CreateShortUrl(OriginalUrlDto originalUrl)
        {
            try
            {
                var originalUrlEntity = _unitOfWork.GetRepository<OriginalUrl>()
                    .Get(url => url.Url == originalUrl.Url)
                    .FirstOrDefault();

                if (originalUrlEntity == null)
                {
                    originalUrlEntity = _mapper.Map<OriginalUrl>(originalUrl);
                    _unitOfWork.GetRepository<OriginalUrl>().Add(originalUrlEntity);
                }

                var md5 = originalUrl.Url.ToMd5();
                var base64Url = Convert.ToBase64String(md5);
                
                var shortUrlEntity = new ShortUrl
                {
                    OriginalUrlId = originalUrlEntity.Id,
                    Url = TakeRandomSymbols(base64Url, 6)
                };

                _unitOfWork.GetRepository<ShortUrl>().Add(shortUrlEntity);
                _unitOfWork.Commit();
                return new ServiceResult<ShortUrlDto>(_mapper.Map<ShortUrlDto>(shortUrlEntity));
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
                var shortUrlEntity = _unitOfWork.GetRepository<ShortUrl>()
                    .Get(url => url.Url == shortUrl.Url)
                    .FirstOrDefault();

                if (shortUrlEntity == null)
                {
                    throw new NotFoundException(shortUrl.Url);
                }

                var originalUrlEntity = _unitOfWork.GetRepository<OriginalUrl>().Get(shortUrlEntity.OriginalUrlId);
                return new ServiceResult<OriginalUrlDto>(_mapper.Map<OriginalUrlDto>(originalUrlEntity));
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

        private string TakeRandomSymbols(string input, int amount)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < amount; i++)
            {
                sb.Append(input[input.Length.Next()]);
            }

            return sb.ToString();
        }
    }
}
