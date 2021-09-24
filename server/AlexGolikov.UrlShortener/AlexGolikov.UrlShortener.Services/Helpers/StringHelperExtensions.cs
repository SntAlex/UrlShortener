using System.Security.Cryptography;
using System.Text;

namespace AlexGolikov.UrlShortener.Services.Helpers
{
    internal static class StringHelperExtensions
    {
        internal static byte[] ToMd5(this string input)
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return hashBytes;
        }
    }
}
