using NooLiteServiceSoft.IconClassTX;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceTX
    {

        EventMethodTX eventMethod = new EventMethodTX();

        public void CreatePictureTX(int i, SerialPort port, PictureBox pictureBox,string devicesChannel, string devicesName,TabPage tabPage, string deviceTypeTx)
        {
            if (deviceTypeTx.Equals("Светодиодный контроллер"))
            {
                PictureBox pct_socet = new PictureBox
                {
                    Height = 32,
                    Width = 32,
                    Name = "pct_rgb" + i.ToString(),
                    Left = 6,
                    Top = 6,
                    Image = Properties.Resources.icon_rgbdevice,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                pct_socet.MouseClick += delegate (object sender, MouseEventArgs e) { eventMethod.MenuItemRGB_Setting(sender, e, port, devicesChannel, devicesName); };
                pct_socet.MouseUp += delegate (object sender, MouseEventArgs e) { eventMethod.Btn_MouseUp(sender, e, port, devicesChannel, pictureBox, devicesName, tabPage); };
                pictureBox.Controls.Add(pct_socet);
            }
            else
            {
                PictureBox pct_socet = new PictureBox
                {
                    Height = 40,
                    Width = 40,
                    Name = "pct_nl" + i.ToString(),
                    Top = 5,
                    Left = 5,
                    Image = Properties.Resources.icon_light,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Normal
                };
                pct_socet.MouseClick += delegate (object sender, MouseEventArgs e) { eventMethod.DbClick_Connection(sender, e, port, devicesChannel); };
                pct_socet.MouseUp += delegate (object sender, MouseEventArgs e) { eventMethod.Btn_MouseUp(sender, e, port, devicesChannel, pictureBox, devicesName, tabPage); };
                pictureBox.Controls.Add(pct_socet);
            }
        }
    }
}
