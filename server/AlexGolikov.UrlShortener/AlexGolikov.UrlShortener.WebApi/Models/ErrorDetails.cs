namespace AlexGolikov.UrlShortener.WebApi.Models
{
    /// <summary>
    /// Error model
    /// </summary>
    public class ErrorDetails
    {
        #region constructor
        public ErrorDetails(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        #endregion

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Http error status code
        /// </summary>
        public int StatusCode { get; }
    }
}
