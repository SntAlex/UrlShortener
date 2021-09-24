using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlexGolikov.UrlShortener.Services.Helpers
{
    internal static class RandomIntHelperExtension
    {
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
