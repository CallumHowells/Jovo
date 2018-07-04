using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formSettings : Form
    {
        ModuleHandler module;
        UtilityHandler utility;
        bool settingsChanged;

        public formSettings(ModuleHandler _module, UtilityHandler _utility)
        {
            module = _module;
            utility = _utility;
            InitializeComponent();

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width + 5), Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height + 5));
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            settingsChanged = false;
            GenerateSettingHeaders();
        }

        private void GenerateSettingHeaders()
        {
            Label lbl = new Label();
            lbl.Name = "lblJovo";
            lbl.Text = "Jovo";
            lbl.AutoSize = true;
            lbl.ForeColor = Color.FromArgb(30, 30, 30);
            lbl.BackColor = Color.Transparent;
            lbl.MouseEnter += label_MouseEnter;
            lbl.MouseLeave += label_MouseLeave;
            lbl.Click += label_Click;
            lbl.Tag = null;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Location = new Point(5, 70);
            lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Controls.Add(lbl);

            Panel pnl = new Panel();
            pnl.Name = "pnlHeadJovo";
            pnl.Size = new Size(lbl.Size.Width, 3);
            pnl.Location = new Point(5, 95);
            pnl.BackColor = Color.FromArgb(51, 153, 255);
            pnl.Visible = true;
            this.Controls.Add(pnl);

            FillInfoPanel(null);
            GenerateSettingPanel(null);

            int x = 5 + lbl.Size.Width + 5;
            foreach (ModuleData data in module.InstalledModules)
            {
                if (data.HasSettings)
                {
                    Label header = new Label();
                    header.Name = "lbl" + data.Name;
                    header.Text = data.Text;
                    header.AutoSize = true;
                    header.ForeColor = Color.FromArgb(30, 30, 30);
                    header.BackColor = Color.Transparent;
                    header.MouseEnter += label_MouseEnter;
                    header.MouseLeave += label_MouseLeave;
                    header.Click += label_Click;
                    header.Tag = data.Tag;
                    header.TextAlign = ContentAlignment.MiddleLeft;
                    //header.Size = new Size(100, 25);
                    header.Location = new Point(x, 70);
                    header.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                    this.Controls.Add(header);

                    Panel under = new Panel();
                    under.Name = "pnlHead" + data.Name;
                    under.Size = new Size(header.Size.Width, 3);
                    under.Location = new Point(x, 95);
                    under.BackColor = Color.FromArgb(51, 153, 255);
                    under.Visible = false;
                    this.Controls.Add(under);
                    x += header.Size.Width + 5;
                }
            }
        }

        private void GenerateSettingPanel(object ModuleTag)
        {
            if (!UserChangedSettings(ModuleTag))
            {
                pnlSettings.Controls.Clear();
                foreach (Control cntrl in this.Controls)
                {
                    if (cntrl.Name.Contains("btnSave"))
                    {
                        Button btn = (Button)cntrl;
                        btn.Dispose();
                    }
                }

                if (ModuleTag == null)
                {
                    int x = 10;
                    int y = 5;
                    foreach (SettingsProperty setting in Jovo.Default.Properties)
                    {
                        Label name = new Label();
                        name.Name = "lbl" + setting.Name;
                        name.Text = setting.Name.Replace("_", " ");
                        name.ForeColor = Color.FromArgb(30, 30, 30);
                        name.Size = new Size(pnlSettings.Size.Width - (x + 30), 13);
                        name.Location = new Point(x, y);
                        pnlSettings.Controls.Add(name);
                        y += 15;

                        if (setting.Name.Contains("Module_Name"))
                        {
                            ComboBox value = new ComboBox();
                            value.Name = "cbx" + setting.Name;
                            value.Size = new Size(pnlSettings.Size.Width - (x + 30), 21);
                            value.Location = new Point(x, y);
                            value.SelectedValueChanged += setting_SelectedValueChanged;
                            value.DropDownStyle = ComboBoxStyle.DropDownList;
                            foreach (ModuleData data in module.InstalledModules)
                                value.Items.Add(data.Name);
                            value.SelectedItem = Jovo.Default[setting.Name].ToString();
                            pnlSettings.Controls.Add(value);
                            y += 21;
                        }
                        else if (setting.Name.Contains("Path"))
                        {
                            TextBox pth = new TextBox();
                            pth.Name = "txt" + setting.Name;
                            pth.Text = Jovo.Default[setting.Name].ToString();
                            pth.Size = new Size(pnlSettings.Size.Width - (x + 58), 22);
                            pth.Location = new Point(x, y);
                            pth.TextChanged += setting_TextChanged;
                            pnlSettings.Controls.Add(pth);

                            Button pthbrowse = new Button();
                            pthbrowse.Name = "btn" + setting.Name;
                            pthbrowse.Text = "...";
                            pthbrowse.Size = new Size(24, 22);
                            pthbrowse.Location = new Point(x + (pnlSettings.Size.Width - (x + 54)), y);
                            pthbrowse.Click += path_Click;
                            pnlSettings.Controls.Add(pthbrowse);
                            y += 22;
                        }
                        else
                        {
                            TextBox value = new TextBox();
                            value.Name = "txt" + setting.Name;
                            value.Text = Jovo.Default[setting.Name].ToString();
                            value.Size = new Size(pnlSettings.Size.Width - (x + 30), 22);
                            value.Location = new Point(x, y);
                            value.TextChanged += setting_TextChanged;
                            pnlSettings.Controls.Add(value);
                            y += 22;
                        }

                        y += 10;
                    }

                    Button btn = new Button();
                    btn.Name = "btnSave";
                    btn.Text = "Save Changes";
                    btn.Tag = null;
                    btn.Size = new Size(400, 23);
                    btn.Location = new Point(12, 565);
                    btn.Click += save_Click;
                    this.Controls.Add(btn);

                    ShowNoSettings(false);
                }
                else
                {
                    int x = 10;
                    int y = 5;

                    try
                    {
                        foreach (SettingData data in module.GetModuleSettings((ModuleData)ModuleTag))
                        {
                            Label name = new Label();
                            name.Name = "lbl" + data.Name;
                            name.Text = data.Text;
                            name.ForeColor = Color.FromArgb(30, 30, 30);
                            name.Size = new Size(pnlSettings.Size.Width - (x + 30), 13);
                            name.Location = new Point(x, y);
                            pnlSettings.Controls.Add(name);
                            y += 15;

                            switch (data.Domain)
                            {
                                case "string":
                                    TextBox str = new TextBox();
                                    str.Name = "txt" + data.Name;
                                    str.Text = data.Value;
                                    str.Size = new Size(pnlSettings.Size.Width - (x + 30), 22);
                                    str.Location = new Point(x, y);
                                    str.TextChanged += setting_TextChanged;
                                    pnlSettings.Controls.Add(str);
                                    y += 22;
                                    break;

                                case "password":
                                    TextBox pas = new TextBox();
                                    pas.Name = "txt" + data.Name;
                                    pas.Text = data.Value;
                                    pas.UseSystemPasswordChar = true;
                                    pas.Size = new Size(pnlSettings.Size.Width - (x + 30), 22);
                                    pas.Location = new Point(x, y);
                                    pas.TextChanged += setting_TextChanged;
                                    pnlSettings.Controls.Add(pas);
                                    y += 22;
                                    break;

                                case "integer":
                                    NumericUpDown num = new NumericUpDown();
                                    num.Name = "num" + data.Name;
                                    num.Minimum = 0;
                                    num.Maximum = Int32.MaxValue;
                                    num.Value = (int.TryParse(data.Value, out int value)) ? Convert.ToInt32(data.Value) : 0;
                                    num.Size = new Size(pnlSettings.Size.Width - (x + 30), 22);
                                    num.Location = new Point(x, y);
                                    num.TextChanged += setting_ValueChanged;
                                    pnlSettings.Controls.Add(num);
                                    y += 22;
                                    break;

                                case "path":
                                    TextBox pth = new TextBox();
                                    pth.Name = "txt" + data.Name;
                                    pth.Text = data.Value;
                                    pth.Size = new Size(pnlSettings.Size.Width - (x + 58), 22);
                                    pth.Location = new Point(x, y);
                                    pth.TextChanged += setting_TextChanged;
                                    pnlSettings.Controls.Add(pth);

                                    Button pthbrowse = new Button();
                                    pthbrowse.Name = "btn" + data.Name;
                                    pthbrowse.Text = "...";
                                    pthbrowse.Size = new Size(24, 22);
                                    pthbrowse.Location = new Point(x + (pnlSettings.Size.Width - (x + 54)), y);
                                    pthbrowse.Click += path_Click;
                                    pnlSettings.Controls.Add(pthbrowse);
                                    y += 22;
                                    break;

                                case "boolean":
                                    ComboBox cmb = new ComboBox();
                                    cmb.Name = "cbx" + data.Name;
                                    cmb.Size = new Size(pnlSettings.Size.Width - (x + 30), 21);
                                    cmb.Location = new Point(x, y);
                                    cmb.SelectedValueChanged += setting_SelectedValueChanged;
                                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                                    cmb.Items.Add("True");
                                    cmb.Items.Add("False");
                                    cmb.SelectedItem = data.Value;
                                    pnlSettings.Controls.Add(cmb);
                                    y += 21;
                                    break;

                                default:
                                    TextBox som = new TextBox();
                                    som.Name = "txt" + data.Name;
                                    som.Text = data.Value;
                                    som.Size = new Size(pnlSettings.Size.Width - (x + 30), 22);
                                    som.Location = new Point(x, y);
                                    som.TextChanged += setting_TextChanged;
                                    pnlSettings.Controls.Add(som);
                                    y += 22;
                                    break;
                            }


                            y += 10;
                        }

                        Button btn = new Button();
                        btn.Name = "btnSave";
                        btn.Text = "Save Changes";
                        btn.Tag = ModuleTag;
                        btn.Size = new Size(400, 23);
                        btn.Location = new Point(12, 565);
                        btn.Click += save_Click;
                        this.Controls.Add(btn);

                        ShowNoSettings(false);
                    }
                    catch (Exception)
                    { ShowNoSettings(true); }
                }

                settingsChanged = false;
            }
        }

        private void FillInfoPanel(object ModuleTag)
        {
            if (ModuleTag == null)
            {
                lblModuleText.Text = "Jovo";
                lblModuleInfo.Text = "Jovo is a multi-functional tool for consolidating modules until one centralised menu for easy access via the Windows system tray.";
                lblModulePath.Text = module.AppPath;
                lblModuleName.Text = "jovo";
                dynamic vers = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("manifest.json"));
                lblModuleVersion.Text = vers.Version.ToString();
                lblModulePublishDate.Text = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime.ToString("");
            }
            else
            {
                ModuleData data = (ModuleData)ModuleTag;
                lblModuleText.Text = data.Text;
                lblModuleInfo.Text = data.Info;
                lblModulePath.Text = data.Path;
                lblModulePath.Click += path_Clicked;
                lblModuleName.Text = data.Name;
                lblModuleVersion.Text = data.Version;
                lblModulePublishDate.Text = data.PublishDate;
            }
        }

        private bool UserChangedSettings(object ModuleTag)
        {
            if (settingsChanged)
            {
                DialogResult dr = MessageBox.Show("Any unsaved changes will be lost!\n\nAre you sure you want to continue?", "Warning...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void ShowNoSettings(bool visible)
        {
            pnlNoSettings.Visible = visible;
        }

        private void ShowSaveSuccess(object ModuleTag)
        {
            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += save_Tick;
            if (ModuleTag == null)
            {
                lblSaveSuccess.Text = "Settings for Jovo were saved successfully!";
                utility.LogEvent("Jovo settings were changed");
            }
            else
            {
                ModuleData data = (ModuleData)ModuleTag;
                lblSaveSuccess.Text = "Settings for " + data.Text + " were saved successfully!";
                utility.LogEvent(data.Name + " settings were changed");
            }
            pnlSaveSuccess.Visible = true;

            timer.Start();
        }

        #region EventHandlers
        private void label_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            string pnlName = "pnlHead" + lbl.Name.Substring(3, lbl.Name.Length - 3);
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl.Name.Contains("pnlHead"))
                {
                    Panel pnl = (Panel)cntrl;
                    if (pnl.Name == pnlName)
                    {
                        pnl.Visible = true;
                        FillInfoPanel(lbl.Tag);
                        GenerateSettingPanel(lbl.Tag);
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

        private void lblModuleChangelog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changelog form doesnt work yet.");
        }

        private void btnFormClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formSettings_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void setting_SelectedValueChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }

        private void setting_TextChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }

        private void setting_ValueChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
            {
                foreach (SettingsProperty setting in Jovo.Default.Properties)
                {
                    if (setting.Name.Contains("Module_Name"))
                    {
                        foreach (Control cntrl in pnlSettings.Controls)
                            if (cntrl.Name == "cbx" + setting.Name)
                            {
                                ComboBox value = (ComboBox)cntrl;
                                Jovo.Default[setting.Name] = value.Text;
                            }
                    }
                    else
                    {
                        foreach (Control cntrl in pnlSettings.Controls)
                            if (cntrl.Name == "txt" + setting.Name)
                            {
                                TextBox value = (TextBox)cntrl;
                                Jovo.Default[setting.Name] = value.Text;
                            }
                    }
                }
                Jovo.Default.Save();
                ShowSaveSuccess(btn.Tag);
                settingsChanged = false;
            }
            else
            {
                List<SettingData> save = new List<SettingData>();
                foreach (SettingData data in module.GetModuleSettings((ModuleData)btn.Tag))
                {
                    foreach (Control cntrl in pnlSettings.Controls)
                        switch (data.Domain)
                        {
                            case "boolean":
                                if (cntrl.Name == "cbx" + data.Name)
                                {
                                    ComboBox value = (ComboBox)cntrl;

                                    //JObject set = new JObject(
                                    //     new JProperty("Name", data.Name),
                                    //     new JProperty("Text", data.Text),
                                    //     new JProperty("Domain", data.Domain),
                                    //     new JProperty("Value", value.SelectedItem));

                                    SettingData set = new SettingData
                                    {
                                        Name = data.Name,
                                        Text = data.Text,
                                        Domain = data.Domain,
                                        Value = value.SelectedItem.ToString()
                                    };

                                    save.Add(set);
                                }
                                break;

                            case "integer":
                                if (cntrl.Name == "num" + data.Name)
                                {
                                    NumericUpDown value = (NumericUpDown)cntrl;

                                    //JObject set = new JObject(
                                    //     new JProperty("Name", data.Name),
                                    //     new JProperty("Text", data.Text),
                                    //     new JProperty("Domain", data.Domain),
                                    //     new JProperty("Value", Convert.ToInt32(value.Value)));

                                    SettingData set = new SettingData
                                    {
                                        Name = data.Name,
                                        Text = data.Text,
                                        Domain = data.Domain,
                                        Value = value.Value.ToString()
                                    };

                                    save.Add(set);
                                }
                                break;

                            default:
                                if (cntrl.Name == "txt" + data.Name)
                                {
                                    TextBox value = (TextBox)cntrl;

                                    //JObject set = new JObject(
                                    //     new JProperty("Name", data.Name),
                                    //     new JProperty("Text", data.Text),
                                    //     new JProperty("Domain", data.Domain),
                                    //     new JProperty("Value", value.Text));

                                    SettingData set = new SettingData
                                    {
                                        Name = data.Name,
                                        Text = data.Text,
                                        Domain = data.Domain,
                                        Value = value.Text
                                    };

                                    save.Add(set);
                                }
                                break;
                        }
                }
                if (module.SaveModuleSettings((ModuleData)btn.Tag, save))
                {
                    ShowSaveSuccess(btn.Tag);
                    settingsChanged = false;
                } else
                {
                    utility.LogEvent("Error occured while saving settings (file does not exist)");
                }
            }
        }

        private void save_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            pnlSaveSuccess.Visible = false;
        }

        private void path_Click(object sender, EventArgs e)
        {
            this.Deactivate -= formSettings_Deactivate;
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowNewFolderButton = true;
            fld.Description = "Select Path...";
            fld.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult dia = fld.ShowDialog();
            if (dia == DialogResult.OK)
            {
                Button btn = (Button)sender;
                ((TextBox)pnlSettings.Controls[btn.Name.Replace("btn", "txt")]).Text = fld.SelectedPath;
            }
            this.Deactivate += formSettings_Deactivate;
        }

        private void btnFormClose_MouseEnter(object sender, EventArgs e)
        {
            btnFormClose.BackColor = Color.FromArgb(201, 222, 245);
        }

        private void btnFormClose_MouseLeave(object sender, EventArgs e)
        {
            btnFormClose.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void path_Clicked(object sender, EventArgs e)
        {
            Label clicked = (Label)sender;
            System.Diagnostics.Process.Start(clicked.Text);
        }
        #endregion

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
