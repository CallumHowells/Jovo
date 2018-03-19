namespace Jovo
{
    partial class formModules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formModules));
            this.btnFormClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.rtbChangelog = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBoxVersion = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.lblPath = new System.Windows.Forms.TextBox();
            this.groupBoxText = new System.Windows.Forms.GroupBox();
            this.lblText = new System.Windows.Forms.Label();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxVersion.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxText.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFormClose
            // 
            this.btnFormClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFormClose.FlatAppearance.BorderSize = 0;
            this.btnFormClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFormClose.Location = new System.Drawing.Point(557, 1);
            this.btnFormClose.Name = "btnFormClose";
            this.btnFormClose.Size = new System.Drawing.Size(26, 28);
            this.btnFormClose.TabIndex = 1;
            this.btnFormClose.Text = "X";
            this.btnFormClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormClose.UseVisualStyleBackColor = true;
            this.btnFormClose.Click += new System.EventHandler(this.btnFormClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Jovo.Properties.Resources.Jovo_Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.label1.Location = new System.Drawing.Point(47, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Modules";
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoScroll = true;
            this.pnlButtons.Location = new System.Drawing.Point(4, 83);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(235, 505);
            this.pnlButtons.TabIndex = 5;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.rtbChangelog);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.groupBoxInfo);
            this.pnlMain.Controls.Add(this.groupBoxVersion);
            this.pnlMain.Controls.Add(this.groupBoxPath);
            this.pnlMain.Controls.Add(this.groupBoxText);
            this.pnlMain.Controls.Add(this.groupBoxName);
            this.pnlMain.Location = new System.Drawing.Point(245, 83);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(350, 505);
            this.pnlMain.TabIndex = 6;
            // 
            // rtbChangelog
            // 
            this.rtbChangelog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbChangelog.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rtbChangelog.Location = new System.Drawing.Point(10, 389);
            this.rtbChangelog.Name = "rtbChangelog";
            this.rtbChangelog.Size = new System.Drawing.Size(333, 96);
            this.rtbChangelog.TabIndex = 5;
            this.rtbChangelog.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(10, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Release Date";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(18, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(300, 13);
            this.lblDate.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.lblInfo);
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxInfo.Location = new System.Drawing.Point(10, 114);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(333, 100);
            this.groupBoxInfo.TabIndex = 2;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(18, 23);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(300, 60);
            this.lblInfo.TabIndex = 0;
            // 
            // groupBoxVersion
            // 
            this.groupBoxVersion.Controls.Add(this.lblVersion);
            this.groupBoxVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxVersion.Location = new System.Drawing.Point(10, 276);
            this.groupBoxVersion.Name = "groupBoxVersion";
            this.groupBoxVersion.Size = new System.Drawing.Size(333, 50);
            this.groupBoxVersion.TabIndex = 3;
            this.groupBoxVersion.TabStop = false;
            this.groupBoxVersion.Text = "Version";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(18, 23);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(300, 13);
            this.lblVersion.TabIndex = 0;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.lblPath);
            this.groupBoxPath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxPath.Location = new System.Drawing.Point(10, 220);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(333, 50);
            this.groupBoxPath.TabIndex = 2;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Path";
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(6, 19);
            this.lblPath.Name = "lblPath";
            this.lblPath.ReadOnly = true;
            this.lblPath.Size = new System.Drawing.Size(322, 22);
            this.lblPath.TabIndex = 0;
            this.lblPath.DoubleClick += new System.EventHandler(this.lblPath_DoubleClick);
            // 
            // groupBoxText
            // 
            this.groupBoxText.Controls.Add(this.lblText);
            this.groupBoxText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxText.Location = new System.Drawing.Point(10, 58);
            this.groupBoxText.Name = "groupBoxText";
            this.groupBoxText.Size = new System.Drawing.Size(333, 50);
            this.groupBoxText.TabIndex = 1;
            this.groupBoxText.TabStop = false;
            this.groupBoxText.Text = "Text";
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(18, 23);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(300, 13);
            this.lblText.TabIndex = 0;
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.lblName);
            this.groupBoxName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxName.Location = new System.Drawing.Point(10, 2);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Size = new System.Drawing.Size(333, 50);
            this.groupBoxName.TabIndex = 0;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(18, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(300, 13);
            this.lblName.TabIndex = 0;
            // 
            // formModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formModules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Installed Modules";
            this.Deactivate += new System.EventHandler(this.formModules_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxVersion.ResumeLayout(false);
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxText.ResumeLayout(false);
            this.groupBoxName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFormClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBoxText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.GroupBox groupBoxVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox lblPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.RichTextBox rtbChangelog;
    }
}