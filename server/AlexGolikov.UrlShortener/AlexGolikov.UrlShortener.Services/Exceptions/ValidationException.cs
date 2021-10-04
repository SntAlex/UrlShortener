using AlexGolikov.UrlShortener.Services.Exceptions.Base;

namespace AlexGolikov.UrlShortener.Services.Exceptions
{
    /// <summary>
    /// Validation exception
    /// </summary>
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base(400, message) { }
    }
}
