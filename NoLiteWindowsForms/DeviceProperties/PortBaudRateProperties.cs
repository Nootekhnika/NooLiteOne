using NooLiteServiceSoft.XML;
using System;
using System.Windows.Forms;

namespace NooLiteServiceSoft.DeviceProperties
{
    public partial class PortBaudRateProperties : Form
    {
        private const int CS_DROPSHADOW = 0x20000;
        XmlPort xmlPort = new XmlPort();
        string[] baudRate = new string[8] { "9600", "14400", "19200", "28800", "38400", "56600", "57600", "115200" };
        public PortBaudRateProperties()
        {
            InitializeComponent();
            comboBox_BaudRate.Items.AddRange(baudRate);
            comboBox_BaudRate.SelectedIndex = 0;
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            xmlPort.UpdatePortValue(comboBox_BaudRate.Text);
            Close();
        }

        private void Button_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
