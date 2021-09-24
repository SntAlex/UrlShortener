using System;
using System.Collections.Generic;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Services.Result
{
    public interface IServiceResult
    {
        bool IsSuccessful { get; }
        Exception Exception { get; }
    }

    public interface IServiceResult<out TDto> : IServiceResult
        where TDto : BaseDto
    {
        IEnumerable<TDto> Data { get; }
    }
}
