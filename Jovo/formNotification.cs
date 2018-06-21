using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formNotification : Form
    {
        UtilityHandler utility;
        Timer timeoutTimer;
        bool update;

        public formNotification(string Title, string Text, int Timeout, bool JovoUpdate, UtilityHandler _utility)
        {
            InitializeComponent();

            utility = _utility;
            update = JovoUpdate;

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

            pbImage.Image = (update) ? Properties.Resources.Jovo_Logo1 : Properties.Resources.jovo_loading;
             
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width + 5), Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height + 5));
            pbImage.Location = new Point(13, (this.Size.Height - pbImage.Height) / 2);

            this.Click += doWork_Click;
            lblTitle.Click += doWork_Click;
            lblText.Click += doWork_Click;
            pbImage.Click += doWork_Click;
        }

        private void timeoutTick(object sender, EventArgs e)
        {
            timeoutTimer.Stop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void doWork_Click(object sender, EventArgs e)
        {
            if (update)
            {
                utility.LogEvent("Notification Clicked");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void formNotification_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }
    }
}
