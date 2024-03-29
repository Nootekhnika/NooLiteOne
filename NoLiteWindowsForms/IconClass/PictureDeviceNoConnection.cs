﻿using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceNoConnection 
    {
        PictureBox pct_noConnection = new PictureBox();
        EventMethod eventClass = new EventMethod();

        public void CreateDeviceNoConnection(int i, PictureBox pictureBox, SerialPort port, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage, int positionPictureTop, int positionPictureLeft, Label srf13000T, Label tempT, Label tempMaxT,TabControl tabControl)
        {           
            pct_noConnection.Height = 26;
            pct_noConnection.Width = 26;
            pct_noConnection.Name = "pct_noConnection" + i.ToString();
            pct_noConnection.Left = 75;
            pct_noConnection.Top = 1;
            pct_noConnection.Image = Properties.Resources.ic_state_no_connection;
            pct_noConnection.BackColor = Color.White;
            pct_noConnection.SizeMode = PictureBoxSizeMode.StretchImage;
            if (deviceType.Equals("7"))
            {
                pct_noConnection.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                pct_noConnection.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_noConnection, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }

            if (deviceType.Equals("6"))
            {
                pct_noConnection.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T, i, tempT, tempMaxT,tabPage, tabControl); };
                pct_noConnection.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_noConnection, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }
            else
            {
                pct_noConnection.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct_noConnection.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_noConnection, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }
            pictureBox.Controls.Add(pct_noConnection);
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
