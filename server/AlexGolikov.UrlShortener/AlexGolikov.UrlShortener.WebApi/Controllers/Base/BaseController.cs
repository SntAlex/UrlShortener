using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexGolikov.UrlShortener.WebApi.Controllers.Base
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;

        #region costructor
        protected BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
        #endregion

        /// <summary>
        /// Throw service result errors
        /// </summary>
        /// <param name="serviceResult">Error, if exists</param>
        protected void ThrowServiceError(IServiceResult serviceResult)
        {
            if (!serviceResult.IsSuccessful)
            {
                throw serviceResult.Exception;
            }
        }
    }
}
