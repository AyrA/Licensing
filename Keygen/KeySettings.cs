using System;
using System.IO;
using System.Xml.Serialization;

namespace Keygen
{
    [Serializable]
    public class KeySettings
    {
        public string AppId { get; set; }

        public string Charset { get; set; }

        public string OffsetLicense { get; set; }

        public FlagOption[] Flags { get; set; }

        public KeySettings()
        {
            Flags = FlagOption.GetDefaults();
        }

        public void Serialize(string FileName)
        {
            XmlSerializer Ser = new XmlSerializer(GetType());
            using (var FS = File.Create(FileName))
            {
                Ser.Serialize(FS, this);
            }
        }

        public static KeySettings Deserialize(string FileName)
        {
            XmlSerializer Ser = new XmlSerializer(typeof(KeySettings));
            using (var FS = File.OpenRead(FileName))
            {
                return (KeySettings)Ser.Deserialize(FS);
            }
        }
    }

    [Serializable]
    public class FlagOption
    {
        public string Name { get; set; }
        
        [XmlAttribute]
        public bool Enabled { get; set; }
        
        [XmlAttribute]
        public bool Checked { get; set; }

        public static FlagOption[] GetDefaults()
        {
            return new FlagOption[]
            {
                new FlagOption(){ Name = "Flag 1", Enabled = true, Checked = false },
                new FlagOption(){ Name = "Flag 2", Enabled = true, Checked = false },
                new FlagOption(){ Name = "Flag 3", Enabled = true, Checked = false },
                new FlagOption(){ Name = "Flag 4", Enabled = true, Checked = false },
                new FlagOption(){ Name = "Flag 5", Enabled = true, Checked = false }
            };
        }
    }
}
