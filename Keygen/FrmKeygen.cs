using System;
using System.Linq;
using System.Windows.Forms;
using AyrA.Licensing.Base;

namespace Keygen
{
    public partial class FrmKeygen : Form
    {
        private class BoxInfo
        {
            public CheckBox Box;
            public LicenseProperties Prop;

            public void SetBox(FlagOption FO)
            {
                Box.Text = FO.Name;
                Box.Enabled = FO.Enabled;
                Box.Checked = FO.Checked;
            }

            public FlagOption GetBox()
            {
                return new FlagOption()
                {
                    Checked = Box.Checked && Box.Enabled,
                    Enabled = Box.Enabled,
                    Name = Box.Text
                };
            }
        }

        private readonly BoxInfo[] Boxes;

        public FrmKeygen()
        {
            InitializeComponent();

            //This makes iteration over the flag boxes much easier
            Boxes = new BoxInfo[]
            {
                new BoxInfo() { Box = CbProp1, Prop = LicenseProperties.Prop1 },
                new BoxInfo() { Box = CbProp2, Prop = LicenseProperties.Prop2 },
                new BoxInfo() { Box = CbProp3, Prop = LicenseProperties.Prop3 },
                new BoxInfo() { Box = CbProp4, Prop = LicenseProperties.Prop4 },
                new BoxInfo() { Box = CbProp5, Prop = LicenseProperties.Prop5 }
            };

            TbAlphabet.Text = Global.Alpha;
            TbAppId.Text = Global.AppId;
            TbOffsetLicense.Text = Global.OffsetLicense;
            TbLicCount.Maximum = (int)LicenseProperties.UnitCount;
            Font = new System.Drawing.Font(Font.Name, Math.Max(Program.ZoomSize, Font.Size));

            TbExpDate.Value = TbExpDate.Value.ToUniversalTime().Date.AddMonths(1);
            //Make dialogs identical
            SFD.DefaultExt = OFD.DefaultExt;
            SFD.Filter = OFD.Filter;

            SetDefaultFlags();
#if DEBUG
            Text += " [DEBUG MODE, using fake values]";
#endif
        }

#if DEBUG
        private void SetRandomCharset(string s)
        {
            Global.SetAlphabet(s);
            string Offset = AyrA.Licensing.Generator.GenerateOffsetLicense();
            string AppId = AyrA.Licensing.Generator.GenerateAppId();
            Global.SetAppId(AppId);
            Global.SetOffsetLicense(Offset);

            TbAppId.Text = AppId;
            TbAlphabet.Text = s;
            TbOffsetLicense.Text = Offset;
        }
#endif

        private void Err(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Info(string msg, string title = null)
        {
            MessageBox.Show(msg, title ?? Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetDefaultFlags()
        {
            var Opt = FlagOption.GetDefaults();
            for (var i = 0; i < Opt.Length; i++)
            {
                Boxes[i].SetBox(Opt[i]);
            }
        }

        private LicenseProperties GetFlags()
        {
            var F = LicenseProperties.Empty;
            foreach (var B in Boxes.Where(m => m.Box.Checked && m.Box.Enabled).Select(m => m.Prop))
            {
                F |= B;
            }
            return F;
        }

        private void BtnSetAppId_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TbAppId.Text))
                {
                    TbAppId.Text = AyrA.Licensing.Generator.GenerateAppId();
                }
                Global.SetAppId(TbAppId.Text);
            }
            catch (Exception ex)
            {
                Err(ex);
            }
        }

