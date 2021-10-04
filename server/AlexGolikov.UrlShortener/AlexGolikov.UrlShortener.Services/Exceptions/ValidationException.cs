using AlexGolikov.UrlShortener.Services.Exceptions.Base;

namespace AlexGolikov.UrlShortener.Services.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base(400, message) { }
    }
}
