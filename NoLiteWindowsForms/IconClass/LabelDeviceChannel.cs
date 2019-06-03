using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelDeviceChannel
    {
        // Отображение иконки на основной иконке
        public void CreateLabelDeviceChannel(int i ,PictureBox pct, string[] devicesChannel)
        {

            Label deviceChannel = new Label
            {
                Height = 20,
                Width = 80,
                Name = "deviceChannel" + i.ToString(),
                Left = 20,
                Top = 65,
                BackColor = Color.White,
                Text = devicesChannel[i]
            };
            deviceChannel.Visible = false;
            pct.Controls.Add(deviceChannel);
        }
    }
}
