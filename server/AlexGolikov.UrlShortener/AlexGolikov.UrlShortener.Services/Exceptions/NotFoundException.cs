using AlexGolikov.UrlShortener.Services.Exceptions.Base;
using System;

namespace AlexGolikov.UrlShortener.Services.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string entityName) :
            base(404, $"Error : Entity {entityName} not found.")
        { }
    }
}
