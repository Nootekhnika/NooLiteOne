using NooLiteServiceSoft.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.DeviceProperties
{
    public partial class PortBaudRateProperties : Form
    {
        XmlPort xmlPort = new XmlPort();
        string[] baudRate = new string[7] {"9600","14400","19200","28800","38400","56600","57600"};
        public PortBaudRateProperties()
        {
            InitializeComponent();
            comboBox_BaudRate.Items.AddRange(baudRate);
            comboBox_BaudRate.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            xmlPort.UpdatePortValue(comboBox_BaudRate.Text);
            Close();
        }

        private void ClosePicture_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClosePicture_MouseEnter(object sender, EventArgs e)
        {
            closePicture.Image = NooLiteServiceSoft.Properties.Resources.close2;
        }

        private void ClosePicture_MouseLeave(object sender, EventArgs e)
        {
            closePicture.Image = NooLiteServiceSoft.Properties.Resources.close1;
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
