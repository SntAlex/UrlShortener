using AlexGolikov.UrlShortener.Domain.Contracts.Services.Result;
using AlexGolikov.UrlShortener.Domain.Models.Dtos.Base;
using System;
using System.Collections.Generic;

namespace AlexGolikov.UrlShortener.Services.Result
{
    /// <summary>
    /// Not generic Service result
    /// </summary>
    public class ServiceResult : IServiceResult
    {
        /// <summary>
        /// If service result successful
        /// </summary>
        public bool IsSuccessful { get; }

        /// <summary>
        /// Exception, if error
        /// </summary>
        public Exception Exception { get; }

        #region constructors
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
        #endregion

    }

    /// <summary>
    /// Dto service result
    /// </summary>
    /// <typeparam name="TDto">Class, that BaseDto or inherits it</typeparam>
    public class ServiceResult<TDto> : ServiceResult, IServiceResult<TDto>
        where TDto : BaseDto
    {
        public IEnumerable<TDto> Data { get; }

        #region constructors
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
        #endregion
    }
}
