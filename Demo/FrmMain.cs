using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Demo
{
    public partial class FrmMain : Form
    {
        private Random R = new Random();

        public FrmMain()
        {
            InitializeComponent();

            Font = new System.Drawing.Font(Font.Name, Math.Max(16f, Font.Size));

            AyrA.Licensing.Base.Global.SetAppId(GetCharBlock());
            AyrA.Licensing.Base.Global.SetOffsetLicense(
                string.Join(AyrA.Licensing.Base.Global.SegmentJoiner.ToString(), new string[] { GetCharBlock(), GetCharBlock(), GetCharBlock(), GetCharBlock(), GetCharBlock() }
                ));

            LblAppId.Text += " " + AyrA.Licensing.Base.Global.AppId;
            BtnCopyId.Tag = AyrA.Licensing.Base.Global.AppId;

            LblOffset.Text += " " + AyrA.Licensing.Base.Global.OffsetLicense;
            BtnCopyOffset.Tag = AyrA.Licensing.Base.Global.OffsetLicense;

            LblCharset.Text += " " + AyrA.Licensing.Base.Global.Alpha;
            BtnCopyCharset.Tag = AyrA.Licensing.Base.Global.Alpha;
        }

        private string GetCharBlock()
        {
            byte[] Data = new byte[5];
            R.NextBytes(Data);
            var Chars = Data
                .Select(m => (char)AyrA.Licensing.Base.Global.ToAlphabet(m))
                .ToArray();
            return new string(Chars);
        }

        private void CopyTag(object sender, EventArgs args)
        {
            var Value = ((Button)sender).Tag.ToString();
            Clipboard.Clear();
            Clipboard.SetText(Value);
            MessageBox.Show($"'{Value}' copied to clipboard", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            AyrA.Licensing.Base.LicenseInfo LI;
            try
            {
                LI = AyrA.Licensing.Verification.Verify.ParseLicense(TbLicense.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Validation failed. {ex.Message}", ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!LI.ChecksumPass)
            {
                MessageBox.Show($"Validation failed. Checksum did not pass. This usually means an invalid application id, offset license, or a different alphabet", "Checksum Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var Result = new string[]
            {
                "License check result:",
                $"Checksum: {(LI.ChecksumPass ? "Pass" : "Fail")}",
                $"Number of copies: {(LI.LicenseCount < 1 ? "Unlimited" : LI.LicenseCount.ToString())}",
                $"Expiration: {(LI.IsPerpetual() ? "Never" : LI.Expiration.AddDays(1).ToShortDateString())}",
                $"Features: {LI.Props}"
            };
            MessageBox.Show(string.Join(Environment.NewLine, Result), "License status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
