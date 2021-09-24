using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Services.Base
{
    public interface IBaseService<TDto, TEntity> 
        where TDto : BaseDto 
        where TEntity : BaseEntity { }
}
