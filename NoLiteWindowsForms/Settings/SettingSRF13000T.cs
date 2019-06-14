using NooLiteServiceSoft.IconClass;
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
    public partial class SettingSRF13000T : Form
    {
        Device deviceT = new Device();
        readonly SerialPort port = Port.TakeDataPort();
        Icons icons = new Icons();
        PictureBox _pct = new PictureBox();
        PictureDeviceOn _deviceOn = new PictureDeviceOn();
        PictureDeviceNoConnection _deviceNoConnection = new PictureDeviceNoConnection();
        PictureDeviceOff _deviceoff = new PictureDeviceOff();
        Label _labelSRF13000T;
        Label _tempT;
        Label _tempMaxT;
        string nameDevice;
        TabPage _page;
        PictureSocket pictureSocket = new PictureSocket();
        int _i;

        public SettingSRF13000T(Device device,PictureBox pct, PictureDeviceOn deviceOn, PictureDeviceOff deviceOff, PictureDeviceNoConnection deviceNoConnection,Label srf13000T,int i,string deviceNames,TabPage tabPage,Label tempT,Label tempMaxT)
        {
            InitializeComponent();
            deviceT.Channel = device.Channel;
            deviceT.Id = device.Id;
            _pct = pct;
            _deviceOn = deviceOn;
            _deviceoff = deviceOff;
            _deviceNoConnection = deviceNoConnection;
            _labelSRF13000T = srf13000T;
            _i = i;
            nameDevice = deviceNames;
            _page = tabPage;
            _tempT = tempT;
            _tempMaxT = tempMaxT;
            DataNow(port,device.Channel.ToString(),device.Id);
        }

        public void DataNow(SerialPort port,string devicesChannel, byte[] idDevices)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 0, 0, 0, 0, 0, idDevices[0], idDevices[1], idDevices[2], idDevices[3], 0, 172 };
            byte[] bufferCustomMaxTemp = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 31, 0, 0, 0, 0, idDevices[0], idDevices[1], idDevices[2], idDevices[3], 0, 172 };
            byte[] tx_buffer = deviceT.CRC(buffer);
            byte[] rx_buffer = new byte[17];
            byte[] tx_bufferCustomMaxTemp = deviceT.CRC(bufferCustomMaxTemp);
            byte[] rx_bufferCustomMaxTemp = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceT.WaitData(port, rx_buffer);//to do          
            port.DiscardInBuffer();
            port.Write(tx_bufferCustomMaxTemp, 0, tx_bufferCustomMaxTemp.Length);
            deviceT.WaitData(port, rx_bufferCustomMaxTemp);            
            if (port.IsOpen) port.Close();
            temp.Text = rx_buffer[10].ToString() + "C°";
            maxTemp.Text = rx_bufferCustomMaxTemp[7].ToString() + "C°";
            trackBarTemp.Value = rx_bufferCustomMaxTemp[7];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceT.Channel,2, 0, 0, 0, 0, 0, deviceT.Id[0], deviceT.Id[1], deviceT.Id[2], deviceT.Id[3], 0, 172 };         
            byte[] tx_buffer = deviceT.CRC(buffer);
            byte[] rx_buffer = new byte[17];         
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceT.WaitData(port, rx_buffer);
            if (port.IsOpen) port.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0, deviceT.Channel,0, 0, 0, 0, 0, 0, deviceT.Id[0], deviceT.Id[1], deviceT.Id[2], deviceT.Id[3], 0, 172 };
            byte[] tx_buffer = deviceT.CRC(buffer);
            byte[] rx_buffer = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceT.WaitData(port, rx_buffer);
            if (port.IsOpen) port.Close();
        }

        private void TrackBarTemp_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTemp(deviceT.Channel,deviceT.Id);
        }

        public void UpdateTemp(byte devicesChannel,byte[] idDevices)
        {
            byte[] buffer = new byte[17] { 171, 2, 8, 0,devicesChannel, 128, 0, 0, 0, 0, 0, idDevices[0], idDevices[1], idDevices[2], idDevices[3], 0, 172 };
            byte[] bufferCustomMaxTemp = new byte[17] { 171, 2, 8, 0, devicesChannel, 6, 31,byte.Parse(trackBarTemp.Value.ToString()), 0, 0, 0, idDevices[0], idDevices[1], idDevices[2], idDevices[3], 0, 172 };
            byte[] tx_buffer = deviceT.CRC(buffer);
            byte[] rx_buffer = new byte[17];
            byte[] tx_bufferCustomMaxTemp = deviceT.CRC(bufferCustomMaxTemp);
            byte[] rx_bufferCustomMaxTemp = new byte[17];
            if (port.IsOpen == false) port.Open();
            port.Write(tx_buffer, 0, tx_buffer.Length);
            deviceT.WaitData(port, rx_buffer);//to do          
            port.DiscardInBuffer();
            port.Write(tx_bufferCustomMaxTemp, 0, tx_bufferCustomMaxTemp.Length);
            deviceT.WaitData(port, rx_bufferCustomMaxTemp);
            if (port.IsOpen) port.Close();
            if (rx_buffer[2] == 0)
            {
                temp.Text = rx_buffer[10].ToString() + "C°";
            }
            if (rx_bufferCustomMaxTemp[2] == 0)
            {
                maxTemp.Text = trackBarTemp.Value.ToString() + "C°";
            }
            //if (int.Parse(temp.Text.TrimEnd('C','°'))>= int.Parse(maxTemp.Text.TrimEnd('C','°'))){
            //    button1.Enabled = false;
            //    button2.Enabled = false;
            //}
            //else
            //{
            //    button1.Enabled = true;
            //    button2.Enabled = true;
            //}
        }

        private void SettingSRF13000T_FormClosed(object sender, FormClosedEventArgs e)
        {
            string Id="";
            for (int i = 0; i < deviceT.Id.Length; i++)
            {
                Id += deviceT.Id[i].ToString() + "&";
            }
            string IdDevice = Id.TrimEnd('&');
            icons.StatusAllIcons(_pct, _deviceoff, _deviceOn, _deviceNoConnection, IdDevice, _labelSRF13000T);
            pictureSocket.CreateLabelForSRF13000T(_i,_pct,port, deviceT.Channel.ToString(),_deviceOn,_deviceoff,_deviceNoConnection, IdDevice, nameDevice, "6",_page , _labelSRF13000T, _tempT,_tempMaxT);
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
