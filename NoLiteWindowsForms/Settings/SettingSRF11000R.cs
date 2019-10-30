using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
    public partial class SettingSRF11000R : Form
    {
        Device deviceR = new Device();
        readonly SerialPort port = Port.TakeDataPort();

        public SettingSRF11000R(Device device)
        {
            InitializeComponent();
            deviceR.Channel = device.Channel;
            deviceR.Id = device.Id;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceR.Channel, 2, 0, 0, 0, 0, 0, deviceR.Id[0], deviceR.Id[1], deviceR.Id[2], deviceR.Id[3], 0, 172 };
                byte[] tx_buffer = deviceR.CRC(buffer);
                byte[] rx_buffer = new byte[17];
                if (port.IsOpen == false) port.Open();
                port.Write(tx_buffer, 0, tx_buffer.Length);
                deviceR.WaitData(port, rx_buffer);
                if (port.IsOpen) port.Close();
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

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceR.Channel, 0, 0, 0, 0, 0, 0, deviceR.Id[0], deviceR.Id[1], deviceR.Id[2], deviceR.Id[3], 0, 172 };
                byte[] tx_buffer = deviceR.CRC(buffer);
                byte[] rx_buffer = new byte[17];
                if (port.IsOpen == false) port.Open();
                port.Write(tx_buffer, 0, tx_buffer.Length);
                deviceR.WaitData(port, rx_buffer);
                if (port.IsOpen) port.Close();
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
                byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceR.Channel, 10, 0, 0, 0, 0, 0, deviceR.Id[0], deviceR.Id[1], deviceR.Id[2], deviceR.Id[3], 0, 172 };
                byte[] tx_buffer = deviceR.CRC(buffer);
                byte[] rx_buffer = new byte[17];
                if (port.IsOpen == false) port.Open();
                port.Write(tx_buffer, 0, tx_buffer.Length);
                deviceR.WaitData(port, rx_buffer);
                if (port.IsOpen) port.Close();
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
            Close();
        }
    }
}
