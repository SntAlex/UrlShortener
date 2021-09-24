using System.Linq;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.WebApi.Controllers.Base;
using AlexGolikov.UrlShortener.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexGolikov.UrlShortener.WebApi.Controllers
{
    public class UrlShortenerController : BaseController
    {
        private readonly IUrlShortenerService _urlShortenerService;

        #region constructor
        public UrlShortenerController(IMapper mapper, IUrlShortenerService urlShortenerService) : base(mapper)
        {
            _urlShortenerService = urlShortenerService;
        }
        #endregion

        [HttpPost]
        public ActionResult<string> CreateShortUrl(OriginalUrlModel originalUrl)
        {
            var result = _urlShortenerService.CreateShortUrl(Mapper.Map<OriginalUrlDto>(originalUrl));
            ThrowServiceError(result);
            return Ok(result.Data.First().Url);
        }

        [HttpGet("{shortUrl}")]
        public ActionResult<string> GetShortUrl(string shortUrl)
        {
            var result = _urlShortenerService.GetOriginalUrl(Mapper.Map<ShortUrlDto>(shortUrl));
            ThrowServiceError(result);
            return Ok(result.Data.First().Url);
        }
    }
}
