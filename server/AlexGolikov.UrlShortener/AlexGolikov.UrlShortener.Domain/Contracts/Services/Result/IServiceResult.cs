using System;
using System.Collections.Generic;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Services.Result
{
    /// <summary>
    /// Non-generic service result interface
    /// </summary>
    public interface IServiceResult
    {
        /// <summary>
        /// If service result successful
        /// </summary>
        bool IsSuccessful { get; }
        
        /// <summary>
        /// Exception, if error
        /// </summary>
        Exception Exception { get; }
    }

    /// <summary>
    /// Dto service result interface
    /// </summary>
    /// <typeparam name="TDto">Dto model, that BaseDto or inherits it</typeparam>
    public interface IServiceResult<out TDto> : IServiceResult
        where TDto : BaseDto
    {
        IEnumerable<TDto> Data { get; }
    }
}
