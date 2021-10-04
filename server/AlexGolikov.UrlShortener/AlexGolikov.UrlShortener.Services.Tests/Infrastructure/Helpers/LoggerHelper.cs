using System;
using AlexGolikov.UrlShortener.Services.Base;
using Microsoft.Extensions.Logging;
using Moq;

namespace AlexGolikov.UrlShortener.Services.Tests.Infrastructure.Helpers
{
    public static class LoggerHelper<TService> where TService: BaseService
    {
        public static Mock<ILogger<TService>> GetMock()
        {
            var logger = new Mock<ILogger<TService>>();
            return logger;
        }
    }
}
