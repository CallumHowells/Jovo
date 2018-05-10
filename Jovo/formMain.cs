using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Diagnostics;

namespace Jovo
{
    public partial class formMain : Form
    {
        // https://www.iconfinder.com/iconsets/colicon

        // Define Handlers
        ModuleHandler module;
        UtilityHandler utility;

        // Define Sub-Forms
        formSettings settings;
        formNotification notification;
        formModules formModules;

        // Define Controls
        BackgroundWorker UpdateWorker = new BackgroundWorker();
        ContextMenuStrip menu = new ContextMenuStrip();
        ToolStripMenuItem item;
        ToolStripSeparator sep;
        private static NotifyIcon icon = new NotifyIcon();
        Stopwatch startupTimer = new Stopwatch();

        public formMain(ModuleHandler _module, UtilityHandler _utility)
        {
            utility = _utility;
            module = _module;

            AppDomain.CurrentDomain.FirstChanceException += new EventHandler<FirstChanceExceptionEventArgs>(FirstChance_Handler);

            InitializeComponent();
            startupTimer.Start();

            // Create NotifyIcon to sit in system tray
            icon.Text = "Jovo";
            icon.Icon = Properties.Resources.Jovo_Logo;
            icon.Visible = true;
            icon.ContextMenuStrip = menu;
            icon.MouseDown += icon_Click;

            UpdateWorker.WorkerReportsProgress = true;
            UpdateWorker.DoWork += UpdateWorker_DoWork;
            UpdateWorker.RunWorkerCompleted += UpdateWorker_RunWorkerCompleted;
            UpdateWorker.ProgressChanged += UpdateWorker_ProgressChanged;
            utility.LogEvent("Program probably started OK");
            UpdateWorker.RunWorkerAsync();
        }

        private void UpdateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            NotificationData data = (NotificationData)e.UserState;
            if (data.Method == "Show")
            {
                notification = new formNotification(data.Title, data.Text, data.Timeout);
                notification.Show();
            }
            else
            {
                try
                {
                    notification.Hide();
                }
                catch (Exception) { }
            }
        }

        private void UpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            utility.LogEvent("Updater finished");
            int prev_cat = 0;
            List<ModuleData> SortedList = module.InstalledModules.OrderBy(m=>m.Category).ToList();
            foreach (ModuleData data in SortedList)
            {
                if (data.CreateMenuItem)
                {
                    if (prev_cat != data.Category)
                    {
                        sep = new ToolStripSeparator();
                        menu.Items.Add(sep);
                    }

                    item = new ToolStripMenuItem();
                    item.Name = data.Name;
                    item.Text = data.Text;
                    item.Tag = data;
                    if (File.Exists(data.Path + "\\" + data.Icon))
                        item.Image = Image.FromFile(data.Path + "\\" + data.Icon);
                    else
                        item.Image = Properties.Resources.settings;
                    item.Click += menu_Click;
                    menu.Items.Add(item);

                    prev_cat = data.Category;
                }
            }

            // Create context menu items and add to menu
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            item = new ToolStripMenuItem();
            item.Name = "tsModules";
            item.Text = "Modules";
            item.Tag = "modules";
            item.Click += menu_Click;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Name = "tsSettings";
            item.Text = "Settings";
            item.Tag = "settings";
            item.Image = Properties.Resources.settings;
            item.Click += menu_Click;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Name = "tsExit";
            item.Text = "Exit";
            item.Tag = "exit";
            item.Image = Properties.Resources.exit;
            item.Click += menu_Click;
            menu.Items.Add(item);

            utility.LogEvent($"Startup finished in {startupTimer.Elapsed.TotalSeconds.ToString()} seconds");
            utility.LogEvent($"Total memory usage: {Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024)} MB allocated ({Environment.WorkingSet / (1024 * 1024)} MB mapped)");
        }

        private void UpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            utility.LogEvent("Updater starting...");
            module.GetModuleUpdates(utility, (BackgroundWorker)sender);
        }

        private void menu_Click(object sender, EventArgs e)
        {
            // Each context menu item triggers this event, get which is triggered using Tag element //
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            switch (click.Tag)
            {
                case "modules":
                    formModules = new formModules(module, utility);
                    formModules.Show();
                    break;

                case "settings":
                    if (settings == null)
                        settings = new formSettings(module, utility);
                    if (settings.Visible == false)
                        settings.Show();
                    break;

                case "exit":
                    icon.Visible = false;
                    Application.Exit();
                    break;

                default:
                    module.ExecuteModule((ModuleData)click.Tag);
                    break;
            }
        }

        private void icon_Click(object sender, MouseEventArgs e)
        {
            // Check which button is clicked and trigger the event that matches
            switch (e.Button)
            {
                case MouseButtons.Left:
                    module.ExecuteModule(module.FindModule(Jovo.Default.System_Tray_Icon_Left_Click_Module));
                    break;
                case MouseButtons.Middle:
                    module.ExecuteModule(module.FindModule(Jovo.Default.System_Tray_Icon_Middle_Click_Module));
                    break;

                default:
                    break;
            }
        }

        private void FirstChance_Handler(object sender, FirstChanceExceptionEventArgs e) => utility.LogEvent($"{e.Exception.Source} - {e.Exception.ToString()}\n", true, true);

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            startupTimer.Stop();
            utility.LogEvent($"Program was exited properly after {startupTimer.Elapsed} ({e.CloseReason})", true, true);
        }
    }
}