        private void BtnSetAlpha_Click(object sender, EventArgs e)
        {
            try
            {
                Global.SetAlphabet(TbAlphabet.Text);
                if (!string.IsNullOrEmpty(TbAppId.Text))
                {
                    BtnSetAppId_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Err(ex);
            }
        }

        private void BtnSetOffset_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TbOffsetLicense.Text))
                {
                    TbOffsetLicense.Text = AyrA.Licensing.Generator.GenerateOffsetLicense();
                }
                Global.SetOffsetLicense(TbOffsetLicense.Text);
            }
            catch (Exception ex)
            {
                Err(ex);
            }
        }

        private void BtnExp1Y_Click(object sender, EventArgs e)
        {
            TbExpDate.Value = DateTime.UtcNow.AddYears(1);
        }

        private void CbExpNever_CheckedChanged(object sender, EventArgs e)
        {
            TbExpDate.Enabled = !CbExpNever.Checked;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Global.CheckIfReady();
            }
            catch (Exception ex)
            {
                Err(ex);
                return;
            }
            var Exp = CbExpNever.Checked ? Global.Forever : TbExpDate.Value;
            TbKey.Text = AyrA.Licensing.Generator.Keygen(Exp, (int)TbLicCount.Value, GetFlags());

            var License = AyrA.Licensing.Verification.Verify.ParseLicense(TbKey.Text);
            if (!License.IsValid())
            {
                MessageBox.Show("License not considered valid");
            }
            else
            {
                TbKey.SelectAll();
                TbKey.Focus();
            }
        }

        private void BtnParseKey_Click(object sender, EventArgs e)
        {
            LicenseInfo License;
            try
            {
                License = AyrA.Licensing.Verification.Verify.ParseLicense(TbParseKey.Text);
            }
            catch (Exception ex)
            {
                Err(ex);
                return;
            }
            if (!License.ChecksumPass)
            {
                Info("License checksum failed. Make sure the settings are correct.");
            }
            else
            {
                if (License.AppId != TbAppId.Text)
                {
                    Info("License application id differs from the currently set value");
                }
                if (License.Expiration == Global.Forever)
                {
                    CbExpNever.Checked = true;
                }
                else
                {
                    CbExpNever.Checked = false;
                    TbExpDate.Value = License.Expiration.ToLocalTime();
                }
                TbLicCount.Value = License.LicenseCount;
                foreach (var B in Boxes)
                {
                    B.Box.Checked = B.Box.Enabled && License.Props.HasFlag(B.Prop);
                }
                Info("License parsed");
            }
        }

        private void BtnRandomize_Click(object sender, EventArgs e)
        {
            try
            {
                var s1 = AyrA.Licensing.Generator.GenerateAppId();
                var s2 = AyrA.Licensing.Generator.GenerateOffsetLicense();
                TbAppId.Text = s1;
                TbOffsetLicense.Text = s2;
                Global.SetAppId(s1);
                Global.SetOffsetLicense(s2);
            }
            catch (Exception ex)
            {
                Err(ex);
            }
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    new KeySettings()
                    {
                        AppId = TbAppId.Text,
                        Charset = TbAlphabet.Text,
                        OffsetLicense = TbOffsetLicense.Text,
                        Flags = Boxes.Select(m => m.GetBox()).ToArray()
                    }.Serialize(SFD.FileName);
                }
                catch (Exception ex)
                {
                    Err(ex);
                }
            }
        }

        private void BtnLoadConfig_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var Values = KeySettings.Deserialize(OFD.FileName);
                    Global.SetAlphabet(TbAlphabet.Text = Values.Charset);
                    Global.SetAppId(TbAppId.Text = Values.AppId);
                    Global.SetOffsetLicense(TbOffsetLicense.Text = Values.OffsetLicense);
                    SetDefaultFlags();
                    if (Values.Flags != null)
                    {
                        for (var i = 0; i < Values.Flags.Length; i++)
                        {
                            var B = Boxes[i];
                            var F = Values.Flags[i];
                            B.SetBox(F);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Err(ex);
                }
            }
        }

        private void BtnSetFlags_Click(object sender, EventArgs e)
        {
            using (var f = new FrmFlags(Boxes.Select(m => m.GetBox()).ToArray()))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    for(var i=0;i< f.InitFlags.Length; i++)
                    {
                        Boxes[i].SetBox(f.InitFlags[i]);
                    }
                }
            }
        }
    }
}
