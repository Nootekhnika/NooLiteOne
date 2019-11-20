using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureMain
    {
        EventMethod eventClass = new EventMethod();


        public PictureBox CreatePictureMain(int i, SerialPort port,PictureBox pictureBox,string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage, int positionPictureTop, int positionPictureLeft,Label srf13000T,Label tempT,Label tempMaxT,TabControl tabControl)
        {

            PictureBox pct = new PictureBox
            {
                Height = 102,
                Width = 102,
                Name = "pct" + i.ToString(),
                Left = 5 + positionPictureLeft * 120,
                Top = 60 + positionPictureTop * 120,
                Image = Properties.Resources.Rounded_corner,
                SizeMode = PictureBoxSizeMode.StretchImage         
            };

            if (deviceType.Equals("7"))
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T, tabControl); };
                }

            if (deviceType.Equals("6"))
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T,i,tempT,tempMaxT,tabPage, tabControl); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T, tabControl); };
               }
            //if (deviceType.Equals("5"))
            //{
            //    pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.ShowSuf13000Window(port, devicesChannel, idDevices); };
            //    pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            //}

            else
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T, tabControl); };
            }
            tabPage.Controls.Add(pct);
            return pct;
        }
    }
}
 