using AlexGolikov.UrlShortener.Services.Exceptions.Base;

namespace AlexGolikov.UrlShortener.Services.Exceptions
{
    public class InternalServerException : BaseException
    {
        public InternalServerException() :
            base(500, "Error : Internal server error.")
        { }
    }
}
