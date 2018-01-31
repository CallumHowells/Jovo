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
    public partial class formMain : Form
    {
        ToolStrip menu = new ToolStrip();

        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            menu.Items.Add(new ToolStripMenuItem { Name = "tsSettings", Text = "Settings...", Image = Properties.Resources.settings });
            menu.Items.Add(new ToolStripMenuItem { Name = "tsExit", Text = "Exit...", Image = Properties.Resources.close1 });
        }
    }
}
