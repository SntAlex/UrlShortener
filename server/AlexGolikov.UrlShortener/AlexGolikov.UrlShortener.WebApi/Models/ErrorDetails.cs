namespace AlexGolikov.UrlShortener.WebApi.Models
{
    public class ErrorDetails
    {
        public ErrorDetails(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public string Message { get; }
        public int StatusCode { get; }
    }
}
