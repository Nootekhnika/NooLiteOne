﻿using NooLiteServiceSoft.DeviceProperties;
using NooLiteServiceSoft.Settings;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class EventMethod: Device
    {
        readonly XmlDevice xmlDevice = new XmlDevice();
        readonly XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        UpdateFW.UpdateDeviceFW update = new UpdateFW.UpdateDeviceFW();
        Icons icons = new Icons();

        public void MenuItemSRF13000T_Setting(object _sender, MouseEventArgs e, SerialPort port, PictureBox pct, string devicesChannel, string devicesName, string idDevices, PictureDeviceOn _deviceOn, PictureDeviceOff deviceOff, PictureDeviceNoConnection deviceNoConnection, Label srf13000T, int i, Label tempT, Label tempMaxT,TabPage tabPage,TabControl tabControl)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    string[] idArray = idDevices.Split('&');
                    byte[] idArrayByte = new byte[idArray.Length];
                    for (int j = 0; j < idArray.Length; j++)
                    {
                        idArrayByte[j] = byte.Parse(idArray[j]);
                    }
                    Device device = new Device
                    {
                        NameDevice = devicesName,
                        Channel = byte.Parse(devicesChannel),
                        Id = idArrayByte
                    };

                    byte[] buffer = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                    byte[] tx_buffer = CRC(buffer);
                    byte[] rx_buffer = new byte[17];
                    if (port.IsOpen == false) port.Open();
                    port.Write(tx_buffer, 0, tx_buffer.Length);
                    WaitData(port, rx_buffer);//to do          

                    if (port.IsOpen) port.Close();
                    char[] a = Binary(rx_buffer[9]);
                    if (rx_buffer[2] == 1)
                    {

                        deviceNoConnection.VisibleTrue();
                        _deviceOn.VisibleFalse();
                        deviceOff.VisibleFalse();
                    }
                    else
                    {
                        if (rx_buffer[3] == 0)
                        {
                            if (int.Parse(a[0].ToString()) == 1)
                            {
                                _deviceOn.VisibleTrue();
                                deviceOff.VisibleFalse();
                                deviceNoConnection.VisibleFalse();
                            }
                            else
                            {
                                _deviceOn.VisibleFalse();
                                deviceOff.VisibleTrue();
                                deviceNoConnection.VisibleFalse();
                            }
                            using (SettingSRF13000T fm = new SettingSRF13000T(device, pct, _deviceOn, deviceOff, deviceNoConnection, srf13000T, i, devicesName, tabPage, tempT, tempMaxT, tabControl))
                            {
                                fm.ShowDialog();
                            }
                        }
                        else
                        {
                            if (rx_buffer[3] == 2)
                            {
                                _deviceOn.VisibleFalse();
                                deviceNoConnection.VisibleTrue();
                            }
                        }
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

        public void ShowSuf13000Window(SerialPort port, string devicesChannel, string idDevices)
        {
            using (SetttingSUF1300 settingSUF13000 = new SetttingSUF1300(port, devicesChannel, idDevices))
            {
                settingSUF13000.ShowDialog();
            }
        }


        public void MenuItemSRF11000R_Setting(object _sender, MouseEventArgs e, SerialPort port, PictureBox pct, string devicesChannel, string devicesName, string idDevices, PictureDeviceOn _deviceOn, PictureDeviceOff deviceOff, PictureDeviceNoConnection deviceNoConnection, int i)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    string[] idArray = idDevices.Split('&');
                    byte[] idArrayByte = new byte[idArray.Length];
                    for (int j = 0; j < idArray.Length; j++)
                    {
                        idArrayByte[j] = byte.Parse(idArray[j]);
                    }
                    Device device = new Device
                    {
                        NameDevice = devicesName,
                        Channel = byte.Parse(devicesChannel),
                        Id = idArrayByte
                    };

                    byte[] buffer = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                    byte[] tx_buffer = CRC(buffer);
                    byte[] rx_buffer = new byte[17];
                    if (port.IsOpen == false) port.Open();
                    port.Write(tx_buffer, 0, tx_buffer.Length);
                    WaitData(port, rx_buffer);//to do          

                    if (port.IsOpen) port.Close();
                    char[] a = Binary(rx_buffer[9]);
                    if (rx_buffer[2] == 1)
                    {

                        deviceNoConnection.VisibleTrue();
                        _deviceOn.VisibleFalse();
                        deviceOff.VisibleFalse();
                    }
                    else
                    {
                        if (rx_buffer[3] == 0)
                        {
                            if (int.Parse(a[0].ToString()) == 1)
                            {
                                _deviceOn.VisibleTrue();
                                deviceOff.VisibleFalse();
                                deviceNoConnection.VisibleFalse();
                            }
                            else
                            {
                                _deviceOn.VisibleFalse();
                                deviceOff.VisibleTrue();
                                deviceNoConnection.VisibleFalse();
                            }
                            using (SettingSRF11000R fm = new SettingSRF11000R(device))
                            {
                                fm.ShowDialog();
                            }
                        }
                        else
                        {
                            if (rx_buffer[3] == 2)
                            {
                                _deviceOn.VisibleFalse();
                                deviceNoConnection.VisibleTrue();
                            }
                        }
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

        public void DbClick_Connection(object sender, MouseEventArgs e, SerialPort port, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff deviceOff, PictureDeviceNoConnection deviceNoConnection, string idDevices)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (deviceNoConnection.StatusIcon() == false)
                    {
                        string[] idArray = idDevices.Split('&');
                        byte[] buffer = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 4, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                        byte[] tx_buffer = CRC(buffer);
                        byte[] rx_buffer = new byte[17];
                        WriteData(port, tx_buffer);
                        WaitData(port, rx_buffer);
                        if (rx_buffer[2] == 1)
                        {

                            deviceNoConnection.VisibleTrue();
                            _deviceOn.VisibleFalse();
                            deviceOff.VisibleFalse();

                        }
                        else
                        {
                            if (rx_buffer[3] == 0)
                            {
                                if (rx_buffer[9] == 1)
                                {
                                    _deviceOn.VisibleTrue();
                                    deviceOff.VisibleFalse();
                                    deviceNoConnection.VisibleFalse();

                                }
                                if (rx_buffer[9] == 0)
                                {
                                    _deviceOn.VisibleFalse();
                                    deviceOff.VisibleTrue();
                                    deviceNoConnection.VisibleFalse();

                                }
                            }
                            else
                            {
                                if (rx_buffer[3] == 2)
                                {
                                    _deviceOn.VisibleFalse();
                                    deviceNoConnection.VisibleTrue();
                                }
                            }
                        }
                        if (port.IsOpen) { port.Close(); }
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

        public void Btn_MouseUp(object sender, MouseEventArgs e, SerialPort port, PictureBox pictureBox, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string devicesChannel, string idDevices, PictureBox pct, string devicesName, string deviceType, TabPage tabPage, Label srf13000T,TabControl tabControl)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (deviceNoConnection.StatusIcon() == false)
                {
                    ContextMenuStrip context = new ContextMenuStrip();
                    ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
                    ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
                    ToolStripMenuItem menuItem3 = new ToolStripMenuItem();
                    ToolStripMenuItem menuItem4 = new ToolStripMenuItem();
                    context.Items.AddRange(new ToolStripMenuItem[] { menuItem1, menuItem2, menuItem3, menuItem4 });
                    menuItem1.Text = "Настройка";
                    menuItem2.Text = "Свойства";
                    menuItem3.Text = "Обновление прошивки";
                    menuItem4.Text = "Отвязать";
                    menuItem1.Click += delegate (object _sender, EventArgs _e) { MenuItem3_Setting(_sender, _e, port, devicesChannel, idDevices, pct, devicesName); };
                    menuItem2.Click += delegate (object _sender, EventArgs _e) { MenuItem2_ClickProperty(_sender, _e, port, devicesChannel, idDevices, pct, devicesName, deviceType); };
                    menuItem3.Click += delegate (object _sender, EventArgs _e) { MenuItem4_UpdateFirmware(_sender, _e, port, devicesChannel, idDevices, deviceType); };
                    menuItem4.Click += delegate (object _sender, EventArgs _e) { MenuItem1_ClickRemove(_sender, _e, port, devicesChannel, idDevices, pct, devicesName, tabPage, tabControl); };
                    context.Show(Cursor.Position);
                }
                else
                {
                    ContextMenuStrip context = new ContextMenuStrip();
                    ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
                    ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
                    ToolStripMenuItem menuItem3 = new ToolStripMenuItem();
                    context.Items.AddRange(new ToolStripMenuItem[] { menuItem1, menuItem2, menuItem3 });
                    menuItem1.Text = "Обновить состояние";
                    menuItem2.Text = "Обновление прошивки";
                    menuItem3.Text = "Отвязать";
                    menuItem1.Click += delegate (object _sender, EventArgs _e) { icons.StatusAllIcons(pictureBox, _deviceoff, _deviceOn, deviceNoConnection, idDevices, srf13000T); };
                    menuItem2.Click += delegate (object _sender, EventArgs _e) { MenuItem4_UpdateFirmware(_sender, _e, port, devicesChannel, idDevices, deviceType); };
                    menuItem3.Click += delegate (object _sender, EventArgs _e) { MenuItem1_ClickRemove(_sender, _e, port, devicesChannel, idDevices, pct, devicesName, tabPage, tabControl); };
                    context.Show(Cursor.Position);
                }
            }
        }

        public void MenuItem1_ClickRemove(object _sender, EventArgs _e, SerialPort port, string devicesChannel, string idDevices, PictureBox pct, string devicesName, TabPage tabPage,TabControl tabControl)
        {
                string[] idArray = idDevices.Split('&');
                byte[] bufferService = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 131, 0, 1, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] bufferRemove = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 9, 0, 1, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] tx_bufferService = CRC(bufferService);
                byte[] tx_bufferRemove = CRC(bufferRemove);
                byte[] rx_buffer = new byte[17];               
                WriteData(port, tx_bufferService);
                Thread.Sleep(500);
                port.Write(tx_bufferRemove, 0, tx_bufferRemove.Length);
                WaitData(port, rx_buffer);
                if (rx_buffer[3] == 0)
                {
                    xmlDevice.DeviceRemoveXml(idArray, devicesChannel);
                    pct.Dispose();
                }
                if (port.IsOpen) port.Close();
                if (tabPage.Text.Equals("Все")) { icons.IconAddallDevices(tabControl, tabPage); }
                else { icons.IconsAddRoom(tabPage, tabControl); }        
        }

        public void MenuItem2_ClickProperty(object _sender, EventArgs _e, SerialPort port, string devicesChannel, string idDevices, PictureBox pct, string devicesName, string deviceType)
        {
            try
            {
                string[] idArray = idDevices.Split('&');
                string status;
                byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 0, 170, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] bufferMainPropertiesSecondWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 2, 170, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] tx_bufferMainPropertiesFirstWrite = CRC(bufferMainPropertiesFirstWrite);
                byte[] tx_bufferMainPropertiresSecondWrite = CRC(bufferMainPropertiesSecondWrite);
                byte[] rx_bufferMainPropertiesFirstRequest = new byte[17];
                byte[] rx_bufferMainPropertiesSecondRequest = new byte[17];
                byte[] rx_bufferActiveChannel = new byte[17];//для активного канала в SRF-10-1000
                WriteData(port, tx_bufferMainPropertiesFirstWrite);
                WaitData(port, rx_bufferMainPropertiesFirstRequest);
                port.DiscardInBuffer();
                port.Write(tx_bufferMainPropertiresSecondWrite, 0, tx_bufferMainPropertiresSecondWrite.Length);
                WaitData(port, rx_bufferMainPropertiesSecondRequest);
                if (deviceType.Equals("2"))
                {
                    byte[] bufferActiveChannel = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 1, 170, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                    byte[] tx_bufferActiveChannel = CRC(bufferActiveChannel);
                    port.Write(tx_bufferActiveChannel, 0, tx_bufferActiveChannel.Length);
                    WaitData(port, rx_bufferActiveChannel);
                }

                if (port.IsOpen) port.Close();
                if (rx_bufferMainPropertiesFirstRequest[9] == 1 || rx_bufferMainPropertiesFirstRequest[9] == 17)// Состояние SRF-1-3000-T
                {
                    status = "ВКЛ";
                }
                else
                {
                    status = "ВЫКЛ";
                }
                using (DeviceProperty deviceProperty = new DeviceProperty(rx_bufferMainPropertiesFirstRequest, rx_bufferMainPropertiesSecondRequest, rx_bufferActiveChannel, status))
                {
                    deviceProperty.ShowDialog();
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


        public void MenuItem3_Setting(object _sender, EventArgs _e, SerialPort port, string devicesChannel, string idDevices, PictureBox pct, string devicesName)
        {
            try
            {
                string[] idArray = idDevices.Split('&');
                int count = 0;

                Device device = new Device
                {
                    NameDevice = devicesName,
                    Channel = byte.Parse(devicesChannel),
                };

                foreach (var d in idArray)
                {
                    device.Id[count] = byte.Parse(d);
                    count++;
                }

                byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 0, 170, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] tx_bufferMainPropertiesFirstWrite = device.CRC(bufferMainPropertiesFirstWrite);
                byte[] rx_bufferMainPropertiesFirstRequest = new byte[17];
                WriteData(port, tx_bufferMainPropertiesFirstWrite);
                WaitData(port, rx_bufferMainPropertiesFirstRequest);
                if (port.IsOpen == true) port.Close();
                device.TypeCode = rx_bufferMainPropertiesFirstRequest[7];
                using (SettingFTX fm = new SettingFTX(device))
                {
                    fm.ShowDialog();
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

        public void MenuItem4_UpdateFirmware(object _sender, EventArgs _e, SerialPort port, string devicesChannel, string idDevices, string deviceType)
        {

            update.PreUpdateFW(port, devicesChannel, idDevices, deviceType);
        }
    }
}

