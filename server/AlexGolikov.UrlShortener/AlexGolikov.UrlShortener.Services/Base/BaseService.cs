using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Services.Base;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AlexGolikov.UrlShortener.Services.Base
{
    public abstract class BaseService : IBaseService<BaseDto, BaseEntity>
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }

    public abstract class BaseService<TService> : BaseService
        where TService : BaseService
    {
        protected readonly ILogger<TService> Logger;

        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<TService> logger) : base(mapper, unitOfWork)
        {
            Logger = logger;
        }
    }
}
