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

        public void CreatePictureSocket(int i, PictureBox pct, string deviceType, SerialPort port, string devicesChannel, string idDevices,Label labelTempT,Label labelTempMaxT)
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
                pct.Controls.Add(pct_socet);
            }
            if(deviceType.Equals(SRF13000) || deviceType.Equals(SRF13000M))
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
                pct.Controls.Add(pct_light);
            }
            if (deviceType.Equals(SRF13000T))
            {
                CreateLabelForSRF13000T(i, port, devicesChannel, pct, deviceType, idDevices, labelTempT, labelTempMaxT);
                pct.Controls.Add(labelTempT);
                pct.Controls.Add(labelTempMaxT);
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
                pct.Controls.Add(pct_roll);
            }
        }

        public void CreateLabelForSRF13000T(int i, SerialPort port, string devicesChannel, PictureBox pct, string deviceType, string idDevices, Label labelTempT, Label labelTempMaxT)
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
            WaitData(port,rx_buffer);//to do
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
            labelTempT.Text = rx_buffer[10].ToString() + "C°";
            labelTempMaxT.Text = rx_bufferCustomMaxTemp[7].ToString() + "C°";
            pct.Controls.Add(pct_socet);          
        }    
    }
}
