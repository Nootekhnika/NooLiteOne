using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelDeviceName
    {
        // Отображение имени устройства на основной иконке
        public void CreateLabelDeviceName(int i ,PictureBox pct, string[] devicesName,string typeDevice, string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, TabPage tabPage, int positionPictureTop, int positionPictureLeft, Label srf13000T, Label tempT, Label tempMaxT, TabControl tabControl, SerialPort port)
        {
            Label deviceName ;
            EventMethod eventClass = new EventMethod();

            if (typeDevice.Equals("6"))
            {
                deviceName = new Label
                {
                    Height = 19,
                    Width = 94,
                    Name = "deviceName" + i.ToString(),
                    Top = 80,
                    Left = 3,
                    BackColor = Color.White,
                    Text = devicesName[i],
                    TextAlign = ContentAlignment.MiddleCenter

                };
            }
            else
            {
                deviceName = new Label
                {
                    Height = 19,
                    Width = 94,
                    Name = "deviceName" + i.ToString(),
                    Top = 72,
                    Left = 3,
                    BackColor = Color.White,
                    Text = devicesName[i],
                    TextAlign = ContentAlignment.MiddleCenter

                };
            }

            if (deviceName.Text.Length >= 13)
            {
                deviceName.Width = 94;
                deviceName.Left = 3;
            }

            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon =false,
                ShowAlways = true,
                BackColor =Color.White
            };
            if (deviceName.Text.Length > 12)
            {
                yourToolTip.SetToolTip(deviceName, deviceName.Text);
            }

            if (typeDevice.Equals("7"))
            {
                deviceName.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pct, devicesChannel, devicesName[i], idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                deviceName.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pct, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName[i], typeDevice, tabPage, srf13000T, tabControl); };
            }

            if (typeDevice.Equals("6"))
            {
                deviceName.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pct, devicesChannel, devicesName[i], idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T, i, tempT, tempMaxT, tabPage, tabControl); };
                deviceName.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pct, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName[i], typeDevice, tabPage, srf13000T, tabControl); };
            }
            else
            {
                deviceName.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                deviceName.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pct, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName[i], typeDevice, tabPage, srf13000T, tabControl); };
            }

            pct.Controls.Add(deviceName);
        }

      
    }
}
