using System;
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

        /// <summary>
        /// Takes random amount of symbols in whole string
        /// </summary>
        /// <param name="input">String input</param>
        /// <param name="amount">Amount of symbols</param>
        /// <returns>String result</returns>
        internal static string TakeRandomSymbols(this string input, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            var sb = new StringBuilder();
            for (var i = 0; i < amount; i++)
            {
                sb.Append(input[input.Length.Next()]);
            }
            return sb.ToString();
        }
    }
}
