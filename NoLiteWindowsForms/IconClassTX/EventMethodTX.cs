using NooLiteServiceSoft.IconClass;
using NooLiteServiceSoft.Settings;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClassTX
{
    public class EventMethodTX:DeviceTX
    {
        readonly XmlDevice xmlDevice = new XmlDevice();
        readonly XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        Icons icons = new Icons();


        public void DbClick_Connection(object sender, MouseEventArgs e, SerialPort port, string devicesChannel)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    byte[] buffer = new byte[17] { 171, 0, 0, 0, byte.Parse(devicesChannel), 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                    byte[] tx_buffer = CRC(buffer);
                    byte[] rx_buffer = new byte[17];
                    if (port.IsOpen == false) port.Open();
                    port.Write(tx_buffer, 0, tx_buffer.Length);
                    if (port.IsOpen) port.Close();
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

        public void Btn_MouseUp(object sender, MouseEventArgs e, SerialPort port, string devicesChannel, PictureBox pct, string devicesName, TabPage tabPage,TabControl tabControl)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip context = new ContextMenuStrip();
                    ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
                    context.Items.AddRange(new ToolStripMenuItem[] { menuItem1 });
                    menuItem1.Text = "Отвязать";
                    menuItem1.Click += delegate (object _sender, EventArgs _e) { MenuItem1_ClickRemove(_sender, _e, port, devicesChannel, pct, devicesName, tabPage, tabControl); };
                    context.Show(Cursor.Position);
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

        public void MenuItem1_ClickRemove(object _sender, EventArgs _e, SerialPort port, string devicesChannel, PictureBox pct, string devicesName, TabPage tabPage,TabControl tabControl)
        {
            try
            {        
                byte[] bufferRemove = new byte[17] { 171, 0, 0, 0, byte.Parse(devicesChannel), 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
                byte[] tx_bufferRemove = CRC(bufferRemove);
                if (port.IsOpen == false)
                {
                    port.Open();
                }
                port.Write(tx_bufferRemove, 0, tx_bufferRemove.Length);

                xmlDevice.DeviceRemoveXmlTX(devicesChannel);
                pct.Dispose();

                if (port.IsOpen)
                {
                    port.Close();
                }
                if (tabPage.Text.Equals("Все")) { icons.IconAddallDevices(tabControl, tabPage); }
                else { icons.IconsAddRoom(tabPage, tabControl); }
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

        public void MenuItemRGB_Setting(object _sender, MouseEventArgs e, SerialPort port, string devicesChannel, string devicesName)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    DeviceTX device = new DeviceTX
                    {
                        NameDevice = devicesName,
                        Channel = byte.Parse(devicesChannel),
                    };

                    using (SettingRGB fm = new SettingRGB(device))
                    {
                        fm.ShowDialog();
                    }
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
