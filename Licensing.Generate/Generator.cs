using System;
using System.Linq;
using System.Security.Cryptography;
using AyrA.Licensing.Base;

namespace AyrA.Licensing
{
    /// <summary>
    /// Key generator functions
    /// </summary>
    public static class Generator
    {
        /// <summary>
        /// Generates a key
        /// </summary>
        /// <param name="Expiration">Expiration date. Use <see cref="Forever"/> if it should not expire</param>
        /// <param name="LicenseCount">Number of permitted installations</param>
        /// <returns>License key</returns>
        public static string Keygen(DateTime Expiration, int LicenseCount, LicenseProperties AdditionalFlags)
        {
            Global.CheckIfReady();
            if (LicenseCount > (int)LicenseProperties.UnitCount | LicenseCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(LicenseCount), LicenseCount, $"Allowed range: 0 - {(int)LicenseProperties.UnitCount}");
            }
            if ((AdditionalFlags & ~LicenseProperties.Properties) != 0)
            {
                throw new ArgumentException("Invalid bitmask. Only known property bits are allowed", nameof(AdditionalFlags));
            }
            var Exp = Expiration.ToUniversalTime().Ticks / TimeSpan.TicksPerDay;
            string[] Parts = new string[5];
            //This is the Mask
            Parts[0] = RandomString(Global.SEG_LENGTH);
            //Expiration date
            Parts[1] = Global.LongToStr(Exp, Global.SEG_LENGTH);
            //Application ID
            Parts[2] = Global.AppId;
            //Properties and license count
            Parts[3] = Global.LongToStr(LicenseCount | (int)AdditionalFlags, Global.SEG_LENGTH);
            //Checksum
            Parts[4] = Global.Checksum(Parts[2], Parts[1], Parts[3]);

            //Offset all values by the initial value
            for (var i = 1; i < Parts.Length; i++)
            {
                Parts[i] = Global.Offset(Parts[i], Parts[0]);
            }

            return Global.OffsetCurrentLicense(string.Join(Global.SegmentJoiner.ToString(), Parts));
        }

        /// <summary>
        /// Generates a string that is used to offset all license values
        /// </summary>
        /// <returns>Offset license</returns>
        /// <remarks>
        /// Offsetting with a random string prevents identical values from generating similar output
        /// </remarks>
        public static string GenerateOffsetLicense()
        {
            return string.Join(Global.SegmentJoiner.ToString(),
                RandomString(Global.SEG_LENGTH),
                RandomString(Global.SEG_LENGTH),
                RandomString(Global.SEG_LENGTH),
                RandomString(Global.SEG_LENGTH),
                RandomString(Global.SEG_LENGTH)
            );
        }

        /// <summary>
        /// Generates a random application Id
        /// </summary>
        /// <returns>Application Id</returns>
        public static string GenerateAppId()
        {
            return RandomString(Global.SEG_LENGTH);
        }

        /// <summary>
        /// Generates a random string from the alphabet
        /// </summary>
        /// <param name="Count">Character count</param>
        /// <returns>Generated string</returns>
        private static string RandomString(int Count)
        {
            using (var RNG = RandomNumberGenerator.Create())
            {
                byte[] Buffer = new byte[Count];
                RNG.GetBytes(Buffer);
                return Global.FromCharValues(Buffer.Select(m => Global.ToAlphabet(m)).ToArray());
            }
        }

    }
}
