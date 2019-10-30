using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelDeviceNameTX
    {
        public void CreateLabelDeviceName(int i ,PictureBox pct, string[] devicesName)
        {
            Label deviceName = new Label
            {
                Height = 18,
                Width = 94,
                Name = "deviceNameTX" + i.ToString(),
                Left = 3,
                Top = 76,
                BackColor = Color.White,
                Text = devicesName[i],
                TextAlign = ContentAlignment.MiddleCenter
            };
            if (deviceName.Text.Length >= 13)
            {
                deviceName.Width = 94;
                deviceName.Left = 3;
            }

            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon = false,
                ShowAlways = true,
                BackColor = Color.White
            };
            if (deviceName.Text.Length > 12)
            {
                yourToolTip.SetToolTip(deviceName, deviceName.Text);
            }

            pct.Controls.Add(deviceName);
        }
    }
}
