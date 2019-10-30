using System;
using System.Drawing;
using System.IO.Ports;
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }

        private void Switch_Color(object sender, EventArgs e)
        {
            try
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
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }

        private void SendUpdateColorCmd(Color c)
        {
            try
            {
                byte[] bufferNextColor = new byte[17] { 171, 0, 0, 0, deviceChannel, 6, 3, c.R, c.G, c.B, 0, 0, 0, 0, 0, 0, 172 };
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
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }

        private void TrackBright_Scroll(object sender, EventArgs e)
        {
            BrightControl();
        }

        private void TrackBright_Scroll(object sender, MouseEventArgs e)
        {
            BrightControl();
        }

        public void BrightControl()
        {
            try
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
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void СhangeColor_Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            panel1.BackColor = colorDialog1.Color;
            SendUpdateColorCmd(colorDialog1.Color);
        }
    }
}
