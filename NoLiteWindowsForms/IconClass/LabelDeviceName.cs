using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelDeviceName
    {
        // Отображение имени устройства на основной иконке
        public void CreateLabelDeviceName(int i ,PictureBox pct, string[] devicesName,string typeDevice)
        {
            Label deviceName ;
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

            pct.Controls.Add(deviceName);
        }

      
    }
}
