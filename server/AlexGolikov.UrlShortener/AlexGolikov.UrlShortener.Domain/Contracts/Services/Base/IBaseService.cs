using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Services.Base
{
    /// <summary>
    /// BaseService interface
    /// </summary>
    /// <typeparam name="TDto">Base Dto model, or model, that inherits it</typeparam>
    /// <typeparam name="TEntity">Base Entity model, or model, that inherits it</typeparam>
    public interface IBaseService<TDto, TEntity> 
        where TDto : BaseDto 
        where TEntity : BaseEntity { }
}
