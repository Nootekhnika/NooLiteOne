using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceNoConnection
    {
        PictureBox pct_noConnection = new PictureBox();

        public void CreateDeviceNoConnection(int i, PictureBox pct)
        {           
            pct_noConnection.Height = 23;
            pct_noConnection.Width = 23;
            pct_noConnection.Name = "pct_noConnection" + i.ToString();
            pct_noConnection.Left = 73;
            pct_noConnection.Image = Properties.Resources.ic_state_no_connection;
            pct_noConnection.BackColor = Color.White;
            pct_noConnection.SizeMode = PictureBoxSizeMode.Zoom;
            pct.Controls.Add(pct_noConnection);
        }
        public void VisibleTrue()
        {
            pct_noConnection.Visible = true;
        }
        public void VisibleFalse()
        {
            pct_noConnection.Visible = false;
        }
        public bool StatusIcon()
        {
            if (pct_noConnection.Visible)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
