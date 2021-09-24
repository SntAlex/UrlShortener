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

namespace AlexGolikov.UrlShortener.Services
{
    public class UrlShortenerService : BaseService, IUrlShortenerService
    {
        public UrlShortenerService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

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
                var sb = new StringBuilder();
                for (var i = 0; i < 6; i++)
                {
                    sb.Append(base64Url[base64Url.Length.Next()]);
                }

                var shortUrlEntity = new ShortUrl
                {
                    OriginalUrlId = originalUrlEntity.Id,
                    Url = sb.ToString()
                };

                _unitOfWork.GetRepository<ShortUrl>().Add(shortUrlEntity);
                _unitOfWork.Commit();
                return new ServiceResult<ShortUrlDto>(_mapper.Map<ShortUrlDto>(shortUrlEntity));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return new ServiceResult<ShortUrlDto>(e);
            }
            catch (Exception e)
            {
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
                return new ServiceResult<OriginalUrlDto>(e);
            }
            catch (Exception e)
            {
                return new ServiceResult<OriginalUrlDto>(new InternalServerException());
            }
        }
    }
}
