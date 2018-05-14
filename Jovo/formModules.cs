using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formModules : Form
    {
        ModuleHandler module;
        UtilityHandler utility;

        public formModules(ModuleHandler _module, UtilityHandler _utility)
        {
            module = _module;
            utility = _utility;
            InitializeComponent();
            GenerateButtons();

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width + 5), Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height + 5));
        }

        private void GenerateButtons()
        {
            string modulePath = module.AppModulePath;
            int icony = 1;
            int y = 1;
            foreach (ModuleData data in module.InstalledModules.OrderBy(m => m.Name))
            {
                PictureBox icon = new PictureBox();
                icon.SizeMode = PictureBoxSizeMode.StretchImage;

                if (File.Exists(data.Path + "\\" + data.Icon))
                {
                    var bytes = File.ReadAllBytes(data.Path + "\\" + data.Icon);
                    var ms = new MemoryStream(bytes);
                    icon.Image = Image.FromStream(ms);
                }
                else
                    icon.Image = Properties.Resources.Jovo_Logo1;

                icon.Location = new Point(1, icony);
                icon.Size = new Size(28, 28);
                pnlButtons.Controls.Add(icon);

                Button button = new Button();
                button.AutoSize = true;
                button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                button.BackColor = Color.White;
                button.FlatAppearance.BorderColor = Color.White;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.MouseOverBackColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

                button.MouseEnter += btn_MouseEnter;
                button.MouseLeave += btn_MouseLeave;
                button.Click += btn_Click;

                button.Location = new Point(60, y);
                button.Name = "btn" + data.Name;
                button.Tag = data;
                button.Size = new Size(220, 30);
                button.Text = data.Text;

                pnlButtons.Controls.Add(button);

                y += 31;
                icony += 31;
            }

            UpdateInfoPanel(module.InstalledModules.Last());
        }

        private void UpdateInfoPanel(ModuleData module)
        {
            lblName.Text = module.Name;
            lblText.Text = module.Text;
            lblInfo.Text = module.Info;
            lblPath.Text = module.Path;
            lblVersion.Text = module.Version;
            lblDate.Text = module.PublishDate;

            if (File.Exists(module.Path + "\\changelog.json"))
                GetChangelog(module);
            else
                rtbChangelog.Text = "No changelog found!";
        }

        private void GetChangelog(ModuleData module)
        {
            rtbChangelog.Text = "Not implemented";
        }

        #region Event Handlers
        private void btnFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            UpdateInfoPanel((ModuleData)btn.Tag);
        }

        private void lblPath_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TextBox path = (TextBox)sender;
                System.Diagnostics.Process.Start(path.Text);
            }
            catch (Exception){}
        }

        private void formModules_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
