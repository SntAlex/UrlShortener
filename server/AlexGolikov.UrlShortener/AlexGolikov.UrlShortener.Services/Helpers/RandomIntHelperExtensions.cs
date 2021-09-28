using System;
using System.Security.Cryptography;

namespace AlexGolikov.UrlShortener.Services.Helpers
{
    /// <summary>
    /// Random int extensions
    /// </summary>
    internal static class RandomIntHelperExtensions
    {
        /// <summary>
        /// Get random int in range
        /// </summary>
        /// <param name="maxValue">Maximum int value</param>
        /// <param name="minValue">Minimal int value</param>
        /// <returns></returns>
        internal static int Next(this int maxValue, int minValue = 0)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue");
            }

            if (minValue == maxValue)
            {
                return minValue;
            }

            long diff = maxValue - minValue;
            var uint32Buffer = new byte[4];
            using var rng = new RNGCryptoServiceProvider();
            while (true)
            {
                rng.GetBytes(uint32Buffer);
                var rand = BitConverter.ToUInt32(uint32Buffer, 0);

                var max = (1 + (long)uint.MaxValue);
                var remainder = max % diff;
                if (rand < max - remainder)
                {
                    return (int)(minValue + (rand % diff));
                }
            }
        }
    }
}
