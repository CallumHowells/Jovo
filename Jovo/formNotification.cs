using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formNotification : Form
    {
        Timer timeoutTimer;

        public formNotification(string Title, string Text, int Timeout)
        {
            InitializeComponent();

            if (Timeout != 0)
            {
                timeoutTimer = new Timer();
                timeoutTimer.Interval = Timeout;
                timeoutTimer.Tick += timeoutTick;
                timeoutTimer.Start();
            }

            foreach (string line in Text.Split('\n'))
            {
                lblText.Size = new Size(lblText.Width, lblText.Height + 12);
                this.Size = new Size(this.Width, this.Height + 12);
            }
            lblTitle.Text = Title;
            Text = Text.Replace("\n", Environment.NewLine);
            lblText.Text = Text;

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width + 5), Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height + 5));
            pbImage.Location = new Point(13, (this.Size.Height - pbImage.Height) / 2);

            this.Click += dismiss_Click;
            lblTitle.Click += dismiss_Click;
            lblText.Click += dismiss_Click;
            pbImage.Click += dismiss_Click;
        }

        private void timeoutTick(object sender, EventArgs e)
        {
            timeoutTimer.Stop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dismiss_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void formNotification_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }
    }
}
