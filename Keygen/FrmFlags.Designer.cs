
namespace Keygen
{
    partial class FrmFlags
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbFlag = new System.Windows.Forms.ListBox();
            this.CbEnabled = new System.Windows.Forms.CheckBox();
            this.CbChecked = new System.Windows.Forms.CheckBox();
            this.TbName = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbFlag
            // 
            this.LbFlag.FormattingEnabled = true;
            this.LbFlag.Items.AddRange(new object[] {
            "Flag 1",
            "Flag 2",
            "Flag 3",
            "Flag 4",
            "Flag 5"});
            this.LbFlag.Location = new System.Drawing.Point(12, 12);
            this.LbFlag.Name = "LbFlag";
            this.LbFlag.Size = new System.Drawing.Size(92, 69);
            this.LbFlag.TabIndex = 0;
            this.LbFlag.SelectedIndexChanged += new System.EventHandler(this.LbFlag_SelectedIndexChanged);
            // 
            // CbEnabled
            // 
            this.CbEnabled.AutoSize = true;
            this.CbEnabled.Location = new System.Drawing.Point(110, 12);
            this.CbEnabled.Name = "CbEnabled";
            this.CbEnabled.Size = new System.Drawing.Size(65, 17);
            this.CbEnabled.TabIndex = 1;
            this.CbEnabled.Text = "Enabled";
            this.CbEnabled.UseVisualStyleBackColor = true;
            this.CbEnabled.CheckedChanged += new System.EventHandler(this.Value_Changed);
            // 
            // CbChecked
            // 
            this.CbChecked.AutoSize = true;
            this.CbChecked.Location = new System.Drawing.Point(110, 35);
            this.CbChecked.Name = "CbChecked";
            this.CbChecked.Size = new System.Drawing.Size(118, 17);
            this.CbChecked.TabIndex = 2;
            this.CbChecked.Text = "Checked by default";
            this.CbChecked.UseVisualStyleBackColor = true;
            this.CbChecked.CheckedChanged += new System.EventHandler(this.Value_Changed);
            // 
            // TbName
            // 
            this.TbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbName.Location = new System.Drawing.Point(110, 61);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(118, 20);
            this.TbName.TabIndex = 3;
            this.TbName.TextChanged += new System.EventHandler(this.Value_Changed);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(75, 95);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(156, 95);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmFlags
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(243, 130);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.CbChecked);
            this.Controls.Add(this.CbEnabled);
            this.Controls.Add(this.LbFlag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFlags";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AyrA.Licensing: Flag Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LbFlag;
        private System.Windows.Forms.CheckBox CbEnabled;
        private System.Windows.Forms.CheckBox CbChecked;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}