
namespace Keygen
{
    partial class FrmKeygen
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
            this.TbAppId = new System.Windows.Forms.TextBox();
            this.TbAlphabet = new System.Windows.Forms.TextBox();
            this.BtnSetAppId = new System.Windows.Forms.Button();
            this.BtnSetAlpha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GbBasicSettings = new System.Windows.Forms.GroupBox();
            this.BtnLoadConfig = new System.Windows.Forms.Button();
            this.BtnSaveConfig = new System.Windows.Forms.Button();
            this.BtnRandomize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TbOffsetLicense = new System.Windows.Forms.TextBox();
            this.BtnSetOffset = new System.Windows.Forms.Button();
            this.GbLicense = new System.Windows.Forms.GroupBox();
            this.BtnSetFlags = new System.Windows.Forms.Button();
            this.PanelFlags = new System.Windows.Forms.TableLayoutPanel();
            this.CbProp5 = new System.Windows.Forms.CheckBox();
            this.CbProp1 = new System.Windows.Forms.CheckBox();
            this.CbProp2 = new System.Windows.Forms.CheckBox();
            this.CbProp3 = new System.Windows.Forms.CheckBox();
            this.CbProp4 = new System.Windows.Forms.CheckBox();
            this.TbKey = new System.Windows.Forms.TextBox();
            this.BtnExp1Y = new System.Windows.Forms.Button();
            this.CbExpNever = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbLicCount = new System.Windows.Forms.NumericUpDown();
            this.TbExpDate = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.GbParse = new System.Windows.Forms.GroupBox();
            this.TbParseKey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnParseKey = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.GbBasicSettings.SuspendLayout();
            this.GbLicense.SuspendLayout();
            this.PanelFlags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbLicCount)).BeginInit();
            this.GbParse.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbAppId
            // 
            this.TbAppId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbAppId.Location = new System.Drawing.Point(109, 22);
            this.TbAppId.Name = "TbAppId";
            this.TbAppId.Size = new System.Drawing.Size(294, 20);
            this.TbAppId.TabIndex = 1;
            // 
            // TbAlphabet
            // 
            this.TbAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbAlphabet.Location = new System.Drawing.Point(109, 51);
            this.TbAlphabet.Name = "TbAlphabet";
            this.TbAlphabet.Size = new System.Drawing.Size(294, 20);
            this.TbAlphabet.TabIndex = 4;
            // 
            // BtnSetAppId
            // 
            this.BtnSetAppId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSetAppId.Location = new System.Drawing.Point(409, 19);
            this.BtnSetAppId.Name = "BtnSetAppId";
            this.BtnSetAppId.Size = new System.Drawing.Size(75, 23);
            this.BtnSetAppId.TabIndex = 2;
            this.BtnSetAppId.Text = "Set";
            this.BtnSetAppId.UseVisualStyleBackColor = true;
            this.BtnSetAppId.Click += new System.EventHandler(this.BtnSetAppId_Click);
            // 
            // BtnSetAlpha
            // 
            this.BtnSetAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSetAlpha.Location = new System.Drawing.Point(409, 48);
            this.BtnSetAlpha.Name = "BtnSetAlpha";
            this.BtnSetAlpha.Size = new System.Drawing.Size(75, 23);
            this.BtnSetAlpha.TabIndex = 5;
            this.BtnSetAlpha.Text = "Set";
            this.BtnSetAlpha.UseVisualStyleBackColor = true;
            this.BtnSetAlpha.Click += new System.EventHandler(this.BtnSetAlpha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alphabet";
            // 
            // GbBasicSettings
            // 
            this.GbBasicSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbBasicSettings.Controls.Add(this.BtnLoadConfig);
            this.GbBasicSettings.Controls.Add(this.BtnSaveConfig);
            this.GbBasicSettings.Controls.Add(this.BtnRandomize);
            this.GbBasicSettings.Controls.Add(this.label1);
            this.GbBasicSettings.Controls.Add(this.label5);
            this.GbBasicSettings.Controls.Add(this.label2);
            this.GbBasicSettings.Controls.Add(this.TbAppId);
            this.GbBasicSettings.Controls.Add(this.TbOffsetLicense);
            this.GbBasicSettings.Controls.Add(this.TbAlphabet);
            this.GbBasicSettings.Controls.Add(this.BtnSetOffset);
            this.GbBasicSettings.Controls.Add(this.BtnSetAlpha);
            this.GbBasicSettings.Controls.Add(this.BtnSetAppId);
            this.GbBasicSettings.Location = new System.Drawing.Point(12, 12);
            this.GbBasicSettings.Name = "GbBasicSettings";
            this.GbBasicSettings.Size = new System.Drawing.Size(502, 142);
            this.GbBasicSettings.TabIndex = 0;
            this.GbBasicSettings.TabStop = false;
            this.GbBasicSettings.Text = "Basic Settings";
            // 
            // BtnLoadConfig
            // 
            this.BtnLoadConfig.Location = new System.Drawing.Point(313, 106);
            this.BtnLoadConfig.Name = "BtnLoadConfig";
            this.BtnLoadConfig.Size = new System.Drawing.Size(90, 23);
            this.BtnLoadConfig.TabIndex = 11;
            this.BtnLoadConfig.Text = "Load";
            this.BtnLoadConfig.UseVisualStyleBackColor = true;
            this.BtnLoadConfig.Click += new System.EventHandler(this.BtnLoadConfig_Click);
            // 
            // BtnSaveConfig
            // 
            this.BtnSaveConfig.Location = new System.Drawing.Point(211, 106);
            this.BtnSaveConfig.Name = "BtnSaveConfig";
            this.BtnSaveConfig.Size = new System.Drawing.Size(90, 23);
            this.BtnSaveConfig.TabIndex = 10;
            this.BtnSaveConfig.Text = "Save";
            this.BtnSaveConfig.UseVisualStyleBackColor = true;
            this.BtnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // BtnRandomize
            // 
            this.BtnRandomize.Location = new System.Drawing.Point(109, 106);
            this.BtnRandomize.Name = "BtnRandomize";
            this.BtnRandomize.Size = new System.Drawing.Size(90, 23);
            this.BtnRandomize.TabIndex = 9;
            this.BtnRandomize.Text = "New App";
            this.BtnRandomize.UseVisualStyleBackColor = true;
            this.BtnRandomize.Click += new System.EventHandler(this.BtnRandomize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Offset License";
            // 
            // TbOffsetLicense
            // 
            this.TbOffsetLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbOffsetLicense.Location = new System.Drawing.Point(109, 80);
            this.TbOffsetLicense.Name = "TbOffsetLicense";
            this.TbOffsetLicense.Size = new System.Drawing.Size(294, 20);
            this.TbOffsetLicense.TabIndex = 7;
            // 
            // BtnSetOffset
            // 
            this.BtnSetOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSetOffset.Location = new System.Drawing.Point(409, 77);
            this.BtnSetOffset.Name = "BtnSetOffset";
            this.BtnSetOffset.Size = new System.Drawing.Size(75, 23);
            this.BtnSetOffset.TabIndex = 8;
            this.BtnSetOffset.Text = "Set";
            this.BtnSetOffset.UseVisualStyleBackColor = true;
            this.BtnSetOffset.Click += new System.EventHandler(this.BtnSetOffset_Click);
            // 
            // GbLicense
            // 
            this.GbLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbLicense.Controls.Add(this.BtnSetFlags);
            this.GbLicense.Controls.Add(this.PanelFlags);
            this.GbLicense.Controls.Add(this.TbKey);
            this.GbLicense.Controls.Add(this.BtnExp1Y);
            this.GbLicense.Controls.Add(this.CbExpNever);
            this.GbLicense.Controls.Add(this.label3);
            this.GbLicense.Controls.Add(this.label7);
            this.GbLicense.Controls.Add(this.label6);
            this.GbLicense.Controls.Add(this.label4);
            this.GbLicense.Controls.Add(this.TbLicCount);
            this.GbLicense.Controls.Add(this.TbExpDate);
            this.GbLicense.Controls.Add(this.BtnGenerate);
            this.GbLicense.Location = new System.Drawing.Point(12, 160);
            this.GbLicense.Name = "GbLicense";
            this.GbLicense.Size = new System.Drawing.Size(502, 140);
            this.GbLicense.TabIndex = 1;
            this.GbLicense.TabStop = false;
            this.GbLicense.Text = "Key Generator";
            // 
            // BtnSetFlags
            // 
            this.BtnSetFlags.Location = new System.Drawing.Point(49, 76);
            this.BtnSetFlags.Name = "BtnSetFlags";
            this.BtnSetFlags.Size = new System.Drawing.Size(43, 23);
            this.BtnSetFlags.TabIndex = 8;
            this.BtnSetFlags.Text = "Edit";
            this.BtnSetFlags.UseVisualStyleBackColor = true;
            this.BtnSetFlags.Click += new System.EventHandler(this.BtnSetFlags_Click);
            // 
            // PanelFlags
            // 
            this.PanelFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelFlags.ColumnCount = 5;
            this.PanelFlags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelFlags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelFlags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelFlags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelFlags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelFlags.Controls.Add(this.CbProp5, 4, 0);
            this.PanelFlags.Controls.Add(this.CbProp1, 0, 0);
            this.PanelFlags.Controls.Add(this.CbProp2, 1, 0);
            this.PanelFlags.Controls.Add(this.CbProp3, 2, 0);
            this.PanelFlags.Controls.Add(this.CbProp4, 3, 0);
            this.PanelFlags.Location = new System.Drawing.Point(109, 75);
            this.PanelFlags.Name = "PanelFlags";
            this.PanelFlags.RowCount = 1;
            this.PanelFlags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelFlags.Size = new System.Drawing.Size(375, 27);
            this.PanelFlags.TabIndex = 9;
            // 
            // CbProp5
            // 
            this.CbProp5.AutoEllipsis = true;
            this.CbProp5.Dock = System.Windows.Forms.DockStyle.Top;
            this.CbProp5.Location = new System.Drawing.Point(303, 3);
            this.CbProp5.Name = "CbProp5";
            this.CbProp5.Size = new System.Drawing.Size(69, 17);
            this.CbProp5.TabIndex = 4;
            this.CbProp5.Text = "Flag 5";
            this.CbProp5.UseVisualStyleBackColor = true;
            // 
            // CbProp1
            // 
            this.CbProp1.AutoEllipsis = true;
            this.CbProp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.CbProp1.Location = new System.Drawing.Point(3, 3);
            this.CbProp1.Name = "CbProp1";
            this.CbProp1.Size = new System.Drawing.Size(69, 17);
            this.CbProp1.TabIndex = 0;
            this.CbProp1.Text = "Flag 1";
            this.CbProp1.UseVisualStyleBackColor = true;
            // 
            // CbProp2
            // 
            this.CbProp2.AutoEllipsis = true;
            this.CbProp2.Dock = System.Windows.Forms.DockStyle.Top;
            this.CbProp2.Location = new System.Drawing.Point(78, 3);
            this.CbProp2.Name = "CbProp2";
            this.CbProp2.Size = new System.Drawing.Size(69, 17);
            this.CbProp2.TabIndex = 1;
            this.CbProp2.Text = "Flag 2";
            this.CbProp2.UseVisualStyleBackColor = true;
            // 
            // CbProp3
            // 
            this.CbProp3.AutoEllipsis = true;
            this.CbProp3.Dock = System.Windows.Forms.DockStyle.Top;
            this.CbProp3.Location = new System.Drawing.Point(153, 3);
            this.CbProp3.Name = "CbProp3";
            this.CbProp3.Size = new System.Drawing.Size(69, 17);
            this.CbProp3.TabIndex = 2;
            this.CbProp3.Text = "Flag 3";
            this.CbProp3.UseVisualStyleBackColor = true;
            // 
            // CbProp4
            // 
            this.CbProp4.AutoEllipsis = true;
            this.CbProp4.Dock = System.Windows.Forms.DockStyle.Top;
            this.CbProp4.Location = new System.Drawing.Point(228, 3);
            this.CbProp4.Name = "CbProp4";
            this.CbProp4.Size = new System.Drawing.Size(69, 17);
            this.CbProp4.TabIndex = 3;
            this.CbProp4.Text = "Flag 4";
            this.CbProp4.UseVisualStyleBackColor = true;
            // 
            // TbKey
            // 
            this.TbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbKey.Location = new System.Drawing.Point(109, 108);
            this.TbKey.Name = "TbKey";
            this.TbKey.ReadOnly = true;
            this.TbKey.Size = new System.Drawing.Size(375, 20);
            this.TbKey.TabIndex = 11;
            // 
            // BtnExp1Y
            // 
            this.BtnExp1Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExp1Y.Location = new System.Drawing.Point(409, 17);
            this.BtnExp1Y.Name = "BtnExp1Y";
            this.BtnExp1Y.Size = new System.Drawing.Size(75, 23);
            this.BtnExp1Y.TabIndex = 3;
            this.BtnExp1Y.Text = "1 Year";
            this.BtnExp1Y.UseVisualStyleBackColor = true;
            this.BtnExp1Y.Click += new System.EventHandler(this.BtnExp1Y_Click);
            // 
            // CbExpNever
            // 
            this.CbExpNever.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbExpNever.AutoSize = true;
            this.CbExpNever.Location = new System.Drawing.Point(323, 21);
            this.CbExpNever.Name = "CbExpNever";
            this.CbExpNever.Size = new System.Drawing.Size(55, 17);
            this.CbExpNever.TabIndex = 2;
            this.CbExpNever.Text = "Never";
            this.CbExpNever.UseVisualStyleBackColor = true;
            this.CbExpNever.CheckedChanged += new System.EventHandler(this.CbExpNever_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Expiration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "License Key";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Flags";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "# Licenses";
            // 
            // TbLicCount
            // 
            this.TbLicCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbLicCount.Location = new System.Drawing.Point(109, 49);
            this.TbLicCount.Name = "TbLicCount";
            this.TbLicCount.Size = new System.Drawing.Size(120, 20);
            this.TbLicCount.TabIndex = 5;
            this.TbLicCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TbExpDate
            // 
            this.TbExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbExpDate.CustomFormat = "yyyy-MM-dd";
            this.TbExpDate.Location = new System.Drawing.Point(109, 20);
            this.TbExpDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.TbExpDate.Name = "TbExpDate";
            this.TbExpDate.Size = new System.Drawing.Size(200, 20);
            this.TbExpDate.TabIndex = 1;
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenerate.Location = new System.Drawing.Point(409, 46);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerate.TabIndex = 6;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // GbParse
            // 
            this.GbParse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbParse.Controls.Add(this.TbParseKey);
            this.GbParse.Controls.Add(this.label8);
            this.GbParse.Controls.Add(this.BtnParseKey);
            this.GbParse.Location = new System.Drawing.Point(12, 306);
            this.GbParse.Name = "GbParse";
            this.GbParse.Size = new System.Drawing.Size(502, 61);
            this.GbParse.TabIndex = 2;
            this.GbParse.TabStop = false;
            this.GbParse.Text = "Key Decoder";
            // 
            // TbParseKey
            // 
            this.TbParseKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbParseKey.Location = new System.Drawing.Point(109, 21);
            this.TbParseKey.Name = "TbParseKey";
            this.TbParseKey.Size = new System.Drawing.Size(294, 20);
            this.TbParseKey.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "License Key";
            // 
            // BtnParseKey
            // 
            this.BtnParseKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnParseKey.Location = new System.Drawing.Point(409, 19);
            this.BtnParseKey.Name = "BtnParseKey";
            this.BtnParseKey.Size = new System.Drawing.Size(75, 23);
            this.BtnParseKey.TabIndex = 2;
            this.BtnParseKey.Text = "Parse";
            this.BtnParseKey.UseVisualStyleBackColor = true;
            this.BtnParseKey.Click += new System.EventHandler(this.BtnParseKey_Click);
            // 
            // OFD
            // 
            this.OFD.DefaultExt = "keyconfig";
            this.OFD.Filter = "Key configuration files|*.keyconfig";
            this.OFD.Title = "Open existing configuration";
            // 
            // SFD
            // 
            this.SFD.Title = "Save current configuration";
            // 
            // FrmKeygen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 391);
            this.Controls.Add(this.GbParse);
            this.Controls.Add(this.GbLicense);
            this.Controls.Add(this.GbBasicSettings);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(550, 430);
            this.Name = "FrmKeygen";
            this.Text = "AyrA.Licensing: Key Generator";
            this.GbBasicSettings.ResumeLayout(false);
            this.GbBasicSettings.PerformLayout();
            this.GbLicense.ResumeLayout(false);
            this.GbLicense.PerformLayout();
            this.PanelFlags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TbLicCount)).EndInit();
            this.GbParse.ResumeLayout(false);
            this.GbParse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TbAppId;
        private System.Windows.Forms.TextBox TbAlphabet;
        private System.Windows.Forms.Button BtnSetAppId;
        private System.Windows.Forms.Button BtnSetAlpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GbBasicSettings;
        private System.Windows.Forms.GroupBox GbLicense;
        private System.Windows.Forms.CheckBox CbExpNever;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown TbLicCount;
        private System.Windows.Forms.DateTimePicker TbExpDate;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Button BtnExp1Y;
        private System.Windows.Forms.TextBox TbKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbOffsetLicense;
        private System.Windows.Forms.Button BtnSetOffset;
        private System.Windows.Forms.CheckBox CbProp5;
        private System.Windows.Forms.CheckBox CbProp4;
        private System.Windows.Forms.CheckBox CbProp3;
        private System.Windows.Forms.CheckBox CbProp2;
        private System.Windows.Forms.CheckBox CbProp1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox GbParse;
        private System.Windows.Forms.TextBox TbParseKey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnParseKey;
        private System.Windows.Forms.Button BtnRandomize;
        private System.Windows.Forms.Button BtnLoadConfig;
        private System.Windows.Forms.Button BtnSaveConfig;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.TableLayoutPanel PanelFlags;
        private System.Windows.Forms.Button BtnSetFlags;
    }
}

