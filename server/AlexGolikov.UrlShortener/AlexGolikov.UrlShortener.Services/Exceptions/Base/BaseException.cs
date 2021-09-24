using System;

namespace AlexGolikov.UrlShortener.Services.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        public int HttpStatusCode { get; }
        public override string Message { get; }

        protected BaseException(int httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }
    }
}
