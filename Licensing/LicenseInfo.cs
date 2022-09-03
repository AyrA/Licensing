using System;

namespace AyrA.Licensing.Base
{
    /// <summary>
    /// License parameters that are obtained from a license key
    /// </summary>
    public class LicenseInfo
    {
        /// <summary>
        /// Properties.
        /// This will have the part that holds license count stripped from it.
        /// </summary>
        public LicenseProperties Props { get; set; }
        /// <summary>
        /// Installation base size
        /// </summary>
        public int LicenseCount { get; set; }
        /// <summary>
        /// Application Id of this license
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// License expiration date
        /// </summary>
        public DateTime Expiration { get; set; }
        /// <summary>
        /// true, if the checksum is valid
        /// </summary>
        public bool ChecksumPass { get; set; }

        /// <summary>
        /// Checks if the license is expired.
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return !IsPerpetual() && Expiration < DateTime.UtcNow;
        }

        /// <summary>
        /// Gets whether the license never expires or not
        /// </summary>
        /// <returns>true, if never expires</returns>
        public bool IsPerpetual()
        {
            return Expiration == Global.Forever;
        }

        /// <summary>
        /// Checks if the license is considered valid.
        /// </summary>
        /// <returns>true, if license is valid</returns>
        public bool IsValid()
        {
            return ChecksumPass &&
                AppId == Global.AppId &&
                LicenseCount >= 0 &&
                !IsExpired();
        }
    }
}
