using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using System;
using System.Collections.Generic;

namespace AlexGolikov.UrlShortener.Services.Result
{
    public class ServiceResult : IServiceResult
    {
        public bool IsSuccessful { get; }
        public Exception Exception { get; }

        public ServiceResult()
        {
            IsSuccessful = true;
            Exception = null;
        }

        public ServiceResult(Exception exception)
        {
            IsSuccessful = false;
            Exception = exception;
        }
    }

    public class ServiceResult<TDto> : ServiceResult, IServiceResult<TDto>
        where TDto : BaseDto
    {
        public ServiceResult(IEnumerable<TDto> data)
        {
            Data = data;
        }

        public ServiceResult(TDto data)
        {
            Data = new List<TDto>() { data };
        }

        public ServiceResult(Exception exception) : base(exception)
        {
            Data = new List<TDto>();
        }

        public IEnumerable<TDto> Data { get; }
    }
}
