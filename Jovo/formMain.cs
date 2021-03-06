﻿using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace Jovo
{
    public partial class formMain : Form
    {
        // https://www.iconfinder.com/iconsets/colicon

        // Define Handlers
        ModuleHandler module;
        UtilityHandler utility;
        KeyboardHook hook;

        // Define Sub-Forms
        formSettings formSettings;
        formNotification formNotification;
        formModules formModules;
        formChangelog formChangelog;

        // Define Controls
        BackgroundWorker UpdateWorker = new BackgroundWorker();
        BackgroundWorker JovoUpdateWorker = new BackgroundWorker();
        BackgroundWorker ConnectionWorker = new BackgroundWorker();
        ContextMenuStrip menu = new ContextMenuStrip();
        ToolStripMenuItem item;
        ToolStripSeparator sep;
        private static NotifyIcon icon = new NotifyIcon();

        Stopwatch startupTimer = new Stopwatch();
        bool FirstStartup = true;

        public formMain(ModuleHandler _module, UtilityHandler _utility, KeyboardHook _hook)
        {
            utility = _utility;
            module = _module;
            hook = _hook;

            utility.IsDevUser = (Path.GetFileName(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)) == "Debug") ? true : false;

            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            AppDomain.CurrentDomain.FirstChanceException += new EventHandler<FirstChanceExceptionEventArgs>(FirstChance_Handler);
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            InitializeComponent();
            startupTimer.Start();
            utility.LogEvent("Program probably started OK");

            // Create NotifyIcon to sit in system tray
            icon.Text = "Jovo" + ((utility.IsDevUser) ? " Development Enviroment" : "");
            icon.Icon = (utility.IsDevUser) ? Properties.Resources.Jovo_Logo_TestEnv : Properties.Resources.Jovo_Logo;
            icon.Visible = true;
            icon.ContextMenuStrip = menu;
            icon.MouseDown += icon_Click;

            UpdateWorker.WorkerReportsProgress = true;
            UpdateWorker.DoWork += UpdateWorker_DoWork;
            UpdateWorker.RunWorkerCompleted += UpdateWorker_RunWorkerCompleted;
            UpdateWorker.ProgressChanged += UpdateWorker_ProgressChanged;
            utility.LogEvent("Module Updater starting...");
            UpdateWorker.RunWorkerAsync(true);

            JovoUpdateWorker.DoWork += JovoUpdateWorker_DoWork;
            JovoUpdateWorker.RunWorkerCompleted += JovoUpdateWorker_RunWorkerCompleted;
            utility.LogEvent("Jovo Updater Starting...");
            JovoUpdateWorker.RunWorkerAsync();

            ConnectionWorker.WorkerReportsProgress = true;
            ConnectionWorker.DoWork += ConnectionWorker_DoWork;
            ConnectionWorker.RunWorkerCompleted += ConnectionWorker_RunWorkerCompleted;
        }

        #region BackgroundWorker
        private void UpdateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            NotificationData data = (NotificationData)e.UserState;
            if (data.Method == "Show")
            {
                formNotification = new formNotification(data.Title, data.Text, data.Timeout, false, utility);
                formNotification.Show();
            }
            else
            {
                try
                {
                    formNotification.Hide();
                }
                catch (Exception) { }
            }
        }

        private void UpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
                utility.LogEvent("Updater finished - building menu");

            int prev_cat = 0;
            int first_cat = -1;

            menu.Items.Clear();
            List<ModuleData> SortedList = module.InstalledModules.Where(m => m.IsActive == true && m.CreateMenuItem == true).OrderBy(m => m.Category).ToList();

            foreach (ModuleData data in SortedList)
            {
                if ((prev_cat != data.Category) && (first_cat != -1))
                {
                    sep = new ToolStripSeparator();
                    menu.Items.Add(sep);
                }

                first_cat = (first_cat == -1) ? data.Category : first_cat;

                item = new ToolStripMenuItem();
                item.Name = data.Name;
                item.Text = data.Text;
                item.Tag = data;
                if (File.Exists(data.Path + "\\" + data.Icon))
                {
                    var bytes = File.ReadAllBytes(data.Path + "\\" + data.Icon);
                    var ms = new MemoryStream(bytes);
                    item.Image = Image.FromStream(ms);
                }
                else
                    item.Image = Properties.Resources.settings;

                if (!String.IsNullOrEmpty(data.KeyboardShortcut))
                    item.ShortcutKeys = utility.GetModuleKeyboardShortcut(data.KeyboardShortcut, hook);

                item.Click += menu_Click;
                menu.Items.Add(item);

                prev_cat = data.Category;
            }

            // Create context menu items and add to menu
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            item = new ToolStripMenuItem();
            item.Name = "tsUpdate";
            item.Text = "Check For Updates";
            item.Tag = "update";
            item.Image = Properties.Resources.refresh;
            item.Click += menu_Click;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Name = "tsChangelog";
            item.Text = "View Changelog";
            item.Tag = "changelog";
            item.Image = Properties.Resources.changelog;
            item.Click += menu_Click;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Name = "tsModules";
            item.Text = "Modules";
            item.Tag = "modules";
            item.Image = Properties.Resources.module;
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
            item.Image = Properties.Resources.close;
            item.Click += menu_Click;
            menu.Items.Add(item);

            if (FirstStartup)
            {
                utility.LogEvent($"Startup finished in {startupTimer.Elapsed.TotalSeconds.ToString()} seconds");
                utility.LogEvent($"Total memory usage: {Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024)} MB allocated ({Environment.WorkingSet / (1024 * 1024)} MB mapped)");
                FirstStartup = false;

                utility.LogEvent("Connection BackgroundWorker Started...");
                ConnectionWorker.RunWorkerAsync();
            }
        }

        private void UpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool outputResults = (bool)e.Argument;
            module.GetModuleUpdates(utility, (BackgroundWorker)sender, outputResults);
            e.Result = outputResults;
        }

        private void ConnectionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                foreach (ModuleData data in module.InstalledModules.Where(m => m.IsActive == true && m.RequiresNetwork != "").OrderBy(m => m.Category).ToList())
                {
                    if (menu.Items.Find(data.Name, false).Count() <= 0)
                        break;

                    ToolStripItem _item = menu.Items.Find(data.Name, false)[0];

                    if (data.IsConnected)
                    {
                        if (File.Exists(data.Path + "\\" + data.Icon))
                        {
                            var bytes = File.ReadAllBytes(data.Path + "\\" + data.Icon);
                            var ms = new MemoryStream(bytes);
                            _item.Image = Image.FromStream(ms);
                        }
                        else
                            _item.Image = Properties.Resources.settings;

                        _item.ToolTipText = "Connected to " + data.RequiresNetwork;
                        _item.Enabled = true;
                    }
                    else
                    {
                        if (File.Exists(data.Path + "\\" + data.Icon))
                        {
                            try
                            {
                                Image imageBackground = Image.FromFile(data.Path + "\\" + data.Icon);
                                Image imageOverlay = utility.ResizeImage(Properties.Resources.disconnected, new Size(imageBackground.Width / 2, imageBackground.Height / 2), true);

                                Image img = new Bitmap(imageBackground.Width, imageBackground.Height);
                                using (Graphics gr = Graphics.FromImage(img))
                                {
                                    gr.DrawImage(imageBackground, new Point(0, 0));
                                    gr.DrawImage(imageOverlay, imageBackground.Width / 2, imageBackground.Height / 2);
                                }

                                _item.Image = img;
                            }
                            catch (Exception) { }
                        }
                        else
                            _item.Image = Properties.Resources.settings;

                        _item.ToolTipText = "Unable to connect to " + data.RequiresNetwork;
                        _item.Enabled = true;
                    }
                }
            }
            catch (Exception) { }

            ConnectionWorker.RunWorkerAsync();
        }

        private void ConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (ModuleData data in module.InstalledModules.Where(m => m.IsActive == true && m.RequiresNetwork != "").OrderBy(m => m.Category).ToList())
            {
                if (!String.IsNullOrWhiteSpace(data.RequiresNetwork))
                {
                    if (utility.TestConnection(data.RequiresNetwork))
                        data.IsConnected = true;
                    else
                        data.IsConnected = false;
                }
            }

            Thread.Sleep(10000);
        }

        private void JovoUpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((string)e.Result == "UPDATE")
            {
                if (!Convert.ToBoolean(Jovo.Default["Jovo_Automatic_Updates"]))
                {
                    utility.LogEvent("Update Notification Shown");
                    formNotification = new formNotification("Jovo Update Available", "Click to Install", 0, true, utility);
                    DialogResult dr = formNotification.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        utility.LogEvent("Processing Update - Killing Jovo and Starting Jovo_Updater @ " + Jovo.Default.Jovo_Updater_Local_Path, true);
                        icon.Visible = false;
                        module.DoJovoUpdate(Jovo.Default.Jovo_Updater_Local_Path);
                    }
                }
                else
                {
                    utility.LogEvent("Processing Update - Killing Jovo and Starting Jovo_Updater @ " + Jovo.Default.Jovo_Updater_Local_Path, true);
                    icon.Visible = false;
                    module.DoJovoUpdate(Jovo.Default.Jovo_Updater_Local_Path);
                }
            }
            else
                JovoUpdateWorker.RunWorkerAsync();
        }

        private void JovoUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = "";

            if (File.Exists(Jovo.Default.Jovo_Update_Remote_Path + "\\manifest.json"))
            {
                if (module.CheckForJovoUpdates(Jovo.Default.Jovo_Update_Remote_Path + "\\manifest.json"))
                    e.Result = "UPDATE";
                else
                {
                    e.Result = "NOUPDATE";
                    Thread.Sleep(60000);
                }
            }
            else
            {
                e.Result = "NOUPDATE";
                Thread.Sleep(60000);
            }
        }
        #endregion

        #region Event Handlers
        private void menu_Click(object sender, EventArgs e)
        {
            // Each context menu item triggers this event, get which is triggered using Tag element //
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            switch (click.Tag)
            {
                case "modules":
                    if (module.InstalledModules.Count > 0)
                    {
                        formModules = new formModules(module, utility);
                        formModules.ShowDialog();
                    }
                    UpdateWorker.RunWorkerAsync(false);
                    break;

                case "settings":
                    if (formSettings == null)
                        formSettings = new formSettings(module, utility);
                    if (formSettings.Visible == false)
                    {
                        formSettings.ShowDialog();
                        UpdateWorker.RunWorkerAsync(false);
                    }
                    break;

                case "update":
                    if (!UpdateWorker.IsBusy)
                        UpdateWorker.RunWorkerAsync(true);
                    break;

                case "changelog":
                    formChangelog = new formChangelog(module.GetModuleChangelog(null), new Point(Screen.PrimaryScreen.WorkingArea.Width - (600 + 5), Screen.PrimaryScreen.WorkingArea.Height - (600 + 5)), "Jovo");
                    formChangelog.ShowDialog();
                    break;

                case "exit":
                    icon.Visible = false;
                    Application.Exit();
                    break;

                case "test":
                    // nothing here :'(
                    break;

                default:
                    module.ExecuteModule(module.FindModule(((ModuleData)click.Tag).Name));
                    break;
            }
        }

        private void icon_Click(object sender, MouseEventArgs e)
        {
            // Check which button is clicked and trigger the event that matches
            switch (e.Button)
            {
                case MouseButtons.Left:
                    module.ExecuteModule(module.FindModule(Jovo.Default.System_Tray_Icon_Left_Click_Module_Name));
                    break;
                case MouseButtons.Middle:
                    module.ExecuteModule(module.FindModule(Jovo.Default.System_Tray_Icon_Middle_Click_Module_Name));
                    break;

                default:
                    break;
            }
        }

        private void FirstChance_Handler(object sender, FirstChanceExceptionEventArgs e)
        {
            utility.LogEvent($"### Exception: {e.Exception.ToString()}\r\n", true, true);
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            startupTimer.Stop();
            utility.LogEvent($"Program was exited properly after {startupTimer.Elapsed} ({e.CloseReason})", true, true);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            List<ModuleData> SortedList = module.InstalledModules.Where(m => m.IsActive == true && m.CreateMenuItem == true && m.KeyboardShortcut != "").OrderBy(m => m.Category).ToList();
            foreach (ModuleData data in SortedList)
            {
                if (utility.CheckKeyboardShortcut(data, e.Modifier, e.Key))
                {
                    module.ExecuteModule(module.FindModule(data.Name));
                }
            }
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                if (Jovo.Default.Module_Name_to_Run_When_PC_Locks.Length > 0)
                    module.ExecuteModule(module.FindModule(Jovo.Default.Module_Name_to_Run_When_PC_Locks));
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                if (Jovo.Default.Module_Name_to_Run_When_PC_Unlocks.Length > 0)
                    module.ExecuteModule(module.FindModule(Jovo.Default.Module_Name_to_Run_When_PC_Unlocks));
            }
        }

        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

    }
}
