using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.WebApi.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexGolikov.UrlShortener.WebApi.Controllers.Base
{
    /// <summary>
    /// Base controller class
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [ValidateModel]
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
