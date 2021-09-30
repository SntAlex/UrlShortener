using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Domain.Models.Dtos;
using AlexGolikov.UrlShortener.WebApi.Controllers.Base;
using AlexGolikov.UrlShortener.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AlexGolikov.UrlShortener.WebApi.Controllers
{
    /// <summary>
    /// UrlShortener controller class
    /// </summary>
    public class UrlShortenerController : BaseController
    {
        private readonly IUrlShortenerService _urlShortenerService;

        #region constructor
        public UrlShortenerController(IMapper mapper, IUrlShortenerService urlShortenerService) : base(mapper)
        {
            _urlShortenerService = urlShortenerService;
        }
        #endregion

        /// <summary>
        /// Create short url
        /// </summary>
        /// <param name="originalUrl">Original url model</param>
        /// <returns>Short url</returns>
        [HttpPost]
        public ActionResult<string> CreateShortUrl(OriginalUrlRequestModel originalUrl)
        {
            var result = _urlShortenerService.CreateShortUrl(Mapper.Map<OriginalUrlDto>(originalUrl));
            ThrowServiceError(result);
            return Ok(result.Data.First().Url);
        }

        /// <summary>
        /// Get short url
        /// </summary>
        /// <param name="shortUrl">Short url</param>
        /// <returns>Original url</returns>
        [HttpGet("shortUrl")]
        public ActionResult<string> GetShortUrl([FromQuery] ShortUrlRequestModel shortUrl)
        {
            var result = _urlShortenerService.GetOriginalUrl(Mapper.Map<ShortUrlDto>(shortUrl));
            ThrowServiceError(result);
            return Ok(result.Data.First().Url);
        }
    }
}
