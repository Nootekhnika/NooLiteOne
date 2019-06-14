using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureSocket:Device
    {
        const string SRF101000 = "2";
        const string SRF13000  = "3";
        const string SRF13000M = "4";
        const string SUF1300   = "5";
        const string SRF13000T = "6";
        const string SRF11000R = "7";

        EventMethod eventClass = new EventMethod();

        public void CreatePictureSocket(int i, PictureBox pictureBox,SerialPort port, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage,Label srf13000T, Label tempT, Label tempMaxT)
        {
            if (deviceType.Equals(SUF1300) || deviceType.Equals(SRF101000))
            {
                PictureBox pct_socet = new PictureBox
                {
                    Height = 40,
                    Width = 40,
                    Name = "pct_socet" + i.ToString(),
                    Top = 5,
                    Left = 5,
                    Image = Properties.Resources.icon_light,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Normal
                };
                pct_socet.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct_socet.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_socet, devicesName, deviceType, tabPage, srf13000T); };
                pictureBox.Controls.Add(pct_socet);
            }
            if (deviceType.Equals(SRF13000) || deviceType.Equals(SRF13000M))
            {
                PictureBox pct_light = new PictureBox
                {
                    Height = 40,
                    Width = 40,
                    Name = "pct_light" + i.ToString(),
                    Left = 5,
                    Top = 5,
                    Image = Properties.Resources.icon_13,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Normal
                };
                pct_light.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct_light.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_light, devicesName, deviceType, tabPage, srf13000T); };
                pictureBox.Controls.Add(pct_light);
            }
            if (deviceType.Equals(SRF13000T))
            {
                CreateLabelForSRF13000T(i, pictureBox,port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection,idDevices,devicesName,deviceType,tabPage,srf13000T,tempT, tempMaxT);
                pictureBox.Controls.Add(tempT);
                pictureBox.Controls.Add(tempMaxT);
            }
            if (deviceType.Equals(SRF11000R))
            {
                PictureBox pct_roll = new PictureBox
                {
                    Height = 40,
                    Width = 40,
                    Name = "pct_roll" + i.ToString(),
                    Left = 5,
                    Top = 5,
                    Image = Properties.Resources.icon_roll,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Normal
                };
               
                    pct_roll.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                    pct_roll.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_roll, devicesName, deviceType, tabPage, srf13000T); };                         
                pictureBox.Controls.Add(pct_roll);
            }
        }

        public void CreateLabelForSRF13000T(int i, PictureBox pictureBox, SerialPort port, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage, Label srf13000T, Label tempT, Label tempMaxT)
        {

            string[] idArray = idDevices.Split('&');
            byte[] buffer = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] bufferCustomMaxTemp = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 31, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] tx_buffer = CRC(buffer);
            byte[] rx_buffer = new byte[17];
            byte[] tx_bufferCustomMaxTemp = CRC(bufferCustomMaxTemp);
            byte[] rx_bufferCustomMaxTemp = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            WaitData(port, rx_buffer);//to do
            port.DiscardInBuffer();
            port.Write(tx_bufferCustomMaxTemp, 0, tx_bufferCustomMaxTemp.Length);
            WaitData(port, rx_bufferCustomMaxTemp);
            if (port.IsOpen) port.Close();

            PictureBox pct_socet = new PictureBox
            {
                Height = 30,
                Width = 30,
                Name = "pct_socet" + i.ToString(),
                Top = 5,
                Left = 1,
                Image = Properties.Resources.icon_temp,
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            pct_socet.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T, i, tempT, tempMaxT, tabPage); };
            pct_socet.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct_socet, devicesName, deviceType, tabPage, srf13000T); };
            tempT.Text = rx_buffer[10].ToString() + "C°";
            if (rx_bufferCustomMaxTemp[2] == 1)
            { tempMaxT.Text = "------"; }
            else
            { tempMaxT.Text = rx_bufferCustomMaxTemp[7].ToString() + "C°"; }
            pictureBox.Controls.Add(pct_socet);
        } 
    }
}
