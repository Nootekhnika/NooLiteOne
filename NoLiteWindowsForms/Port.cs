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
    public class Port
    {
        XmlPort xmlPort = new XmlPort();

        List<string> channel = new List<string>();
        List<string> typeDevice = new List<string>();
        List<string> IdDevice = new List<string>();

        internal void CreatePort(bool flag)
        {

            string[] ports = SerialPort.GetPortNames();
            int baudRate = 9600;
            if (File.Exists("port.xml") == true)
            {
                baudRate = xmlPort.BaudRate();
            }
            if (ports != null)
            {
                foreach (var p in ports)
                {
                    using (SerialPort port = new SerialPort(p, baudRate, Parity.None, 8, StopBits.One))
                    {
                        port.ReadTimeout = 3000;
                        port.WriteTimeout = 500;

                        byte[] buffer = new byte[17] { 171, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 172 };
                        byte[] rx_buffer = new byte[17];
                        if (port.IsOpen == false)
                        {
                            try
                            {
                                port.Open();
                            }
                            catch
                            {

                            }
                        }
                        port.Write(buffer, 0, buffer.Length);
                        Thread.Sleep(500);
                        try
                        {
                            port.Read(rx_buffer, 0, rx_buffer.Length);
                        }
                        catch
                        {

                            if (port.IsOpen == true) port.Close();
                        }
                        if (rx_buffer[8] != 0)// to do
                        {
                            byte[] idPort = new byte[] { rx_buffer[11], rx_buffer[12], rx_buffer[13], rx_buffer[14] };
                            if (port.IsOpen == true) port.Close();

                            if (flag == true)
                            {
                                xmlPort.CreateXmlFile(port, idPort);
                            }
                            else
                            {
                                xmlPort.UpdatePortName(port, idPort);
                            }
                            //return port;
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Вставте USB-передатчик в один из портов вашего компьютера");
            }
        }




        public SerialPort TakeDataAboutPort()
        {
            string portName = xmlPort.PortNameXml();
            int baudRate = 9600;
            if (File.Exists("port.xml") == true)
            {
                baudRate = xmlPort.BaudRate();
            }
            using (SerialPort port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One))
            {
                return port;
            }
        }

        public static SerialPort TakeDataPort()
        {
            try
            {

                XDocument xdoc = XDocument.Load("port.xml");
                var roomElements = from el in xdoc.Root.Elements("port")
                                   select new
                                   {
                                       dName = el.Attribute("name")
                                   };
                foreach (var param in roomElements)
                {
                    using (SerialPort port = new SerialPort((string)param.dName, 9600, Parity.None, 8, StopBits.One))
                    {
                        return port;
                    }
                }
            }
            catch (IOException)
            {
                //MessageBox.Show("Ни одной комнаты не добавлено");
            }
            return null;

        }

        public void ValidationPortId(Port port, string[] portOldId)
        {
            XmlPort xmlPort = new XmlPort();
            XmlDevice xmlDevice = new XmlDevice();
            Device device = new Device();
            string[] idPortArray = xmlPort.PortIdXml();
            bool flag = true;
            if (EqualsPortId(portOldId, idPortArray) != true)
            {
                MainValidationFunc(port,flag);
            }
            for (int i = 0; i < IdDevice.Count; i++)
            {
                xmlDevice.LoadDeviceinXMLFile(channel[i], IdDevice[i], typeDevice[i]);
            }
        }

        public void ValidationPortId(Port port)
        {
            XmlPort xmlPort = new XmlPort();
            XmlDevice xmlDevice = new XmlDevice();
            Device device = new Device();
            string[] idPortArray = xmlPort.PortIdXml();
            bool flag = true;
            MainValidationFunc(port, flag);
            for (int i = 0; i < IdDevice.Count; i++)
            {
                xmlDevice.LoadDeviceinXMLFile(channel[i], IdDevice[i], typeDevice[i]);
            }
        }

        public bool EqualsPortId(string[] IdArrayOld, string[] idArray)
        {
            bool flag = true;

            for (int i = 0; i < 4; i++)
            {
                if (IdArrayOld[i].ToString().Equals(idArray[i]))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                if (flag == false) return false;
            }
            return true;
        }

        private void MainValidationFunc(Port port, bool flag)
        {

            XmlDevice xmlDevice = new XmlDevice();
            Device device = new Device();


            xmlDevice.DeviceRemoveAllXml();
            using (SerialPort _port = port.TakeDataAboutPort())
            {
                _port.ReadTimeout = 3000;
                _port.WriteTimeout = 500;
                for (int i = 0; i < 64; i++)
                {

                    byte[] buffer = new byte[17] { 171, 2, 0, 0, (byte)i, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                    byte[] tx_buffer = device.CRC(buffer);
                    byte[] rx_buffer = new byte[17];
                    if (_port.IsOpen == false) _port.Open();
                    _port.Write(tx_buffer, 0, tx_buffer.Length);
                    while (flag == true)
                    {
                        device.WaitData(_port, rx_buffer);
                        if (rx_buffer[0] == 173 && rx_buffer[2] == 0 || rx_buffer[2] == 1)
                        {
                            channel.Add(i.ToString());
                            typeDevice.Add(rx_buffer[7].ToString());
                            IdDevice.Add(rx_buffer[11] + "/" + rx_buffer[12] + "/" + rx_buffer[13] + "/" + rx_buffer[14]);
                            if (rx_buffer[3] == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }


                }
                _port.Close();
            }          
        }

    }
}


