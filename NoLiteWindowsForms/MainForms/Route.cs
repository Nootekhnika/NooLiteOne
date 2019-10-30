using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public partial class Route : Form
    {
        readonly SerialPort port = Port.TakeDataPort();
        Device deviceOperation = new Device();


        public Route()
        {
            InitializeComponent();
            operationModecomboBox.Items.Add("Включить");
            operationModecomboBox.Items.Add("Выключить");
            operationModecomboBox.SelectedIndex = 0;
        }

        private void Button_SendArr_Click(object sender, EventArgs e)
        {
            if (textBox_AddressSpace.Text.Length != 0 && textBox_Route.Text.Length != 0 && textBox_AddressSpace.Text.Length < 9 && textBox_Route.Text.Length != 0)
            {
                string addressSpaceText = Get16XString(textBox_AddressSpace.Text);
                string RouteText = Get16XString(textBox_Route.Text);
                byte k = 0;
                byte Id0 = Convert.ToByte(addressSpaceText.Substring(0, 2), 16);
                byte Id1 = Convert.ToByte(addressSpaceText.Substring(2, 2), 16);
                byte Id2 = Convert.ToByte(addressSpaceText.Substring(4, 2), 16);
                byte Id3 = Convert.ToByte(addressSpaceText.Substring(6, 2), 16);
                byte d0 = Convert.ToByte(RouteText.Substring(0, 2), 16);
                byte d1 = Convert.ToByte(RouteText.Substring(2, 2), 16);
                byte d2 = Convert.ToByte(RouteText.Substring(4, 2), 16);
                byte d3 = Convert.ToByte(RouteText.Substring(6, 2), 16);
                if (operationModecomboBox.SelectedItem.Equals("Включить"))
                {
                    k = 1;
                }
                byte[] buffer = new byte[17] { 171, 4, 16, 0, 0, 0, k, d0, d1, d2, d3, Id0, Id1, Id2, Id3, 0, 172 };
                byte[] tx_buffer = deviceOperation.CRC(buffer);
                byte[] rx_buffer = new byte[17];
                try
                {
                    if (port.IsOpen == false) port.Open();
                    port.Write(tx_buffer, 0, tx_buffer.Length);
                    deviceOperation.WaitData(port, rx_buffer);
                    if (port.IsOpen) port.Close();
                }
                catch
                {
                    using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                    {
                        disconnectMTRF.ShowDialog();
                    }
                    Application.Exit();
                }
            }
            else
            {
                if (textBox_AddressSpace.Text.Length == 0 || textBox_AddressSpace.Text.Length > 8) { textBox_AddressSpace.BackColor = Color.LightCoral; }
                else { textBox_AddressSpace.BackColor = Color.White; };
                if (textBox_Route.Text.Length == 0 || textBox_Route.Text.Length > 8) { textBox_Route.BackColor = Color.LightCoral; }
                else { textBox_Route.BackColor = Color.White; }
            }
        }

        public string Get16XString(string s)
        {
            int addressSpaceLength = s.Length;
            string addressSpaceText = s;
            for (int i = addressSpaceLength; i < 8; i++)
            {
                addressSpaceText += "0";
            }
            return addressSpaceText;
        }

        private void TextBox_AddressSpace_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validate(e);
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            textBox_AddressSpace.Text = "";
            textBox_AddressSpace.BackColor = Color.White;
            textBox_Route.Text = "";
            textBox_Route.BackColor = Color.White;
        }

        private void Button_closeTerminal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox_Route_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validate(e);
        }


        public void Validate(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 70) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBox_AddressSpace_TextChanged(object sender, EventArgs e)
        {
            if (textBox_AddressSpace.Text.Length > 0)
            {
                textBox_AddressSpace.BackColor = Color.White;
            }
        }

        private void TextBox_Route_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Route.Text.Length > 0)
            {
                textBox_Route.BackColor = Color.White;
            }
        }
    }
}
