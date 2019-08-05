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
    public partial class SettingSRF11000R : Form
    {
        Device deviceR = new Device();
        readonly SerialPort port = Port.TakeDataPort();
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        public SettingSRF11000R(Device device)
        {
            InitializeComponent();
            deviceR.Channel = device.Channel;
            deviceR.Id = device.Id;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceR.Channel, 2, 0, 0, 0, 0, 0, deviceR.Id[0], deviceR.Id[1], deviceR.Id[2], deviceR.Id[3], 0, 172 };
            byte[] tx_buffer = deviceR.CRC(buffer);
            byte[] rx_buffer = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceR.WaitData(port, rx_buffer);
            if (port.IsOpen) port.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceR.Channel, 0, 0, 0, 0, 0, 0, deviceR.Id[0], deviceR.Id[1], deviceR.Id[2], deviceR.Id[3], 0, 172 };
            byte[] tx_buffer = deviceR.CRC(buffer);
            byte[] rx_buffer = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceR.WaitData(port, rx_buffer);
            if (port.IsOpen) port.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceR.Channel, 10, 0, 0, 0, 0, 0, deviceR.Id[0], deviceR.Id[1], deviceR.Id[2], deviceR.Id[3], 0, 172 };
            byte[] tx_buffer = deviceR.CRC(buffer);
            byte[] rx_buffer = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceR.WaitData(port, rx_buffer);
            if (port.IsOpen) port.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
