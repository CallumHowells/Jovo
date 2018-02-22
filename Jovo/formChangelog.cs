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
    public partial class formChangelog : Form
    {
        ModuleHandler module;

        public formChangelog(ModuleHandler _module)
        {
            module = _module;
            InitializeComponent();
        }






    }
}
