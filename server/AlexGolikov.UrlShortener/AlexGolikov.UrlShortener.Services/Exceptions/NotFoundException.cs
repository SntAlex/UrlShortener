using AlexGolikov.UrlShortener.Services.Exceptions.Base;

namespace AlexGolikov.UrlShortener.Services.Exceptions
{
    /// <summary>
    /// Not found exception
    /// </summary>
    public class NotFoundException : BaseException
    {
        public NotFoundException(string entityName) :
            base(404, $"Error : Entity {entityName} not found.")
        { }
    }
}
