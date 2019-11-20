using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelRoomName
    {
        public void CreateLabelRoomName(int i, PictureBox pct, string[] roomName, string typeDevice,string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName,TabPage tabPage, int positionPictureTop, int positionPictureLeft, Label srf13000T, Label tempT, Label tempMaxT, TabControl tabControl, SerialPort port)
        {
            Label labelRoomName;
            EventMethod eventClass = new EventMethod();

            if (typeDevice.Equals("6"))
            {
                labelRoomName = new Label
                {
                    Height = 20,
                    Width = 96,
                    Name = "roomName" + i.ToString(),
                    Top = 63,
                    Left = 2,
                    BackColor = Color.White,
                    Text = roomName[i],
                    TextAlign = ContentAlignment.MiddleCenter

                };
            }
            else
            {
                labelRoomName = new Label
                {
                    Height = 20,
                    Width = 96,
                    Name = "roomName" + i.ToString(),
                    Top = 55,
                    Left = 2,
                    BackColor = Color.White,
                    Text = roomName[i],
                    TextAlign = ContentAlignment.MiddleCenter

                };
            }
            if (labelRoomName.Text.Length >= 13)
            {
                labelRoomName.Width = 94;
                labelRoomName.Left = 3;
            }

            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon = false,
                ShowAlways = true,
                BackColor = Color.White
            };
            if (labelRoomName.Text.Length > 12)
            {
                yourToolTip.SetToolTip(labelRoomName, labelRoomName.Text);
            }

            if (typeDevice.Equals("7"))
            {
                labelRoomName.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pct, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                labelRoomName.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pct, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, typeDevice, tabPage, srf13000T, tabControl); };
            }

            if (typeDevice.Equals("6"))
            {
                labelRoomName.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pct, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T, i, tempT, tempMaxT, tabPage, tabControl); };
                labelRoomName.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pct, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, typeDevice, tabPage, srf13000T, tabControl); };
            }       
            else
            {
                labelRoomName.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                labelRoomName.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pct, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, typeDevice, tabPage, srf13000T, tabControl); };
            }

            pct.Controls.Add(labelRoomName);
        }
    }
}
