﻿using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceOn
    {
        PictureBox pct_on = new PictureBox();
        EventMethod eventClass = new EventMethod();

        public void CreatePictureDeviceOn(int i, PictureBox pictureBox, SerialPort port, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage, int positionPictureTop, int positionPictureLeft, Label srf13000T, Label tempT, Label tempMaxT,TabControl tabControl)
        {
            pct_on.Height = 26;
            pct_on.Width = 26;
            pct_on.Name = "pct_on" + i.ToString();
            pct_on.Left = 75;
            pct_on.Top = 1;
            pct_on.Image = Properties.Resources.green;
            pct_on.BackColor = Color.White;
            pct_on.SizeMode = PictureBoxSizeMode.StretchImage;
            pct_on.Visible = false;
            if (deviceType.Equals("7"))
            {
                pct_on.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                pct_on.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_on, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }

            if (deviceType.Equals("6"))
            {
                pct_on.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T, i, tempT, tempMaxT,tabPage, tabControl); };
                pct_on.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_on, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }
            else
            {
                pct_on.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct_on.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_on, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }
            pictureBox.Controls.Add(pct_on);
        }

        public void VisibleTrue()
        {          
                pct_on.Visible = true;                   
        }

        public void VisibleFalse()
        {
            pct_on.Visible = false;
        }
    }
}
