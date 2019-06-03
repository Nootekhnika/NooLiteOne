using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceOff
    {
        PictureBox pct_off = new PictureBox();

        public void CreateDeviceOff(int i, PictureBox pct)
        {
           
            pct_off.Height = 26;
            pct_off.Width = 26;
            pct_off.Name = "pct_off" + i.ToString();
            pct_off.Left = 71;
            pct_off.Image = Properties.Resources.ic_state_off_3x;
            pct_off.BackColor = Color.White;
            pct_off.SizeMode = PictureBoxSizeMode.Zoom;
            pct.Controls.Add(pct_off);
        }

        public void VisibleTrue()
        {
            pct_off.Visible = true;
        }

        public void VisibleFalse()
        {
            pct_off.Visible = false;
        }
    }
}
