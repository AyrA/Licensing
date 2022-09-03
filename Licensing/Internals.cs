using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AyrA.Licensing.Base
{
    /// <summary>
    /// Contains shared elements between key generator and reader
    /// </summary>
    /// <remarks>Structure of a license:
    /// Format: 11111-22222-33333-44444-55555;
    /// Charset: See <see cref="Alpha"/>;
    /// Segment joiner: <see cref="SegmentJoiner"/>;
    /// Size: 25 bits per component (125 total) if using 32 character alphabet;
    /// Components:
    ///   1. Mask
    ///   2. Expiration date
    ///   3. Applicaion id
    ///   4. Properties and license count
    ///   5. Checksum
    /// </remarks>
    public class Global
    {
        /// <summary>
        /// Length of a segment
        /// </summary>
        public const int SEG_LENGTH = 5;

        /// <summary>
        /// Minimum length of the alphabet
        /// </summary>
        public const int MIN_ALPHA = 16;

        public const string DEFAULT_ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234679";

        /// <summary>
        /// Maximum date value. If the license expiration is at this value, it's considered to never expire.
        /// </summary>
        public static readonly DateTime Forever = new DateTime(0L, DateTimeKind.Utc);

        /// <summary>
        /// This is the character used to join segments together
        /// </summary>
        public static char SegmentJoiner { get; private set; } = '-';

        /// <summary>
        /// This is the bit mask that fully covers <see cref="Alpha"/>
        /// </summary>
        public static int Mask { get; private set; } = 0x1F;

        /// <summary>
        /// This is the alphabet in use. Length must be a power of two
        /// and contain at least at least <see cref="MIN_ALPHA"/> characters.
        /// By default it's 32 characters, and lacks "0158" to avoid confusin with "OISB".
        /// In general you can pick any codepoint you want as long as it fits into UTF-16.
        /// </summary>
        /// <remarks>The alphabet in general is case sensitive</remarks>
        public static string Alpha { get; private set; }

        /// <summary>
        /// This is the application id.
        /// Set it before using any licensing functions.
        /// </summary>
        public static string AppId { get; private set; }

        /// <summary>
        /// This is a fake license key that is just used to offset the real license value
        /// </summary>
        public static string OffsetLicense { get; private set; }

        /// <summary>
        /// Characters in the alphabet
        /// </summary>
        private static int[] AlphaChars;

        /// <summary>
        /// Initialize default alphabet and random license settings
        /// </summary>
        static Global()
        {
            SetAlphabet(DEFAULT_ALPHABET);
        }

        /// <summary>
        /// Swaps bytes in a 32 bit integer
        /// </summary>
        /// <param name="i">Integer</param>
        /// <returns>Swapped integer</returns>
        private static int Swap(int i)
        {
            return (i << 24) |
                ((i & 0xFF00) << 8) |
                ((i & 0xFF0000) >> 8) |
                (i >> 24);
        }

        /// <summary>
        /// Converts a string into UTF32
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>UTF32 characters</returns>
        public static int[] GetCharValues(string s)
        {
            //This is always little endian
            var Data = Encoding.UTF32.GetBytes(s);
            var Ret = new int[Data.Length / 4];
            for (var i = 0; i < Ret.Length; i++)
            {
                Ret[i] = BitConverter.ToInt32(Data, i * 4);
            }
            if (!BitConverter.IsLittleEndian)
            {
                Ret = Ret.Select(Swap).ToArray();
            }
            return Ret;
        }

        /// <summary>
        /// Converts UTF32 characters into a string
        /// </summary>
        /// <param name="Values">UTF32 values</param>
        /// <returns>String</returns>
        public static string FromCharValues(int[] Values)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Values = Values.Select(Swap).ToArray();
            }
            return string.Concat(Values.Select(m => Encoding.UTF32.GetString(BitConverter.GetBytes(m))));
        }

        /// <summary>
        /// Converts a string into indexes from the alphabet
        /// </summary>
        /// <param name="s">String to convert</param>
        /// <returns>Indexes of <see cref="Alpha"/></returns>
        public static int[] GetIndexes(string s)
        {
            CheckIfReady();
            var indexes = GetCharValues(s).Select(m => AI(m)).ToArray();
            if (indexes.Any(m => m < 0))
            {
                throw new ArgumentException("Supplied string cannot be covered by the current alphabet");
            }
            return indexes;
        }

        /// <summary>
        /// Computes the checksum across a number of strings
        /// </summary>
        /// <param name="BitMask">Checksum bitmask</param>
        /// <param name="Values">Values to compute checksum against</param>
        /// <returns>Checksum</returns>
        public static string Checksum(string BitMask, params string[] Values)
        {
            CheckIfReady();
            if (string.IsNullOrEmpty(BitMask))
            {
                throw new ArgumentNullException(nameof(BitMask));
            }
            if (Values == null || Values.Contains(null))
            {
                throw new ArgumentNullException(nameof(Values));
            }
            var MaskList = GetIndexes(BitMask);
            var ValueList = Values.Select(m => GetIndexes(m)).ToArray();
            if (ValueList.Any(m => m.Length != MaskList.Length))
            {
                throw new ArgumentException("At least one supplied value is null or has a different length than the mask", nameof(Values));
            }
            //var indexes = GetIndexes(BitMask);

            foreach (var Segment in ValueList)
            {
                //var ValuePos = GetIndexes(Segment);
                var ValuePos = Segment;
                for (var i = 0; i < ValuePos.Length; i++)
                {
                    MaskList[i] ^= ValuePos[i];
                }
            }
            return FromCharValues(MaskList.Select(ToAlphabet).ToArray());
        }

        /// <summary>
        /// Offsets a string by another
        /// </summary>
        /// <param name="Source">Source string to offset</param>
        /// <param name="BitMask">Value to offset with</param>
        /// <returns>Offset string</returns>
        public static string Offset(string Source, string BitMask)
        {
            if (string.IsNullOrEmpty(Source) || string.IsNullOrEmpty(BitMask) || Source.Length != BitMask.Length)
            {
                throw new ArgumentException("Source and BitMask do not match up. If this keeps happening, increase alphabet size");
            }
            var MI = GetIndexes(BitMask);
            var Chars = GetIndexes(Source).Select((m, i) => AlphaChars[(m ^ MI[i]) & Mask]).ToArray();
            return FromCharValues(Chars);
        }

        /// <summary>
        /// Converts a number into a string
        /// </summary>
        /// <param name="L">Number to convert</param>
        /// <param name="Pad">String size to return</param>
        /// <returns>String</returns>
        public static string LongToStr(long L, int Pad = 0)
        {
            var Ret = new List<int>();
            ulong Value = (ulong)L;
            while (Value != 0)
            {
                Ret.Insert(0, AlphaChars[(int)(Value & (ulong)Mask)]);
                Value /= (ulong)(Mask + 1);
            }
            while (Ret.Count < Pad)
            {
                Ret.Insert(0, AlphaChars[0]);
            }
            return FromCharValues(Ret.ToArray());
        }

        /// <summary>
        /// Converts a string back to a number from <see cref="LongToStr(long, int)"/>
        /// </summary>
        /// <param name="Str">String to convert</param>
        /// <returns>Number</returns>
        public static long StrToLong(string Str)
        {
            var Values = GetCharValues(Str);
            ulong Ret = 0;
            foreach (var V in Values)
            {
                ulong Index = (ulong)AI(V);
                Ret *= (ulong)(Mask + 1);
                Ret |= Index;
            }
            return (long)Ret;
        }

        /// <summary>
        /// Checks if the licensing basics are set up
        /// </summary>
        public static void CheckIfReady()
        {
            var IO = new InvalidOperationException("Licensing has not been set up fully yet");
            if (string.IsNullOrEmpty(Alpha) || string.IsNullOrEmpty(AppId) || string.IsNullOrEmpty(OffsetLicense))
            {
                throw IO;
            }
        }

        /// <summary>
        /// Sets the app id to use in license generation and validation
        /// </summary>
        /// <param name="Id">Application id</param>
        public static void SetAppId(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            if (GetCharValues(Id).Length != SEG_LENGTH)
            {
                throw new FormatException($"Expecting {SEG_LENGTH} characters for AppId");
            }
            if (GetCharValues(Id).All(m => AlphaChars.Contains(m)))
            {
                AppId = Id;
            }
            else
            {
                throw new FormatException("Supplied value cannot be represented using the current alphabet");
            }
        }

        /// <summary>
        /// Sets the alphabet in use.
        /// Will calculate the mask and reset the <see cref="AppId"/>
        /// </summary>
        /// <param name="Alphabet"></param>
        public static void SetAlphabet(string Alphabet)
        {
            if (string.IsNullOrEmpty(Alphabet))
            {
                throw new ArgumentNullException(nameof(Alphabet));
            }
            var ASC = GetCharValues(Alphabet).ToList();
            if (ASC.Count < MIN_ALPHA)
            {
                throw new ArgumentException($"Alphabet must contain at least {MIN_ALPHA} characters");
            }
            for (var i = 0; i < ASC.Count; i++)
            {
                if (ASC.IndexOf(ASC[i]) != i)
                {
                    throw new FormatException($"Supplied alphabet contains a duplicate character: '{Alphabet[i]}'");
                }
            }
            if (ASC.Contains(SegmentJoiner))
            {
                throw new FormatException($"The alphabet can't contain the separator character: '{SegmentJoiner}'");
            }

            if ((ASC.Count & ASC.Count - 1) != 0)
            {
                throw new ArgumentException("Alphabet length must be a power of two");
            }
            AppId = null;
            Alpha = Alphabet;
            Mask = ASC.Count - 1;
            AlphaChars = GetCharValues(Alphabet);
        }

        /// <summary>
        /// Sets the character used to join segments to gether.
        /// By default, it's a dash.
        /// </summary>
        /// <param name="Joiner">New joiner</param>
        public static void SetSegmentJoiner(char Joiner)
        {
            if (Alpha.Contains(Joiner))
            {
                throw new FormatException("Joiner can't be part of the alphabet");
            }
            SegmentJoiner = Joiner;
        }

        /// <summary>
        /// Sets the offset license in use.
        /// </summary>
        /// <param name="License">Offset license</param>
        public static void SetOffsetLicense(string License)
        {
            if (string.IsNullOrEmpty(License))
            {
                throw new ArgumentNullException(nameof(License));
            }
            var Segments = License.Split(SegmentJoiner);
            if (Segments.Length != 5 || Segments.Any(m => GetCharValues(m).Length != SEG_LENGTH))
            {
                throw new ArgumentException($"Offset license needs 5 segments of {SEG_LENGTH} characters each");
            }
            var SegmentIndexes = Segments.SelectMany(m => GetCharValues(m)).ToArray();
            foreach (var C in SegmentIndexes)
            {
                if (!AlphaChars.Contains(C))
                {
                    throw new Exception($"Character {C} not in alphabet");
                }
            }
            OffsetLicense = License;
        }

        /// <summary>
        /// Offsets the current license by a static license value
        /// </summary>
        /// <param name="License">Current license</param>
        /// <returns>Obfuscated license</returns>
        /// <remarks>
        /// This makes sure that segments with similar values turn out completely different
        /// </remarks>
        public static string OffsetCurrentLicense(string License)
        {
            var FE = new FormatException("Invalid license format");
            CheckIfReady();
            if (string.IsNullOrEmpty(License))
            {
                throw new ArgumentNullException(nameof(License));
            }
            var LicenseChars = GetCharValues(License);
            var OffsetChars = GetCharValues(OffsetLicense);
            if (LicenseChars.Length != OffsetChars.Length)
            {
                throw FE;
            }
            var Ret = new int[OffsetChars.Length];
            for (var i = 0; i < Ret.Length; i++)
            {
                //Ensure that the dashes line up
                if (LicenseChars[i] == SegmentJoiner)
                {
                    if (OffsetChars[i] == SegmentJoiner)
                    {
                        Ret[i] = SegmentJoiner;
                    }
                    else
                    {
                        throw FE;
                    }
                }
                else if (OffsetChars[i] == SegmentJoiner)
                {
                    throw FE;
                }
                else
                {
                    Ret[i] = ToAlphabet(AI(LicenseChars[i]) ^ AI(OffsetChars[i]));
                }
            }
            return FromCharValues(Ret);
        }

        /// <summary>
        /// Forces the index into the alphabet range and selects the letter at the given index.
        /// </summary>
        /// <param name="Value">Value</param>
        /// <returns>Alphabet letter</returns>
        public static int ToAlphabet(int Value)
        {
            return AlphaChars[Mask & Value];
        }

        /// <summary>
        /// <see cref="Alpha"/>.IndexOf(v)
        /// </summary>
        /// <param name="v">Character</param>
        /// <returns>Index, or -1 if not found</returns>
        public static int AI(int v)
        {
            for (var i = 0; i < AlphaChars.Length; i++)
            {
                if (AlphaChars[i] == v)
                {
                    return i;
                }
            }
            throw new ArgumentException($"The license alphabet does not contain '{(char)v}'");
        }
    }
}
