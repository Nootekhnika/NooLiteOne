using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelDeviceNameTX
    {
        public void CreateLabelDeviceName(int i ,PictureBox pct, string[] devicesName)
        {
            double countWidth = devicesName[i].Length * 7.5;
            Label deviceName = new Label
            {
                Height = 18,
                Width = (int)countWidth,
                Name = "deviceNameTX" + i.ToString(),
                Left = 20,
                Top = 76,
                BackColor = Color.White,
                Text = devicesName[i]
            };
            deviceName.Left = ((pct.Width - deviceName.Width) / 2) + 1;
            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon = false,
                ShowAlways = true,
                BackColor = Color.White
            };
            if (deviceName.Text.Length > 13)
            {
                yourToolTip.SetToolTip(deviceName, deviceName.Text);
            }
            pct.Controls.Add(deviceName);
        }
    }
}
