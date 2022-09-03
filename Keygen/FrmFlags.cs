using System;
using System.Windows.Forms;

namespace Keygen
{
    public partial class FrmFlags : Form
    {
        public readonly FlagOption[] InitFlags;
        private int currentFlag;
        private bool SkipUpdate = false;

        public FrmFlags(FlagOption[] Flags)
        {
            InitFlags = Flags;
            InitializeComponent();
            Font = new System.Drawing.Font(Font.Name, Math.Max(Program.ZoomSize, Font.Size));
            LbFlag.SelectedIndex = 0;
            DisplayFlag(0);
        }

        private void DisplayFlag(int index)
        {
            var F = InitFlags[index];
            SkipUpdate = true;
            CbChecked.Checked = F.Checked && F.Enabled;
            CbChecked.Enabled = F.Enabled;
            CbEnabled.Checked = F.Enabled;
            TbName.Text = F.Name;
            currentFlag = index;
            SkipUpdate = false;
        }

        private void SaveFlag()
        {
            InitFlags[currentFlag] = new FlagOption()
            {
                Checked = CbChecked.Checked && CbEnabled.Checked,
                Enabled = CbEnabled.Checked,
                Name = TbName.Text
            };
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            CbChecked.Enabled = CbEnabled.Checked;
            if (!SkipUpdate)
            {
                SaveFlag();
            }
        }

        private void LbFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbFlag.SelectedIndex >= 0)
            {
                DisplayFlag(LbFlag.SelectedIndex);
            }
        }
    }
}
