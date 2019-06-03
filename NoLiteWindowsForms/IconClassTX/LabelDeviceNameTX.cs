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
                Height = 20,
                Width = 80,
                Name = "deviceNameTX" + i.ToString(),
                Left = 20,
                Top = 80,
                BackColor = Color.White,
                Text = devicesName[i]
            };
            pct.Controls.Add(deviceName);
        }
    }
}
