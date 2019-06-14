using NooLiteServiceSoft.DeviceProperties;
using NooLiteServiceSoft.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class PictureMain
    {
        //readonly XmlDevice xmlDevice = new XmlDevice();
        //readonly XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        //UpdateFW.UpdateDeviceFW update = new UpdateFW.UpdateDeviceFW();
        //Icons icons = new Icons();
        EventMethod eventClass = new EventMethod();


        public PictureBox CreatePictureMain(int i, SerialPort port,PictureBox pictureBox,string devicesChannel, PictureDeviceOn _deviceOn, PictureDeviceOff _deviceoff, PictureDeviceNoConnection deviceNoConnection, string idDevices, string devicesName, string deviceType, TabPage tabPage, int positionPictureTop, int positionPictureLeft,Label srf13000T,Label tempT,Label tempMaxT)
        {

            PictureBox pct = new PictureBox
            {
                Height = 100,
                Width = 100,
                Name = "pct" + i.ToString(),
                Left = 25 + positionPictureLeft * 120,
                Top = 60 + positionPictureTop * 120,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle              
            };

            if (deviceType.Equals("7"))
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF11000R_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, i); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T); };
                }

            if (deviceType.Equals("6"))
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.MenuItemSRF13000T_Setting(sender, e, port, pictureBox, devicesChannel, devicesName, idDevices, _deviceOn, _deviceoff, deviceNoConnection, srf13000T,i,tempT,tempMaxT,tabPage); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T); };
               }
            else
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventClass.DbClick_Connection(sender, e, port, devicesChannel, _deviceOn, _deviceoff, deviceNoConnection, idDevices); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventClass.Btn_MouseUp(sender, e, port, pictureBox, _deviceOn, _deviceoff, deviceNoConnection, devicesChannel, idDevices, pct, devicesName, deviceType, tabPage, srf13000T); };
               }
            tabPage.Controls.Add(pct);
            return pct;
        }
    }
}
 