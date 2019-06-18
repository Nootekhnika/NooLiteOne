using System;
using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelDeviceName
    {
        // Отображение имени устройства на основной иконке
        public void CreateLabelDeviceName(int i ,PictureBox pct, string[] devicesName)
        {          
            Label deviceName = new Label
            {
                Height = 20,
                Width = 100,
                Name = "deviceName" + i.ToString(),
                Top = 80,
                BackColor = Color.White,
                Text = devicesName[i],
                TextAlign = ContentAlignment.MiddleCenter

            };         
            if (deviceName.Text.Length >= 14)
            {
                deviceName.Width = 100;
                deviceName.Left = 0;
            }

            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon =false,
                ShowAlways = true,
                BackColor =Color.White
            };
            if (deviceName.Text.Length > 13)
            {
                yourToolTip.SetToolTip(deviceName, deviceName.Text);
            }

            pct.Controls.Add(deviceName);
        }

      
    }
}
