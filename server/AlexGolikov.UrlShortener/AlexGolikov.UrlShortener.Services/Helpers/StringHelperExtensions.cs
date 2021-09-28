using System.Security.Cryptography;
using System.Text;

namespace AlexGolikov.UrlShortener.Services.Helpers
{
    /// <summary>
    /// String helper extensions
    /// </summary>
    internal static class StringHelperExtensions
    {
        /// <summary>
        /// Convert string to Md5 byte array
        /// </summary>
        /// <param name="input">String</param>
        /// <returns>Byte array</returns>
        internal static byte[] ToMd5(this string input)
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return hashBytes;
        }
    }
}
