﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formMain : Form
    {
        // Define Handlers
        ModuleHandler module;

        // Define Controls
        ContextMenuStrip menu = new ContextMenuStrip();
        ToolStripMenuItem item;
        NotifyIcon icon;

        //test

        public formMain(ModuleHandler _module)
        {
            module = _module;
            InitializeComponent();

            // Create NotifyIcon to sit in system tray
            icon = new NotifyIcon();
            icon.Text = "Jovo";
            icon.Icon = Properties.Resources.Jovo_Logo;
            icon.Visible = true;
            icon.ContextMenuStrip = menu;
            icon.MouseDown += icon_Click;

            foreach (ModuleData data in module.Modules)
            {
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
            }

            // Create context menu items and add to menu
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
            item.Image = Properties.Resources.close1;
            item.Click += menu_Click;
            menu.Items.Add(item);
        }

        private void formMain_Load(object sender, EventArgs e)
        {
     
        }

        private void menu_Click(object sender, EventArgs e)
        {
            // Each context menu item triggers this event, get which is triggered using Tag element //
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            switch (click.Tag)
            {
                case "settings":
                    formSettings frm = new formSettings(module);
                    frm.ShowDialog();
                    break;
                case "exit":
                    Application.Exit();
                    break;

                default:
                    ModuleData data = (ModuleData)click.Tag;
                    Process.Start(data.Path + "\\" + data.Name + ".exe");
                    break;
            }
        }

        private void icon_Click(object sender, MouseEventArgs e)
        {
            // Check which button is clicked and trigger the event that matches
            switch (e.Button)
            {
                case MouseButtons.Left:
                    module.ExecuteModule(Jovo.Default.System_Tray_Icon_Middle_Click_Module);
                    break;
                case MouseButtons.Middle:
                    module.ExecuteModule(Jovo.Default.System_Tray_Icon_Left_Click_Module);
                    break;

                default:
                    break;
            }
        }

    }
}
