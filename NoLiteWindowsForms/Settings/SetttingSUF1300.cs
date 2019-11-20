using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
    public partial class SetttingSUF1300 : Form
    {

        Device device = new Device();
        readonly SerialPort port;
        byte deviceChannel;
        string[] idArray;

        public SetttingSUF1300(SerialPort _port, string devicesChannel, string idDevices)
        {
            InitializeComponent();
            deviceChannel = byte.Parse(devicesChannel);
            port = _port;
            idArray = idDevices.Split('&');
        }
        
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SufOn_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffer = new byte[17] { 171, 2, 0, 0, deviceChannel, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                byte[] tx_bufferNextColor = device.CRC(buffer);
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

        private void SufOff_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffer = new byte[17] { 171, 2, 0, 0, deviceChannel, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                byte[] tx_bufferNextColor = device.CRC(buffer);
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
    }
}
