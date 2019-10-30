using NooLiteServiceSoft.IconClassTX;
using NooLiteServiceSoft.XML;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class Icons
    {
        const string DEVICEPATH = "devices.xml";
        const string DEVICEPATHTX= "devicesTX.xml";
        XmlDevice xmlDevice = new XmlDevice();
        XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        XmlGroup xmlGroup = new XmlGroup();
        Device device = new Device();
        OperationWithMainForm operationWithMainForm = new OperationWithMainForm();



        public void IconAddallDevices(TabControl tabControl, TabPage tabPage1)
        {
            SerialPort port = Port.TakeDataPort();
            Cursor.Current = Cursors.WaitCursor;
            tabPage1.Controls.Clear();
            int countDevices = 0;
            int positionTop = 0;
            int positionLeft = 0;
            string[] devicesName = xmlDevice.DeviceNameXml(DEVICEPATH);//Оптимизировать всё брать одним запросом  к файлу //TODO//Имена устройств
            string[] devicesChannel = new string[devicesName.Length];
            string[] devicesType = new string[devicesName.Length];
            string[] idDevices = new string[devicesName.Length];
            string[] roomName = new string[devicesName.Length];
            xmlDevice.DeviceElementsXml(devicesChannel, devicesType, idDevices, roomName);//каналы устройств
            string[] devicesNameTX = xmlDevice.DeviceNameXml(DEVICEPATHTX);
            string[] devicesChannelTX = new string[devicesNameTX.Length];
            string[] devicesTypeTX = new string[devicesNameTX.Length];
            string[] roomNameTX = new string[devicesNameTX.Length];
            xmlDevice.DeviceElementsXmlTX(devicesChannelTX, devicesTypeTX, roomNameTX);// не забыть сделать

            for (int i = 0; i < devicesName.Count(); i++)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (i != 0 && i % 7 == 0)
                {
                    positionTop++;
                    positionLeft = 0;
                }
                if (i <= devicesName.Count())
                {
                    PictureBox pct = new PictureBox();
                    PictureSocket pictureSocket = new PictureSocket();
                    PictureDeviceOn _deviceOn = new PictureDeviceOn();
                    PictureDeviceNoConnection deviceNoConnection = new PictureDeviceNoConnection();
                    PictureDeviceOff deviceOff = new PictureDeviceOff();
                    LabelRoomName labelRoomName = new LabelRoomName();
                    LabelDeviceName deviceName = new LabelDeviceName();
                    LabelDeviceChannel deviceChannel = new LabelDeviceChannel();
                    PictureMain _pct = new PictureMain();
                    Label labelTemp = new Label
                    {
                        Name = "labelTempName",
                        Height = 20,
                        Width = 35,
                        Top = 5,
                        Left = 32
                    };
                    Label labelTempMax = new Label
                    {
                        Name = "labelTempMaxName",
                        Height = 17,
                        Width = 34,
                        Top = 25,
                        Left = 32,
                        BackColor = Color.FromArgb(0, 192, 0),
                        ForeColor = Color.White,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Padding = new Padding(0, 0, 0, 1)
                    };

                    Label labelHeatingSRF13000T = new Label()
                    {
                        Name = "labelHeating"
                    };

                    pct = _pct.CreatePictureMain(i, port, pct, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    _deviceOn.CreatePictureDeviceOn(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    pictureSocket.CreatePictureSocket(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    deviceOff.CreateDeviceOff(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    deviceNoConnection.CreateDeviceNoConnection(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    labelRoomName.CreateLabelRoomName(i, pct, roomName, devicesType[i]);
                    deviceName.CreateLabelDeviceName(i, pct, devicesName, devicesType[i]);
                    deviceChannel.CreateLabelDeviceChannel(i, pct, devicesChannel);
                    if (devicesType[i].Equals("6"))
                    {
                        CreateLabelForSRF13000T(i, devicesType[i], pct, labelHeatingSRF13000T);
                    }
                    StatusAllIcons(pct, deviceOff, _deviceOn, deviceNoConnection, idDevices[i], labelHeatingSRF13000T);

                    positionLeft++;
                    countDevices++;
                }
            }
            for (int i = 0; i < xmlDevice.DeviceCountXmlTX(); i++)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (countDevices != 0 && countDevices % 7 == 0)
                {
                    positionTop++;
                    positionLeft = 0;
                }
                PictureBox pct = new PictureBox();
                PictureMainTX _pct = new PictureMainTX();
                LabelDeviceChannelTX deviceChannelTX = new LabelDeviceChannelTX();
                LabelDeviceNameTX deviceNameTX = new LabelDeviceNameTX();
                LabelRoomNameTX labelRoomNameTX = new LabelRoomNameTX();
                PictureDeviceTX pictureDeviceTX = new PictureDeviceTX();

                pct = _pct.CreatePictureMain(i, port, devicesChannelTX[i], devicesNameTX[i], tabPage1, positionTop, positionLeft, devicesTypeTX[i], tabControl);
                pictureDeviceTX.CreatePictureTX(i, port, pct, devicesChannelTX[i], devicesNameTX[i], tabPage1, devicesTypeTX[i], tabControl);
                deviceNameTX.CreateLabelDeviceName(i, pct, devicesNameTX);
                labelRoomNameTX.CreateLabelRoomNameTX(i, pct, roomNameTX);
                deviceChannelTX.CreateLabelDeviceChannel(i, pct, devicesChannelTX);

                positionLeft++;
                countDevices++;
            }
            operationWithMainForm.CheckScroll(tabControl, tabPage1);
        }


        public void IconsAddRoom(TabPage tabPage1,TabControl tabControl)
        {
            tabPage1.Controls.Clear();
            SerialPort port = Port.TakeDataPort();
            Cursor.Current = Cursors.WaitCursor;
            int countDevices = 0;
            int positionTop = 0;
            int positionLeft = 0;
            string[] devicesName = xmlDevice.DeviceNameXmlInRoom(tabPage1.Text, DEVICEPATH);
            string[] devicesChannel = new string[devicesName.Length];
            string[] devicesType = new string[devicesName.Length];
            string[] idDevices = new string[devicesName.Length];
            xmlDevice.DeviceElementsXml(devicesChannel, devicesType, idDevices,tabPage1.Text);
            string[] devicesNameTX = xmlDevice.DeviceNameXmlInRoom(tabPage1.Text, DEVICEPATHTX);
            string[] devicesChannelTX = new string[devicesNameTX.Length];
            string[] devicesTypeTX = new string[devicesNameTX.Length];
            xmlDevice.DeviceElementsXmlRoomTX(devicesChannelTX, devicesTypeTX,tabPage1.Text);

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
                    PictureSocket pictureSocket = new PictureSocket();
                    PictureDeviceOn _deviceOn = new PictureDeviceOn();
                    PictureDeviceNoConnection deviceNoConnection = new PictureDeviceNoConnection();
                    PictureDeviceOff deviceOff = new PictureDeviceOff();
                    LabelDeviceName deviceName = new LabelDeviceName();
                    LabelDeviceChannel deviceChannel = new LabelDeviceChannel();
                    PictureMain _pct = new PictureMain();
                    Label labelTemp = new Label()
                    {
                        Name = "labelTemp",
                        Height = 20,
                        Width = 35,
                    };
                    Label labelTempMax = new Label()
                    {
                        Name = "labelTempMax",
                        Height = 17,
                        Width = 34,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                    };
                    Label labelHeatingSRF13000T = new Label()
                    {
                        Name = "labelHeating"
                    };
                    CreateMainPropsTempForSRF13000T(labelTemp, labelTempMax);
                    pct = _pct.CreatePictureMain(i, port, pct, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    _deviceOn.CreatePictureDeviceOn(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    pictureSocket.CreatePictureSocket(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    deviceOff.CreateDeviceOff(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    deviceNoConnection.CreateDeviceNoConnection(i, pct, port, devicesChannel[i], _deviceOn, deviceOff, deviceNoConnection, idDevices[i], devicesName[i], devicesType[i], tabPage1, positionTop, positionLeft, labelHeatingSRF13000T, labelTemp, labelTempMax, tabControl);
                    deviceName.CreateLabelDeviceName(i, pct, devicesName, devicesType[i]);
                    deviceChannel.CreateLabelDeviceChannel(i, pct, devicesChannel);
                    if (devicesType[i].Equals("6"))
                    {
                        CreateLabelForSRF13000T(i, devicesType[i], pct, labelHeatingSRF13000T);
                    }
                    StatusAllIcons(pct, deviceOff, _deviceOn, deviceNoConnection, idDevices[i], labelHeatingSRF13000T);

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

                pct = _pct.CreatePictureMain(i, port, devicesChannelTX[i], devicesNameTX[i], tabPage1, positionTop, positionLeft, devicesTypeTX[i], tabControl);
                deviceNameTX.CreateLabelDeviceName(i, pct, devicesNameTX);
                deviceChannelTX.CreateLabelDeviceChannel(i, pct, devicesChannelTX);
                pictureDeviceTX.CreatePictureTX(i, port, pct, devicesChannelTX[i], devicesNameTX[i], tabPage1, devicesTypeTX[i], tabControl);

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
                device.WriteData(port, buffer);
                device.WaitData(port, rx_buffer);
                if (rx_buffer != null)
                {
                    label.Text = xmlTypeDevice.TypeDeviceNameXml(rx_buffer[7]) + $" (V{rx_buffer[8]}): Подключено";
                }
            }
        }

        public void StatusAllIcons(PictureBox pictureBox, PictureDeviceOff off, PictureDeviceOn on, PictureDeviceNoConnection noConnection, string idDevices, Label heatingSRF13000T)
        {
            using (SerialPort port = Port.TakeDataPort())
            {
                string[] idArray = idDevices.Split('&');
                byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 9, 0, 0, 128, 0, 170, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
                byte[] tx_bufferMainPropertiesFirstWrite = device.CRC(bufferMainPropertiesFirstWrite);
                byte[] rx_bufferMainPropertiesFirstRequest = new byte[17];
                device.WriteData(port, tx_bufferMainPropertiesFirstWrite);
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

        private void CreateLabelForSRF13000T(int i, string devicesType, PictureBox pct, Label labelHeatingSRF13000T)
        {
            labelHeatingSRF13000T.Height = 20;
            labelHeatingSRF13000T.Width = 90;
            labelHeatingSRF13000T.Top = 45;
            labelHeatingSRF13000T.Left = 10;
            pct.Controls.Add(labelHeatingSRF13000T);
        }

        private void CreateMainPropsTempForSRF13000T(Label Temp, Label TempMax)
        {
            Temp.Height = 20;
            Temp.Width = 35;
            Temp.Top = 5;
            Temp.Left = 32;
            TempMax.Height = 20;
            TempMax.Width = 35;
            TempMax.Top = 25;
            TempMax.Left = 32;
            TempMax.BackColor = Color.FromArgb(0, 192, 0);
            TempMax.ForeColor = Color.White;
            TempMax.TextAlign = ContentAlignment.MiddleCenter;
            TempMax.AutoSize = false;
            TempMax.Padding = new Padding(1, 3, 0, 0);
        }


        public void AddRooms(TabControl tabControl, TabPage mainTabPage)
        {
            string[] RoomName = xmlGroup.RoomNameXml();
            if (RoomName != null)
            {
                for (int i = 0; i < RoomName.Length; i++)
                {
                    TabPage page = new TabPage(RoomName[i])
                    {
                        BackColor = Color.White
                    };
                    page.Enter += delegate (object sender, EventArgs e) { IconsAddRoom(page, tabControl); };
                    page.MouseUp += delegate (object sender, MouseEventArgs e) { Btn_RightClickRoom(sender, e, page.Text, tabControl, page, mainTabPage); };
                    tabControl.Controls.Add(page);
                }
            }
        }
        
        public void UpdateRooms(TabControl tab,TextBox textBox, TabPage mainTabPage,TabControl tabControl)
        {
            if (textBox.Text.Length>0)
            {
                TabPage page = new TabPage(textBox.Text)
                {
                    BackColor = Color.White
                };
                page.Enter += delegate (object sender, EventArgs e) { IconsAddRoom(page, tabControl); };
                page.MouseUp += delegate (object sender, MouseEventArgs e) { Btn_RightClickRoom(sender, e, page.Text, tab, page, mainTabPage); };
                tab.Controls.Add(page);
            }
        }

        private void Btn_RightClickRoom(object sender, MouseEventArgs e, string roomName, TabControl tabControl, TabPage page, TabPage mainTabPage)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context = new ContextMenuStrip();
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem();
                context.Items.AddRange(new ToolStripMenuItem[] { menuItem2, menuItem3 });
                menuItem2.Text = "Редактировать группу";
                menuItem3.Text = "Удалить группу";
                menuItem2.Click += delegate (object _sender, EventArgs _e) { MenuItem2_ClickUpdate(_sender, _e, page, mainTabPage); };
                menuItem3.Click += delegate (object _sender, EventArgs _e) { MenuItem3_ClickRemove(_sender, _e, roomName, tabControl, page, mainTabPage); };
                context.Show(Cursor.Position);
            }
        }

        private void MenuItem3_ClickRemove(object _sender, EventArgs _e, string roomName, TabControl tabControl, TabPage page, TabPage mainTabPage)
        {
            string roomNameSub = roomName;
            tabControl.TabPages.Remove(page);
            xmlGroup.RemoveRoom(roomNameSub);
            UpdateTabPage(mainTabPage, page);
        }

        private void MenuItem2_ClickUpdate(object _sender, EventArgs _e, TabPage page, TabPage mainTabPage)
        {
            using (FormUpdateRoom formUpdateRoom = new FormUpdateRoom(page, mainTabPage))
            {
                formUpdateRoom.ShowDialog();
            }
        }

        public void UpdateTabPage(TabPage mainPage, TabPage removePage)
        {
            foreach (PictureBox p in mainPage.Controls)
            {
                UpdatePictureBox(p);
            };

            void UpdatePictureBox(PictureBox p)
            {
                foreach (var g in p.Controls)
                {
                    if (g is Label label)
                    {
                        string name = "";
                        if (label.Name.Length > 4)
                        {
                            name = label.Name.Substring(0, 4);
                        }
                        string _nameRoom = removePage.Text;
                        if (name.Equals("room"))
                        {
                            if (label.Text.Equals(_nameRoom))
                            {
                                label.Text = "";
                            }
                        }
                    }
                }
            }
        }
    }
}

