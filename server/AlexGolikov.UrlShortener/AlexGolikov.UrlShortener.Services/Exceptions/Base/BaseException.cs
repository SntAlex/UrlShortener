using System;

namespace AlexGolikov.UrlShortener.Services.Exceptions.Base
{
    /// <summary>
    /// Base exception class
    /// </summary>
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public int HttpStatusCode { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public override string Message { get; }

        #region constructor
        protected BaseException(int httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }
        #endregion

    }
}
