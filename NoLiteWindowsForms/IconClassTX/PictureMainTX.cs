using NooLiteServiceSoft.IconClassTX;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public class PictureMainTX
    {
        EventMethodTX eventMethod = new EventMethodTX();

        public PictureBox CreatePictureMain(int i, SerialPort port, string devicesChannel,string devicesName, TabPage tabPage, int positionPictureTop, int positionPictureLeft,string deviceTypeTx,TabControl tabControl)
        {
            PictureBox pct = new PictureBox
            {
                Height = 102,
                Width = 102,
                Name = "pctTx" + i.ToString(),
                Left = 5 + positionPictureLeft * 120,
                Top = 60 + positionPictureTop * 120,
                Image = Properties.Resources.Rounded_corner,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
           
            if (deviceTypeTx.Equals("Светодиодный контроллер"))
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventMethod.MenuItemRGB_Setting(sender, e, port,devicesChannel,devicesName); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventMethod.Btn_MouseUp(sender, e, port, devicesChannel, pct, devicesName, tabPage, tabControl); };
            }
            else
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventMethod.DbClick_Connection(sender, e, port, devicesChannel); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventMethod.Btn_MouseUp(sender, e, port, devicesChannel, pct, devicesName, tabPage, tabControl); };
            }
            tabPage.Controls.Add(pct);
            return pct;
        }
    }
}
