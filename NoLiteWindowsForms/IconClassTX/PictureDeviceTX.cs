using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureDeviceTX
    {
        public void CreatePictureTX(int i, PictureBox pct, string deviceType)
        {
            if (deviceType.Equals("Светодиодный контроллер"))
            {
                PictureBox pct_socet = new PictureBox
                {
                    Height = 40,
                    Width = 40,
                    Name = "pct_rgb" + i.ToString(),
                    Left = 1,
                    Image = Properties.Resources.icon_rgbdevice,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                pct.Controls.Add(pct_socet);
            }
            else
            {
                PictureBox pct_socet = new PictureBox
                {
                    Height = 40,
                    Width = 40,
                    Name = "pct_nl" + i.ToString(),
                    Top = 4,
                    Left = 5,
                    Image = Properties.Resources.icon_light,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Normal
                };
                pct.Controls.Add(pct_socet);
            }
        }
    }
}
