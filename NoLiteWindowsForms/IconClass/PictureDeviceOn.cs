using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceOn
    {
        PictureBox pct_on = new PictureBox();

        public void CreatePictureDeviceOn(int i, PictureBox pct)
        {
            
            pct_on.Height = 26;
            pct_on.Width = 26;
            pct_on.Name = "pct_on" + i.ToString();
            pct_on.Left = 71;
            pct_on.Image = Properties.Resources.ic_state_on;
            pct_on.BackColor = Color.White;
            pct_on.SizeMode = PictureBoxSizeMode.Zoom;
            pct_on.Visible = false;
            pct.Controls.Add(pct_on);
        }

        public void VisibleTrue()
        {          
                pct_on.Visible = true;                   
        }

        public void VisibleFalse()
        {
            pct_on.Visible = false;
        }
       //public void VisibleStatus(PictureDeviceOff off)
       // {
       //     if (pct_on.Visible)
       //     {
       //         pct_on.Visible = false;
       //         off.VisibleTrue();
       //     }
       //     else
       //     {
       //         pct_on.Visible = true;
       //         off.VisibleFalse();
       //     }
       // }
    }
}
