using System;
using System.Linq;
using AyrA.Licensing.Base;

namespace AyrA.Licensing.Verification
{
    /// <summary>
    /// License verification component
    /// </summary>
    public static class Verify
    {
        public static LicenseInfo ParseLicense(string Key)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentNullException(nameof(Key));
            }
            //Undo license offsetting
            Key = Global.OffsetCurrentLicense(Key);
            System.Diagnostics.Debug.Print($"License: {Key}");
            var Segments = Key.Split(Global.SegmentJoiner);
            if (Segments.Length != 5 || Segments.Any(m => Global.GetCharValues(m).Length != Global.SEG_LENGTH))
            {
                throw new ArgumentException("Invalid key format", nameof(Key));
            }
            if (Segments.SelectMany(Global.GetCharValues).Distinct().Count() == 1)
            {
                //Do not accept a license key that after offsetting consists of the same letter only.
                //Among other things, this happens when the user tries to validate the offset license,
                //Because offsetting a license by itself results in the repeated first character of the license alphabet.
                throw new ArgumentException("Invalid license key");
            }
            //Offset all values back to the originals
            Segments = Segments.Select((m, i) => i == 0 ? m : Global.Offset(m, Segments[0])).ToArray();

            LicenseInfo LI = new LicenseInfo();
            if (Segments[4] == Global.Checksum(Segments[2], Segments[1], Segments[3]))
            {
                LI.ChecksumPass = true;
            }
            //Deconstruct expiration date
            try
            {
                LI.Expiration = new DateTime(TimeSpan.TicksPerDay * Global.StrToLong(Segments[1]), DateTimeKind.Utc);
            }
            catch
            {
                LI.Expiration = new DateTime(DateTime.MinValue.Ticks, DateTimeKind.Utc);
            }
            //Copy other license properties
            LI.AppId = Segments[2];
            LI.Props = (LicenseProperties)Global.StrToLong(Segments[3]);
            //Split flags and installation count
            LI.LicenseCount = (int)(LI.Props & LicenseProperties.UnitCount);
            LI.Props &= LicenseProperties.Properties;
            return LI;
        }
    }
}
