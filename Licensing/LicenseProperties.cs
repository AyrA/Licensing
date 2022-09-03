using System;

namespace AyrA.Licensing.Base
{
    /// <summary>
    /// Represents possible properties of the key.
    /// The field is shared with the license count.
    /// There's space for 5 bits and therefore 5 distinct properties,
    /// unless some properties would conflict,
    /// then the conflict could be interpreted as an additional property.
    /// </summary>
    [Flags]
    public enum LicenseProperties : int
    {
        /// <summary>
        /// Default value
        /// </summary>
        Empty = 0,
        /// <summary>
        /// Allow up to 1048575 per license
        /// </summary>
        UnitCount = 0xFFFFF,
        /// <summary>
        /// This are the bits that remain for properties
        /// </summary>
        Properties = Prop1 | Prop2 | Prop3 | Prop4 | Prop5,
        /// <summary>
        /// Custom key property 1
        /// </summary>
        Prop1 = 0x100000,
        /// <summary>
        /// Custom key property 2
        /// </summary>
        Prop2 = Prop1 << 1,
        /// <summary>
        /// Custom key property 3
        /// </summary>
        Prop3 = Prop2 << 1,
        /// <summary>
        /// Custom key property 4
        /// </summary>
        Prop4 = Prop3 << 1,
        /// <summary>
        /// Custom key property 5
        /// </summary>
        Prop5 = Prop4 << 1,
    }
}
