using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public class DeviceTX
    {
        public string NameDevice { get; set; }
        public byte Channel { get; set; }
        public string TypeName { get; set; }
        public string Mode { get; set; }
        public string RoomName { get; set; }

        XmlDevice xmlDevice = new XmlDevice();
        readonly XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        Port portEx = new Port();

        public string[] ChannelCount()
        {
            string[] channel = new string[64];
            for (int i = 0; i < channel.Length; i++)
            {
                channel[i] = (i + 1).ToString();
            }
            return channel;
        }

        public byte[] CRC(byte[] tx_buffer)
        {
            long sum = 0;
            byte[] txcrc_buffer = new byte[17];
            for (int i = 0; i < tx_buffer.Length - 1; i++)
            {
                sum += tx_buffer[i];
            }
            Array.Copy(tx_buffer, txcrc_buffer, tx_buffer.Length);

            txcrc_buffer[15] = (byte)sum;
            return txcrc_buffer;
        }



        public void BindCommandTX(DeviceTX device)
        {
            using (SerialPort port = portEx.TakeDataAboutPort())
            {
                port.WriteTimeout = 500;
                try
                {

                    byte[] buffer = new byte[17] { 171, 0, 0, 0, device.Channel, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                    byte[] tx_buffer = device.CRC(buffer);

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
                }
                catch (Exception)
                {

                }
            }
        }
    }
}

