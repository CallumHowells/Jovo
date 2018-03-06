namespace Jovo
{
    partial class formSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSettings));
            this.btnFormClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblModuleChangelog = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblModulePath = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblModulePublishDate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblModuleVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.lblModuleText = new System.Windows.Forms.Label();
            this.lblModuleInfo = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlNoSettings = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlSaveSuccess = new System.Windows.Forms.Panel();
            this.lblSaveSuccess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlNoSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSaveSuccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFormClose
            // 
            this.btnFormClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFormClose.FlatAppearance.BorderSize = 0;
            this.btnFormClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFormClose.Location = new System.Drawing.Point(574, 0);
            this.btnFormClose.Name = "btnFormClose";
            this.btnFormClose.Size = new System.Drawing.Size(26, 28);
            this.btnFormClose.TabIndex = 0;
            this.btnFormClose.Text = "X";
            this.btnFormClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormClose.UseVisualStyleBackColor = true;
            this.btnFormClose.Click += new System.EventHandler(this.btnFormClose_Click);
            this.btnFormClose.MouseEnter += new System.EventHandler(this.btnFormClose_MouseEnter);
            this.btnFormClose.MouseLeave += new System.EventHandler(this.btnFormClose_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Jovo.Properties.Resources.Jovo_Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.label1.Location = new System.Drawing.Point(47, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Settings.";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.pnlLine.Location = new System.Drawing.Point(0, 97);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(600, 1);
            this.pnlLine.TabIndex = 3;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlInfo.Controls.Add(this.lblModuleChangelog);
            this.pnlInfo.Controls.Add(this.groupBox4);
            this.pnlInfo.Controls.Add(this.groupBox3);
            this.pnlInfo.Controls.Add(this.groupBox2);
            this.pnlInfo.Controls.Add(this.groupBox1);
            this.pnlInfo.Controls.Add(this.lblModuleText);
            this.pnlInfo.Controls.Add(this.lblModuleInfo);
            this.pnlInfo.Location = new System.Drawing.Point(418, 98);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(182, 503);
            this.pnlInfo.TabIndex = 4;
            // 
            // lblModuleChangelog
            // 
            this.lblModuleChangelog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblModuleChangelog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblModuleChangelog.Location = new System.Drawing.Point(3, 308);
            this.lblModuleChangelog.Name = "lblModuleChangelog";
            this.lblModuleChangelog.Size = new System.Drawing.Size(176, 31);
            this.lblModuleChangelog.TabIndex = 6;
            this.lblModuleChangelog.Text = "View Changelog";
            this.lblModuleChangelog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblModuleChangelog.Click += new System.EventHandler(this.lblModuleChangelog_Click);
            this.lblModuleChangelog.MouseEnter += new System.EventHandler(this.lblModuleChangelog_MouseEnter);
            this.lblModuleChangelog.MouseLeave += new System.EventHandler(this.lblModuleChangelog_MouseLeave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblModulePath);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBox4.Location = new System.Drawing.Point(3, 465);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 35);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Path";
            // 
            // lblModulePath
            // 
            this.lblModulePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblModulePath.Location = new System.Drawing.Point(6, 15);
            this.lblModulePath.Name = "lblModulePath";
            this.lblModulePath.Size = new System.Drawing.Size(164, 13);
            this.lblModulePath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblModulePublishDate);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBox3.Location = new System.Drawing.Point(3, 424);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 35);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Publish Date";
            // 
            // lblModulePublishDate
            // 
            this.lblModulePublishDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblModulePublishDate.Location = new System.Drawing.Point(6, 15);
            this.lblModulePublishDate.Name = "lblModulePublishDate";
            this.lblModulePublishDate.Size = new System.Drawing.Size(164, 13);
            this.lblModulePublishDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblModuleVersion);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBox2.Location = new System.Drawing.Point(3, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 35);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Version";
            // 
            // lblModuleVersion
            // 
            this.lblModuleVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblModuleVersion.Location = new System.Drawing.Point(6, 15);
            this.lblModuleVersion.Name = "lblModuleVersion";
            this.lblModuleVersion.Size = new System.Drawing.Size(164, 13);
            this.lblModuleVersion.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblModuleName);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 35);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Name";
            // 
            // lblModuleName
            // 
            this.lblModuleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblModuleName.Location = new System.Drawing.Point(6, 15);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(164, 13);
            this.lblModuleName.TabIndex = 0;
            // 
            // lblModuleText
            // 
            this.lblModuleText.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblModuleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.lblModuleText.Location = new System.Drawing.Point(3, 4);
            this.lblModuleText.Name = "lblModuleText";
            this.lblModuleText.Size = new System.Drawing.Size(176, 29);
            this.lblModuleText.TabIndex = 1;
            // 
            // lblModuleInfo
            // 
            this.lblModuleInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblModuleInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.lblModuleInfo.Location = new System.Drawing.Point(3, 36);
            this.lblModuleInfo.Name = "lblModuleInfo";
            this.lblModuleInfo.Size = new System.Drawing.Size(176, 272);
            this.lblModuleInfo.TabIndex = 0;
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoScroll = true;
            this.pnlSettings.BackColor = System.Drawing.Color.White;
            this.pnlSettings.Location = new System.Drawing.Point(12, 125);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(400, 432);
            this.pnlSettings.TabIndex = 5;
            // 
            // pnlNoSettings
            // 
            this.pnlNoSettings.Controls.Add(this.label3);
            this.pnlNoSettings.Controls.Add(this.label2);
            this.pnlNoSettings.Controls.Add(this.pictureBox2);
            this.pnlNoSettings.Location = new System.Drawing.Point(108, 227);
            this.pnlNoSettings.Name = "pnlNoSettings";
            this.pnlNoSettings.Size = new System.Drawing.Size(192, 198);
            this.pnlNoSettings.TabIndex = 8;
            this.pnlNoSettings.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 71);
            this.label3.TabIndex = 2;
            this.label3.Text = "This Module doesn\'t contain any configurable settings.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Oh no!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Jovo.Properties.Resources.if_smiley__8_2290989;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pnlSaveSuccess
            // 
            this.pnlSaveSuccess.Controls.Add(this.lblSaveSuccess);
            this.pnlSaveSuccess.Location = new System.Drawing.Point(12, 100);
            this.pnlSaveSuccess.Name = "pnlSaveSuccess";
            this.pnlSaveSuccess.Size = new System.Drawing.Size(400, 24);
            this.pnlSaveSuccess.TabIndex = 3;
            // 
            // lblSaveSuccess
            // 
            this.lblSaveSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(152)))), ((int)(((byte)(117)))));
            this.lblSaveSuccess.Location = new System.Drawing.Point(4, 5);
            this.lblSaveSuccess.Name = "lblSaveSuccess";
            this.lblSaveSuccess.Size = new System.Drawing.Size(393, 13);
            this.lblSaveSuccess.TabIndex = 0;
            this.lblSaveSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pnlSaveSuccess);
            this.Controls.Add(this.pnlNoSettings);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormClose);
            this.Controls.Add(this.pnlLine);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Deactivate += new System.EventHandler(this.formSettings_Deactivate);
            this.Load += new System.EventHandler(this.formSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlNoSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSaveSuccess.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFormClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblModulePath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblModulePublishDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblModuleVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Label lblModuleText;
        private System.Windows.Forms.Label lblModuleInfo;
        private System.Windows.Forms.Label lblModuleChangelog;
        private System.Windows.Forms.Panel pnlNoSettings;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSaveSuccess;
        private System.Windows.Forms.Label lblSaveSuccess;
    }
}