using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Services.Base;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AlexGolikov.UrlShortener.Services.Base
{
    /// <summary>
    /// Base service class
    /// </summary>
    public abstract class BaseService : IBaseService<BaseDto, BaseEntity>
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        #region constructor
        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        #endregion

    }

    /// <summary>
    /// Base service class with logger
    /// </summary>
    /// <typeparam name="TService">Service to log</typeparam>
    public abstract class BaseService<TService> : BaseService
        where TService : BaseService
    {
        protected readonly ILogger<TService> Logger;

        #region constructor
        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<TService> logger) : base(mapper, unitOfWork)
        {
            Logger = logger;
        }
        #endregion

    }
}
