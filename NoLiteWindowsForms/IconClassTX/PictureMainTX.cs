using NooLiteServiceSoft.IconClass;
using NooLiteServiceSoft.IconClassTX;
using NooLiteServiceSoft.Settings;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public class PictureMainTX
    {
        EventMethodTX eventMethod = new EventMethodTX();

        public PictureBox CreatePictureMain(int i, SerialPort port, string devicesChannel,string devicesName, TabPage tabPage, int positionPictureTop, int positionPictureLeft,string deviceTypeTx)
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
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventMethod.Btn_MouseUp(sender, e, port, devicesChannel, pct, devicesName, tabPage); };
            }
            else
            {
                pct.MouseClick += delegate (object sender, MouseEventArgs e) { eventMethod.DbClick_Connection(sender, e, port, devicesChannel); };
                pct.MouseUp += delegate (object sender, MouseEventArgs e) { eventMethod.Btn_MouseUp(sender, e, port, devicesChannel, pct, devicesName, tabPage); };
            }
            tabPage.Controls.Add(pct);
            return pct;
        }

        //private void DbClick_Connection(object sender, MouseEventArgs e, SerialPort port, string devicesChannel)
        //{
        //    //SWITCH COMMAND
        //    if (e.Button == MouseButtons.Left)
        //    {            
        //        byte[] buffer = new byte[17] { 171, 0, 0, 0, byte.Parse(devicesChannel), 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
        //        byte[] tx_buffer = CRC(buffer);
        //        byte[] rx_buffer = new byte[17];
        //        if (port.IsOpen == false) port.Open();
        //        port.Write(tx_buffer, 0, tx_buffer.Length);
        //        if (port.IsOpen) port.Close();
        //    }
        //}

        //private void Btn_MouseUp(object sender, MouseEventArgs e, SerialPort port, string devicesChannel, PictureBox pct, string devicesName, TabPage tabPage)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        ContextMenuStrip context = new ContextMenuStrip();
        //        ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
        //        context.Items.AddRange(new ToolStripMenuItem[] { menuItem1});
        //        menuItem1.Text = "Отвязать";
        //        menuItem1.Click += delegate (object _sender, EventArgs _e) { MenuItem1_ClickRemove(_sender, _e, port, devicesChannel, pct, devicesName, tabPage); };
        //        context.Show(Cursor.Position);
        //    }
        //}

        //private void MenuItem1_ClickRemove(object _sender, EventArgs _e, SerialPort port, string devicesChannel, PictureBox pct, string devicesName, TabPage tabPage)
        //{
        //    //SERVICE AND REMOVE COMMAND         
        //    byte[] bufferRemove = new byte[17] { 171, 0, 0, 0, byte.Parse(devicesChannel), 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
        //    byte[] tx_bufferRemove = CRC(bufferRemove);
        //    if (port.IsOpen == false)
        //    {
        //        port.Open();
        //    }
        //    port.Write(tx_bufferRemove, 0, tx_bufferRemove.Length);

        //    xmlDevice.DeviceRemoveXmlTX(devicesChannel);
        //    pct.Dispose();

        //    if (port.IsOpen)
        //    {
        //        port.Close();
        //    }
        //    icons.IconAddallDevices(tabPage);
        //}

        //private void MenuItemRGB_Setting(object _sender, MouseEventArgs e, SerialPort port, string devicesChannel,string devicesName)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        DeviceTX device = new DeviceTX
        //        {
        //            NameDevice = devicesName,
        //            Channel = byte.Parse(devicesChannel),
        //        };

        //        using (SettingRGB fm = new SettingRGB(device))
        //        {
        //            fm.ShowDialog();
        //        }
        //    }
        //}
    }
}
