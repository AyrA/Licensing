
namespace Demo
{
    partial class FrmMain
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
            this.LblAppId = new System.Windows.Forms.Label();
            this.LblCharset = new System.Windows.Forms.Label();
            this.LblOffset = new System.Windows.Forms.Label();
            this.BtnCopyId = new System.Windows.Forms.Button();
            this.BtnCopyCharset = new System.Windows.Forms.Button();
            this.BtnCopyOffset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbLicense = new System.Windows.Forms.TextBox();
            this.BtnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblAppId
            // 
            this.LblAppId.AutoSize = true;
            this.LblAppId.Location = new System.Drawing.Point(99, 17);
            this.LblAppId.Name = "LblAppId";
            this.LblAppId.Size = new System.Drawing.Size(74, 13);
            this.LblAppId.TabIndex = 1;
            this.LblAppId.Text = "Application Id:";
            // 
            // LblCharset
            // 
            this.LblCharset.AutoSize = true;
            this.LblCharset.Location = new System.Drawing.Point(99, 52);
            this.LblCharset.Name = "LblCharset";
            this.LblCharset.Size = new System.Drawing.Size(46, 13);
            this.LblCharset.TabIndex = 3;
            this.LblCharset.Text = "Charset:";
            // 
            // LblOffset
            // 
            this.LblOffset.AutoSize = true;
            this.LblOffset.Location = new System.Drawing.Point(99, 87);
            this.LblOffset.Name = "LblOffset";
            this.LblOffset.Size = new System.Drawing.Size(78, 13);
            this.LblOffset.TabIndex = 5;
            this.LblOffset.Text = "Offset License:";
            // 
            // BtnCopyId
            // 
            this.BtnCopyId.Location = new System.Drawing.Point(12, 12);
            this.BtnCopyId.Name = "BtnCopyId";
            this.BtnCopyId.Size = new System.Drawing.Size(75, 23);
            this.BtnCopyId.TabIndex = 0;
            this.BtnCopyId.Text = "Copy";
            this.BtnCopyId.UseVisualStyleBackColor = true;
            this.BtnCopyId.Click += new System.EventHandler(this.CopyTag);
            // 
            // BtnCopyCharset
            // 
            this.BtnCopyCharset.Location = new System.Drawing.Point(12, 47);
            this.BtnCopyCharset.Name = "BtnCopyCharset";
            this.BtnCopyCharset.Size = new System.Drawing.Size(75, 23);
            this.BtnCopyCharset.TabIndex = 2;
            this.BtnCopyCharset.Text = "Copy";
            this.BtnCopyCharset.UseVisualStyleBackColor = true;
            this.BtnCopyCharset.Click += new System.EventHandler(this.CopyTag);
            // 
            // BtnCopyOffset
            // 
            this.BtnCopyOffset.Location = new System.Drawing.Point(12, 82);
            this.BtnCopyOffset.Name = "BtnCopyOffset";
            this.BtnCopyOffset.Size = new System.Drawing.Size(75, 23);
            this.BtnCopyOffset.TabIndex = 4;
            this.BtnCopyOffset.Text = "Copy";
            this.BtnCopyOffset.UseVisualStyleBackColor = true;
            this.BtnCopyOffset.Click += new System.EventHandler(this.CopyTag);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "License:";
            // 
            // TbLicense
            // 
            this.TbLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbLicense.Location = new System.Drawing.Point(73, 125);
            this.TbLicense.Name = "TbLicense";
            this.TbLicense.Size = new System.Drawing.Size(209, 20);
            this.TbLicense.TabIndex = 7;
            // 
            // BtnCheck
            // 
            this.BtnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCheck.Location = new System.Drawing.Point(294, 123);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(75, 23);
            this.BtnCheck.TabIndex = 8;
            this.BtnCheck.Text = "Check";
            this.BtnCheck.UseVisualStyleBackColor = true;
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.BtnCheck);
            this.Controls.Add(this.TbLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCopyOffset);
            this.Controls.Add(this.BtnCopyCharset);
            this.Controls.Add(this.BtnCopyId);
            this.Controls.Add(this.LblOffset);
            this.Controls.Add(this.LblCharset);
            this.Controls.Add(this.LblAppId);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "FrmMain";
            this.Text = "Licensing Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblAppId;
        private System.Windows.Forms.Label LblCharset;
        private System.Windows.Forms.Label LblOffset;
        private System.Windows.Forms.Button BtnCopyId;
        private System.Windows.Forms.Button BtnCopyCharset;
        private System.Windows.Forms.Button BtnCopyOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbLicense;
        private System.Windows.Forms.Button BtnCheck;
    }
}

