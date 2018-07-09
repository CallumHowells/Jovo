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
            this.lblViewChangelog = new System.Windows.Forms.Label();
            this.lblToggleActive = new System.Windows.Forms.Label();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.lblPath = new System.Windows.Forms.TextBox();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.lblText2 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.groupBoxRelDate = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBoxVersion = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            this.groupBoxRelDate.SuspendLayout();
            this.groupBoxVersion.SuspendLayout();
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
            this.pnlButtons.Location = new System.Drawing.Point(6, 98);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(235, 502);
            this.pnlButtons.TabIndex = 5;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlMain.Controls.Add(this.lblViewChangelog);
            this.pnlMain.Controls.Add(this.lblToggleActive);
            this.pnlMain.Controls.Add(this.groupBoxPath);
            this.pnlMain.Controls.Add(this.groupBoxName);
            this.pnlMain.Controls.Add(this.lblInfo);
            this.pnlMain.Controls.Add(this.lblText);
            this.pnlMain.Controls.Add(this.groupBoxRelDate);
            this.pnlMain.Controls.Add(this.groupBoxVersion);
            this.pnlMain.Location = new System.Drawing.Point(245, 98);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(355, 503);
            this.pnlMain.TabIndex = 6;
            // 
            // lblViewChangelog
            // 
            this.lblViewChangelog.BackColor = System.Drawing.Color.Transparent;
            this.lblViewChangelog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewChangelog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblViewChangelog.Location = new System.Drawing.Point(192, 258);
            this.lblViewChangelog.Name = "lblViewChangelog";
            this.lblViewChangelog.Size = new System.Drawing.Size(132, 36);
            this.lblViewChangelog.TabIndex = 9;
            this.lblViewChangelog.Text = "View Changelog";
            this.lblViewChangelog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblViewChangelog.Visible = false;
            this.lblViewChangelog.Click += new System.EventHandler(this.btnUtility_Click);
            this.lblViewChangelog.MouseEnter += new System.EventHandler(this.btnUtility_MouseEnter);
            this.lblViewChangelog.MouseLeave += new System.EventHandler(this.btnUtility_MouseLeave);
            // 
            // lblToggleActive
            // 
            this.lblToggleActive.BackColor = System.Drawing.Color.Transparent;
            this.lblToggleActive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToggleActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblToggleActive.Location = new System.Drawing.Point(192, 294);
            this.lblToggleActive.Name = "lblToggleActive";
            this.lblToggleActive.Size = new System.Drawing.Size(132, 36);
            this.lblToggleActive.TabIndex = 7;
            this.lblToggleActive.Text = "Toggle Active";
            this.lblToggleActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblToggleActive.Click += new System.EventHandler(this.btnUtility_Click);
            this.lblToggleActive.MouseEnter += new System.EventHandler(this.btnUtility_MouseEnter);
            this.lblToggleActive.MouseLeave += new System.EventHandler(this.btnUtility_MouseLeave);
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.lblPath);
            this.groupBoxPath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBoxPath.Location = new System.Drawing.Point(5, 455);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(344, 43);
            this.groupBoxPath.TabIndex = 2;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Path";
            // 
            // lblPath
            // 
            this.lblPath.BackColor = System.Drawing.SystemColors.Window;
            this.lblPath.Location = new System.Drawing.Point(5, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.ReadOnly = true;
            this.lblPath.Size = new System.Drawing.Size(334, 22);
            this.lblPath.TabIndex = 0;
            this.lblPath.DoubleClick += new System.EventHandler(this.lblPath_DoubleClick);
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.lblText2);
            this.groupBoxName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBoxName.Location = new System.Drawing.Point(173, 332);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Size = new System.Drawing.Size(176, 35);
            this.groupBoxName.TabIndex = 3;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // lblText2
            // 
            this.lblText2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText2.Location = new System.Drawing.Point(6, 15);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(164, 13);
            this.lblText2.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.lblInfo.Location = new System.Drawing.Point(4, 33);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(164, 310);
            this.lblInfo.TabIndex = 7;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.lblText.Location = new System.Drawing.Point(1, 4);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(342, 29);
            this.lblText.TabIndex = 8;
            // 
            // groupBoxRelDate
            // 
            this.groupBoxRelDate.Controls.Add(this.lblDate);
            this.groupBoxRelDate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxRelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBoxRelDate.Location = new System.Drawing.Point(173, 414);
            this.groupBoxRelDate.Name = "groupBoxRelDate";
            this.groupBoxRelDate.Size = new System.Drawing.Size(176, 35);
            this.groupBoxRelDate.TabIndex = 4;
            this.groupBoxRelDate.TabStop = false;
            this.groupBoxRelDate.Text = "Release Date";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(6, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(164, 13);
            this.lblDate.TabIndex = 0;
            // 
            // groupBoxVersion
            // 
            this.groupBoxVersion.Controls.Add(this.lblVersion);
            this.groupBoxVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.groupBoxVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.groupBoxVersion.Location = new System.Drawing.Point(173, 373);
            this.groupBoxVersion.Name = "groupBoxVersion";
            this.groupBoxVersion.Size = new System.Drawing.Size(176, 35);
            this.groupBoxVersion.TabIndex = 3;
            this.groupBoxVersion.TabStop = false;
            this.groupBoxVersion.Text = "Version";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(6, 15);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(164, 13);
            this.lblVersion.TabIndex = 0;
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.pnlLine.Location = new System.Drawing.Point(0, 97);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(600, 1);
            this.pnlLine.TabIndex = 6;
            // 
            // formModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pnlLine);
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
            this.Activated += new System.EventHandler(this.formModules_Activated);
            this.Deactivate += new System.EventHandler(this.formModules_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxRelDate.ResumeLayout(false);
            this.groupBoxVersion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFormClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.GroupBox groupBoxVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.TextBox lblPath;
        private System.Windows.Forms.GroupBox groupBoxRelDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.Label lblToggleActive;
        private System.Windows.Forms.Label lblViewChangelog;
    }
}