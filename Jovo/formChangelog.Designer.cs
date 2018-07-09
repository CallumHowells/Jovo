namespace Jovo
{
    partial class formChangelog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formChangelog));
            this.pnlChangelog = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.btnFormClose = new System.Windows.Forms.Button();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.pnlError = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChangelog
            // 
            this.pnlChangelog.AutoScroll = true;
            this.pnlChangelog.BackColor = System.Drawing.Color.White;
            this.pnlChangelog.Location = new System.Drawing.Point(5, 194);
            this.pnlChangelog.Name = "pnlChangelog";
            this.pnlChangelog.Size = new System.Drawing.Size(595, 400);
            this.pnlChangelog.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Jovo.Properties.Resources.Jovo_Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(95)))), ((int)(((byte)(197)))));
            this.lblMainTitle.Location = new System.Drawing.Point(47, 12);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(521, 46);
            this.lblMainTitle.TabIndex = 11;
            this.lblMainTitle.Text = "Changelog";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.pnlLine.Location = new System.Drawing.Point(0, 97);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(600, 1);
            this.pnlLine.TabIndex = 13;
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
            this.btnFormClose.TabIndex = 9;
            this.btnFormClose.Text = "X";
            this.btnFormClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormClose.UseVisualStyleBackColor = true;
            this.btnFormClose.Click += new System.EventHandler(this.btnFormClose_Click);
            // 
            // pnlVersion
            // 
            this.pnlVersion.AutoScroll = true;
            this.pnlVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlVersion.Location = new System.Drawing.Point(0, 98);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Size = new System.Drawing.Size(600, 93);
            this.pnlVersion.TabIndex = 16;
            // 
            // pnlError
            // 
            this.pnlError.Controls.Add(this.label2);
            this.pnlError.Controls.Add(this.pictureBox2);
            this.pnlError.Location = new System.Drawing.Point(200, 303);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(192, 121);
            this.pnlError.TabIndex = 17;
            this.pnlError.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Changelog Syntax Error";
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
            // formChangelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlChangelog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.btnFormClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formChangelog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formChangelog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChangelog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Button btnFormClose;
        private System.Windows.Forms.Panel pnlVersion;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}