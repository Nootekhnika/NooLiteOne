using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceOff
    {
        PictureBox pct_off = new PictureBox();
        EventMethod eventClass = new EventMethod();

        public void CreateDeviceOff(int i, PictureBox pictureBox, SerialPort port, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage, int positionPictureTop, int positionPictureLeft, Label srf13000T, Label tempT, Label tempMaxT)
        {
           
            pct_off.Height = 26;
            pct_off.Width = 26;
            pct_off.Name = "pct_off" + i.ToString();
            pct_off.Left = 75;
            pct_off.Top = 1;
            pct_off.Image = Properties.Resources.offline;
            pct_off.BackColor = Color.White;
            pct_off.SizeMode = PictureBoxSizeMode.StretchImage;
            if (deviceType.Equals("7"))
            {
                pct_off.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                pct_off.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_off, devicesName, deviceType, tabPage, srf13000T); };
            }

            if (deviceType.Equals("6"))
            {
                pct_off.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T, i, tempT, tempMaxT,tabPage); };
                pct_off.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_off, devicesName, deviceType, tabPage, srf13000T); };
            }
            else
            {
                pct_off.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct_off.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_off, devicesName, deviceType, tabPage, srf13000T); };
            }
            pictureBox.Controls.Add(pct_off);
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
