using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jovo
{
    public class UtilityHandler
    {
        public UtilityHandler() { }

        formNotification frm;

        public void ShowNotification(string Title, string Text, int Timeout, bool SupportsCancellation)
        {
            frm = new formNotification(Title, Text, Timeout);
            frm.Show();
        }

        public void HideNotification()
        {
            try
            {
                frm.Close();
            }
            catch (Exception) { }
        }
        

    }
}
