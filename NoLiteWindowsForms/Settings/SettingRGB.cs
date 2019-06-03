using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
    public partial class SettingRGB : Form
    {
        byte deviceChannel;
        DeviceTX device = new DeviceTX();
        readonly SerialPort port = Port.TakeDataPort();

        public SettingRGB(DeviceTX device)
        {
            InitializeComponent();
            deviceChannel = byte.Parse(int.Parse(device.Channel.ToString()).ToString());
            UpdateColor();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferNextColor = device.CRC(bufferNextColor);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            port.Write(tx_bufferNextColor, 0, tx_bufferNextColor.Length);

            if (port.IsOpen)
            {
                port.Close();
            }
        }

        private void Switch_Color(object sender, EventArgs e)
        {
            byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferNextColor = device.CRC(bufferNextColor);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            port.Write(tx_bufferNextColor, 0, tx_bufferNextColor.Length);

            if (port.IsOpen)
            {
                port.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferNextColor = device.CRC(bufferNextColor);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            port.Write(tx_bufferNextColor, 0, tx_bufferNextColor.Length);

            if (port.IsOpen)
            {
                port.Close();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferNextColor = device.CRC(bufferNextColor);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            port.Write(tx_bufferNextColor, 0, tx_bufferNextColor.Length);

            if (port.IsOpen)
            {
                port.Close();
            }
        }

        private void UpdateColor()
        {
            Color c = Color.FromArgb(trackBar2.Value, trackBar3.Value, trackBar4.Value);
            panel1.BackColor = c;          
        }

        private void SendUpdateColorCmd()
        {
            Color c = Color.FromArgb(trackBar2.Value, trackBar3.Value, trackBar4.Value);
            panel1.BackColor = c;
            int red = ((trackBar2.Value - 0) * 100 / (255 - 0));
            int green = ((trackBar3.Value - 0) * 100 / (255 - 0));
            int blue = ((trackBar4.Value - 0) * 100 / (255 - 0));

            byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 6, 3, byte.Parse(red.ToString()), byte.Parse(green.ToString()), byte.Parse(blue.ToString()), 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferNextColor = device.CRC(bufferNextColor);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            port.Write(tx_bufferNextColor, 0, tx_bufferNextColor.Length);

            if (port.IsOpen)
            {
                port.Close();
            }
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void TrackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void TrackBar4_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void TrackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            SendUpdateColorCmd();
        }

        private void TrackBar3_MouseUp(object sender, MouseEventArgs e)
        {
            SendUpdateColorCmd();
        }

        private void TrackBar4_MouseUp(object sender, MouseEventArgs e)
        {
            SendUpdateColorCmd();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = ((trackBar1.Value - 28) * 100 / (156 - 28)).ToString() + "%";
            byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 6, 1, byte.Parse(trackBar1.Value.ToString()), 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferNextColor = device.CRC(bufferNextColor);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            port.Write(tx_bufferNextColor, 0, tx_bufferNextColor.Length);

            if (port.IsOpen)
            {
                port.Close();
            }
        }
    }
}
