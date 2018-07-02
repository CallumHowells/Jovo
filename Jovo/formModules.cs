using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        ButtonFilter currentFilter;
        enum ButtonFilter { All, Installed, NotInstalled };

        public formModules(ModuleHandler _module, UtilityHandler _utility)
        {
            module = _module;
            utility = _utility;
            InitializeComponent();

            currentFilter = ButtonFilter.All;

            GenerateButtons(currentFilter);
            GenerateHeaders();

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width + 5), Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height + 5));
        }

        private void GenerateHeaders()
        {
            string[] headers = { "All Modules", "Installed Modules", "Available Modules" };

            //FillInfoPanel(null);
            //GenerateSettingPanel(null);

            int x = 5;
            bool first = true;
            foreach (string headerText in headers)
            {
                Label header = new Label();
                header.Name = "lbl" + headerText.Replace(" ", String.Empty);
                header.Text = headerText;
                header.AutoSize = true;
                header.ForeColor = Color.FromArgb(30, 30, 30);
                header.BackColor = Color.Transparent;
                header.MouseEnter += label_MouseEnter;
                header.MouseLeave += label_MouseLeave;
                header.Click += label_Click;
                header.Tag = headerText.Replace(" ", String.Empty);
                header.TextAlign = ContentAlignment.MiddleLeft;
                //header.Size = new Size(100, 25);
                header.Location = new Point(x, 70);
                header.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                this.Controls.Add(header);

                Panel under = new Panel();
                under.Name = "pnlHead" + headerText.Replace(" ", String.Empty);
                under.Size = new Size(header.Size.Width, 3);
                under.Location = new Point(x, 95);
                under.BackColor = Color.FromArgb(51, 153, 255);
                under.Visible = first;
                this.Controls.Add(under);
                x += header.Size.Width + 5;
                first = false;
            }
        }

        private void GenerateButtons(ButtonFilter filter)
        {
            pnlButtons.Controls.Clear();

            List<ModuleData> filtered = new List<ModuleData>();
            switch (filter)
            {
                case ButtonFilter.All:
                    filtered = module.InstalledModules.OrderBy(m => m.Name).ToList();
                    break;

                case ButtonFilter.Installed:
                    filtered = module.InstalledModules.Where(m => m.IsActive == true).OrderBy(m => m.Name).ToList();
                    break;

                case ButtonFilter.NotInstalled:
                    filtered = module.InstalledModules.Where(m => m.IsActive == false).OrderBy(m => m.Name).ToList();
                    break;
            }

            string modulePath = module.AppModulePath;
            int icony = 1;
            int y = 1;

            foreach (ModuleData data in filtered)
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

            if(filtered.Count > 0)
                UpdateInfoPanel(filtered.Last());
        }

        private void UpdateInfoPanel(ModuleData module)
        {
            lblText.Text = module.Name;
            lblText2.Text = module.Text;
            lblInfo.Text = module.Info;
            lblPath.Text = module.Path;
            lblVersion.Text = module.Version;
            lblDate.Text = module.PublishDate;

            if (File.Exists(module.Path + "\\changelog.json"))
                GetChangelog(module);
            else
                rtbChangelog.Text = "No changelog found!";

            lblToggleActive.Tag = module;
            lblToggleActive.Text = (module.IsActive) ? "Uninstall Module" : "Install Module";
        }

        private void GetChangelog(ModuleData module)
        {
            rtbChangelog.Text = "Not implemented";
        }

        #region Event Handlers
        private void label_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            switch (lbl.Name)
            {
                case "lblAllModules":
                    currentFilter = ButtonFilter.All;
                    GenerateButtons(currentFilter);
                    break;
                case "lblInstalledModules":
                    currentFilter = ButtonFilter.Installed;
                    GenerateButtons(currentFilter);
                    break;
                case "lblAvailableModules":
                    currentFilter = ButtonFilter.NotInstalled;
                    GenerateButtons(currentFilter);
                    break;
            }

            string pnlName = "pnlHead" + lbl.Name.Substring(3, lbl.Name.Length - 3);
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl.Name.Contains("pnlHead"))
                {
                    Panel pnl = (Panel)cntrl;
                    if (pnl.Name == pnlName)
                    {
                        pnl.Visible = true;
                    }
                    else
                        pnl.Visible = false;
                }
            }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(51, 153, 255);
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(30, 30, 30);
        }

        private void btnUtility_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            ModuleData newModule = (ModuleData)lbl.Tag;
            if (newModule.IsActive)
                newModule.IsActive = false;
            else
                newModule.IsActive = true;

            module.WriteModuleManifest(newModule);
            GenerateButtons(currentFilter);
        }

        private void btnUtility_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(51, 153, 255);
        }

        private void btnUtility_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(30, 30, 30);
        }

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
            catch (Exception) { }
        }

        private void formModules_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
