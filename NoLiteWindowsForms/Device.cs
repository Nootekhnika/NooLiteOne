using NooLiteServiceSoft.IconClass;
using NooLiteServiceSoft.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NooLiteServiceSoft
{
    public class Device
    {
        public byte[] Id { get; set; } = new byte[4];
        public string NameDevice { get; set; }
        public byte Channel { get; set; }
        public int TypeCode { get; set; }
        public string Mode { get; set; }
        public string RoomName { get; set; }

        XmlDevice xmlDevice = new XmlDevice();
        readonly XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        Port portEx = new Port();

        //int debugId=0;

        public string[] ChannelCount()
        {
            string[] channel = new string[64];
            for (int i = 0; i < channel.Length; i++)
            {
                channel[i] = (i + 1).ToString();
            }
            return channel;
        }

        public string[] ModeServ()
        {
            string[] modeserv = new string[] { "NooLite F-TX", "NooLite TX" };
            return modeserv;
        }

        public string[] TypeDevicesTX()
        {
            string[] typeDevicesTx = new string[] { "Реле", "Диммер","Светодиодный контроллер"};
            return typeDevicesTx;
        }

        public byte[] CRC(byte[] tx_buffer)
        {
            long sum = 0;
            byte[] txcrc_buffer = new byte[tx_buffer.Length];
            for (int i = 0; i < tx_buffer.Length - 1; i++)
            {
                sum += tx_buffer[i];
            }
            Array.Copy(tx_buffer, txcrc_buffer, tx_buffer.Length);

            txcrc_buffer[tx_buffer.Length-2] = (byte)sum;
            return txcrc_buffer;
        }
       

        public void BindCommandFTX(Device device)
        {
            //BIND COMMAND           
            using (SerialPort port = portEx.TakeDataAboutPort())
            {

                port.ReadTimeout = 3000;
                port.WriteTimeout = 500;
                try
                {
                    byte[] buffer = new byte[17] { 171, 2, 0, 0, device.Channel, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                    byte[] tx_buffer = device.CRC(buffer);
                    byte[] rx_buffer = new byte[17];
                    string[] deviceId = new string[4];
                    try
                    {
                        if (port.IsOpen == false)
                        {
                            port.Open();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Проблемы с открытием порта");
                    }
                    port.Write(tx_buffer, 0, tx_buffer.Length);
                    WaitData(port, rx_buffer);
                    for (int i = 0; i < 4; i++)
                    {
                        device.Id[i] = rx_buffer[11 + i];
                        deviceId[i] += device.Id[i];
                    }
                    device.TypeCode = rx_buffer[7];
                    if (xmlDevice.ValidationBindXML(deviceId, device.Channel))
                    {
                    }
                    else
                    {
                        if (rx_buffer[2] == 3)
                        {
                            try
                            {
                                xmlDevice.LoadXMLFile(device);                               
                            }
                            catch (IOException)
                            {
                                xmlDevice.CreateXmlFile(device);                               
                            }
                        }

                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public void WaitData(SerialPort port, byte[] read)
        {
            int count = 0;
            port.ReadTimeout = 3000;

            try
            {
                while (count < read.Length)
                {

                    count += port.Read(read, count, read.Length - count);

                }
            }
            catch (TimeoutException)
            {
               // MessageBox.Show("Ответ не пришёл");
            }
        }

        public char[] Binary(byte x)
        {
            int k = Convert.ToInt32(x);
            string g = Convert.ToString(k, 2);
            char[] a = g.ToCharArray();
            Array.Reverse(a);
            return a;
        }

         public byte[] DeviceSettings(SerialPort port, string devicesChannel, byte typeCode, byte[] idArray)
        {
            byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 16, 0, 0, 0, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
            byte[] rx_bufferSettingRequest = new byte[17];

            if (port.IsOpen == false) port.Open();
            port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
            WaitData(port, rx_bufferSettingRequest);
            port.DiscardInBuffer();
            if (port.IsOpen) port.Close();

            string stringByte = Convert.ToString(rx_bufferSettingRequest[7], 2);

            byte[] arrayByte = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
            int count = stringByte.Length - 1;
            foreach (var b in stringByte)
            {
                arrayByte[count] = byte.Parse(b.ToString());
                count--;
            }
            return arrayByte;
        }
    }
}