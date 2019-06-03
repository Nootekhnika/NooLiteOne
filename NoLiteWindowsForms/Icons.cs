using NooLiteServiceSoft.XML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NooLiteServiceSoft.IconClass
{
    public class Icons
    {
        const string DEVICEPATH = "devices.xml";
        const string DEVICEPATHTX= "devicesTX.xml";
        //SerialPort port = Port.TakeDataPort();
        XmlDevice xmlDevice = new XmlDevice();
        XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        XmlGroup xmlGroup = new XmlGroup();
        Device device = new Device();
        Label labelHeatingSRF13000T = new Label();
        readonly Label labelTemp = new Label
        {
            Height = 30,
            Width = 35,
            Top = 5,
            Left = 30
        };
        readonly Label labelTempMax = new Label
        {
            Height = 15,
            Width = 30,
            Top = 30,
            Left = 30,
            BackColor = Color.FromArgb(0,192,0),
            ForeColor = Color.White
        };


        public void IconAddallDevices(TabPage tabPage1)
        {
            tabPage1.Controls.Clear();
            int countDevices = 0;
            int positionTop = 0;
            int positionLeft = 0;

            SerialPort port = Port.TakeDataPort();

            string[] devicesName = xmlDevice.DeviceNameXml(DEVICEPATH);//Оптимизировать всё брать одним запросом  к файлу //TODO//Имена устройств
            string[] devicesChannel = new string[devicesName.Length];
            string[] devicesType = new string[devicesName.Length];
            string[] idDevices = new string[devicesName.Length];
            xmlDevice.DeviceElementsXml(devicesChannel, devicesType, idDevices);//каналы устройств
            string[] devicesNameTX = xmlDevice.DeviceNameXml(DEVICEPATHTX);
            string[] devicesChannelTX = new string[devicesNameTX.Length];
            string[] devicesTypeTX = new string[devicesNameTX.Length];
            xmlDevice.DeviceElementsXmlTX(devicesChannelTX, devicesTypeTX);

            for (int i = 0; i < devicesName.Count(); i++)
            {
                if (i != 0 && i % 7 == 0)
                {
                    positionTop++;
                    positionLeft = 0;
                }
                if (i <= devicesName.Count())
                {
                    PictureBox pct = new PictureBox();

                    PictureMain _pct = new PictureMain();
                    PictureSocket pictureSocket = new PictureSocket();
                    PictureDeviceOn _deviceOn = new PictureDeviceOn();
                    PictureDeviceNoConnection deviceNoConnection = new PictureDeviceNoConnection();
                    PictureDeviceOff deviceOff = new PictureDeviceOff();
                    LabelDeviceName deviceName = new LabelDeviceName();
                    LabelDeviceChannel deviceChannel = new LabelDeviceChannel();

                    pct = _pct.CreatePictureMain(i, port,pct, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i],devicesType[i],tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp,labelTempMax);                  
                    _deviceOn.CreatePictureDeviceOn(i, pct);
                    pictureSocket.CreatePictureSocket(i, pct, devicesType[i], port, devicesChannel[i], idDevices[i],labelTemp,labelTempMax);
                    deviceOff.CreateDeviceOff(i, pct);
                    deviceNoConnection.CreateDeviceNoConnection(i, pct);
                    deviceName.CreateLabelDeviceName(i, pct, devicesName);
                    deviceChannel.CreateLabelDeviceChannel(i, pct, devicesChannel);
                    if (devicesType[i].Equals("6"))
                    {
                        CreateLabelForSRF13000T(i,devicesType[i],pct);
                    }
                    StatusAllIcons(pct, deviceOff, _deviceOn, deviceNoConnection, idDevices[i],labelHeatingSRF13000T);

                    positionLeft++;
                    countDevices++;
                }
            }
            for (int i = 0; i < xmlDevice.DeviceCountXmlTX(); i++)
            {
                if (countDevices != 0 && countDevices % 7 == 0)
                {
                    positionTop++;
                    positionLeft = 0;
                }
                PictureBox pct = new PictureBox();

                PictureMainTX _pct = new PictureMainTX();
                LabelDeviceChannelTX deviceChannelTX = new LabelDeviceChannelTX();
                LabelDeviceNameTX deviceNameTX = new LabelDeviceNameTX();
                PictureDeviceTX pictureDeviceTX = new PictureDeviceTX();

                pct = _pct.CreatePictureMain(i, port, devicesChannelTX[i], devicesNameTX[i], tabPage1, positionTop, positionLeft, devicesTypeTX[i]);
                pictureDeviceTX.CreatePictureTX(i,pct, devicesTypeTX[i]);
                deviceNameTX.CreateLabelDeviceName(i, pct, devicesNameTX);
                deviceChannelTX.CreateLabelDeviceChannel(i, pct, devicesChannelTX);

                positionLeft++;
                countDevices++;
            }
        }


        public void IconsAddRoom(TabPage tabPage1)
        {

            tabPage1.Controls.Clear();
            int countDevices = 0;
            int positionTop = 0;
            int positionLeft = 0;

            SerialPort port = Port.TakeDataPort();
            string[] devicesName = xmlDevice.DeviceNameXmlInRoom(tabPage1.Text.Remove(0, 1), DEVICEPATH);//Оптимизировать всё брать одним запросом  к файлу //TODO
            string[] devicesChannel = new string[devicesName.Length];
            string[] devicesType = new string[devicesName.Length];
            string[] idDevices = new string[devicesName.Length];
            xmlDevice.DeviceElementsXml(devicesChannel, devicesType, idDevices,tabPage1.Text.Remove(0, 1));//каналы устройств
            string[] devicesNameTX = xmlDevice.DeviceNameXmlInRoom(tabPage1.Text.Remove(0, 1), DEVICEPATHTX);
            string[] devicesChannelTX = new string[devicesNameTX.Length];
            string[] devicesTypeTX = new string[devicesNameTX.Length];
            xmlDevice.DeviceElementsXmlRoomTX(devicesChannelTX, devicesTypeTX,tabPage1.Text.Remove(0, 1));

            for (int i = 0; i < devicesName.Count(); i++)
            {
                if (i != 0 && i % 7 == 0)
                {
                    positionTop++;
                    positionLeft = 0;
                }
                if (i <= devicesName.Count())
                {
                    PictureBox pct = new PictureBox();

                    PictureMain _pct = new PictureMain();
                    PictureSocket pictureSocket = new PictureSocket();
                    PictureDeviceOn _deviceOn = new PictureDeviceOn();
                    PictureDeviceNoConnection deviceNoConnection = new PictureDeviceNoConnection();
                    PictureDeviceOff deviceOff = new PictureDeviceOff();
                    LabelDeviceName deviceName = new LabelDeviceName();
                    LabelDeviceChannel deviceChannel = new LabelDeviceChannel();

                    pct = _pct.CreatePictureMain(i, port, pct,devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax);
                    _deviceOn.CreatePictureDeviceOn(i, pct);
                    pictureSocket.CreatePictureSocket(i, pct, devicesType[i],port,devicesChannel[i],idDevices[i],labelTemp,labelTempMax);
                    deviceOff.CreateDeviceOff(i, pct);
                    deviceNoConnection.CreateDeviceNoConnection(i, pct);
                    deviceName.CreateLabelDeviceName(i, pct, devicesName);
                    deviceChannel.CreateLabelDeviceChannel(i, pct, devicesChannel);
                    if (devicesType[i].Equals("6"))
                    {
                        CreateLabelForSRF13000T(i, devicesType[i], pct);
                    }
                    StatusAllIcons(pct, deviceOff, _deviceOn, deviceNoConnection, idDevices[i],labelHeatingSRF13000T);

                    positionLeft++;
                    countDevices++;
                }
            }
            for (int i = 0; i < devicesNameTX.Count(); i++)
            {
                if (countDevices != 0 && countDevices % 7 == 0)
                {
                    positionTop++;
                    positionLeft = 0;
                }
                PictureBox pct = new PictureBox();

                PictureMainTX _pct = new PictureMainTX();
                LabelDeviceChannelTX deviceChannelTX = new LabelDeviceChannelTX();
                LabelDeviceNameTX deviceNameTX = new LabelDeviceNameTX();
                PictureDeviceTX pictureDeviceTX = new PictureDeviceTX();

                pct = _pct.CreatePictureMain(i, port, devicesChannelTX[i], devicesNameTX[i], tabPage1, positionTop, positionLeft,devicesTypeTX[i]);
                deviceNameTX.CreateLabelDeviceName(i, pct, devicesNameTX);
                deviceChannelTX.CreateLabelDeviceChannel(i, pct, devicesChannelTX);
                pictureDeviceTX.CreatePictureTX(i,pct,devicesTypeTX[i]);

                positionLeft++;
                countDevices++;
            }
        }
            public void StatusMtrf(Label label)
        {
            using (SerialPort port = Port.TakeDataPort())
            {

                
                    port.ReadTimeout = 3000;
                    port.WriteTimeout = 500;



                    byte[] buffer = new byte[17] { 171, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 172 };
                    byte[] rx_buffer = new byte[17];
                    if (port.IsOpen == false)
                    {
                        port.Open();
                    }
                    port.Write(buffer, 0, buffer.Length);
                    device.WaitData(port, rx_buffer);
                    if (rx_buffer != null)
                    {
                        label.Text = xmlTypeDevice.TypeDeviceNameXml(rx_buffer[7]) + $" (V{rx_buffer[8]}): Подключено";
                    }
                
              
            }
        }

        public void StatusAllIcons(PictureBox pictureBox,PictureDeviceOff off, PictureDeviceOn on, PictureDeviceNoConnection noConnection, string idDevices,Label heatingSRF13000T)
        {

            using (SerialPort port = Port.TakeDataPort())
            {


                string[] idArray = idDevices.Split('&');

                byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 9, 0, 0, 128, 0, 170, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] tx_bufferMainPropertiesFirstWrite = device.CRC(bufferMainPropertiesFirstWrite);             
                byte[] rx_bufferMainPropertiesFirstRequest = new byte[17];
               
                if (port.IsOpen == false) port.Open();
                port.Write(tx_bufferMainPropertiesFirstWrite, 0, tx_bufferMainPropertiesFirstWrite.Length);//БАГ              
                device.WaitData(port, rx_bufferMainPropertiesFirstRequest);

                if (port.IsOpen) port.Close();
                if (rx_bufferMainPropertiesFirstRequest[2] == 1)
                {
                    noConnection.VisibleTrue();
                    off.VisibleFalse();
                    on.VisibleFalse();
                }
                else
                {
                    if (rx_bufferMainPropertiesFirstRequest[9] == 1)
                    {
                        on.VisibleTrue();
                        off.VisibleFalse();
                        noConnection.VisibleFalse();
                    }
                    else
                    {
                        on.VisibleFalse();
                        off.VisibleTrue();
                        noConnection.VisibleFalse();
                    }

                    if (rx_bufferMainPropertiesFirstRequest[7] == 6)
                    {
                        char[] a = device.Binary(rx_bufferMainPropertiesFirstRequest[9]);
                        int[] resultchar = new int[7];
                        for (int i = 0; i < a.Length; i++)
                        {
                            resultchar[i] = int.Parse(a[i].ToString());
                        }
                        for (int i = a.Length; i < resultchar.Length; i++)
                        {
                            resultchar[i] = 0;
                        }

                        
                        
                        if (int.Parse(resultchar[0].ToString()) == 1)
                        {
                            on.VisibleTrue();
                            off.VisibleFalse();
                            noConnection.VisibleFalse();

                            if (int.Parse(resultchar[4].ToString()) == 1)
                            {
                                heatingSRF13000T.Text = "Нагрев вкл";
                            }
                            else
                            {
                                heatingSRF13000T.Text = "Нагрев выкл";
                            }
                        }
                        else
                        {
                            on.VisibleFalse();
                            off.VisibleTrue();
                            noConnection.VisibleFalse();
                            heatingSRF13000T.Text = "Нагрев выкл";                         
                        }

                    }
                }
            }
        }

        private void CreateLabelForSRF13000T(int i,string devicesType,PictureBox pct)
        {           
                labelHeatingSRF13000T.Height = 20;
                labelHeatingSRF13000T.Width = 120;
                labelHeatingSRF13000T.Top = 50;
                labelHeatingSRF13000T.Left = 15;
                pct.Controls.Add(labelHeatingSRF13000T);           
        }

        public void AddRooms( TabControl tabControl)
        {
            string[] RoomName = xmlGroup.RoomNameXml();
            if (RoomName != null)
            {
                for (int i = 0; i < RoomName.Length; i++)
                {
                    TabPage page = new TabPage(" " + RoomName[i])
                    {
                        BackColor = Color.White
                    };
                    page.Enter += delegate (object sender, EventArgs e) { IconsAddRoom(page); };
                    page.MouseUp += delegate (object sender, MouseEventArgs e) { Btn_RightClickRoom(sender, e, page.Text.Remove(0,1), tabControl,page); };
                    tabControl.Controls.Add(page);
                }
            }
        }
        
        public void UpdateRooms(TabControl tab,TextBox textBox)
        {
            if (textBox.Text.Length>0)
            {
                TabPage page = new TabPage("  " + textBox.Text)
                {
                    BackColor = Color.White
                };
                page.Enter += delegate (object sender, EventArgs e) { IconsAddRoom(page); };
                page.MouseUp += delegate (object sender, MouseEventArgs e) { Btn_RightClickRoom(sender, e, page.Text.Remove(0,2), tab, page); };
                tab.Controls.Add(page);
            }
        }      

        private void Btn_RightClickRoom(object sender, MouseEventArgs e,string roomName, TabControl tabControl,TabPage page)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem();
                context.Items.AddRange(new ToolStripMenuItem[] { menuItem1, menuItem2, menuItem3 });
                menuItem1.Text = "Обновить устройства";
                menuItem2.Text = "Редактировать группу";
                menuItem3.Text = "Удалить группу";
                //menuItem1.Click += delegate (object _sender, EventArgs _e) { MenuItem1_ClickRemove(_sender, _e); };
                //menuItem2.Click += delegate (object _sender, EventArgs _e) { MenuItem2_ClickProperty(_sender, _e, port, devicesChannel, idDevices, pct, devicesName, deviceType); };
                menuItem3.Click += delegate (object _sender, EventArgs _e) { MenuItem3_ClickRemove(_sender, _e, roomName, tabControl, page); };
                context.Show(Cursor.Position);
            }
        }

        private void MenuItem3_ClickRemove(object _sender, EventArgs _e,string roomName, TabControl tabControl, TabPage page)
        {                     
            tabControl.TabPages.Remove(page);           
            xmlGroup.RemoveRoom(roomName);
        }
    }
}

