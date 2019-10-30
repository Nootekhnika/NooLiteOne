using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Terminal
{
    public partial class Terminal : Form
    {
        Port portEx = new Port();
        Device device = new Device();
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;


        public enum OperationMode
        {
            [Description("nooLite TX")]
            nooLiteTX = 0,
            [Description("nooLite RX")]
            nooLiteRX = 1,
            [Description("nooLite-F TX")]
            nooLiteFTX = 2,
            [Description("nooLite-F RX")]
            nooLiteFRX = 3,
            [Description("Service")]
            Service = 4,
            [Description("Bootloader")]
            Bootloader = 5
        }

        public enum CommandNoolite
        {
            [Description("OFF")]
            OFF = 0,
            [Description("Bright Down")]
            BrightDown = 1,
            [Description("On")]
            On = 2,
            [Description("Bright Up")]
            BrightUp = 3,
            [Description("Switch")]
            Switch = 4,
            [Description("Bright Back")]
            BrightBack = 5,
            [Description("Set Brightness")]
            SetBrightness = 6,
            [Description("Load Preset")]
            LoadPreset = 7,
            [Description("Save Preset ")]
            SavePreset = 8,
            [Description("Unbind")]
            Unbind = 9,
            [Description("Stop Reg")]
            StopReg = 10,
            [Description("Bright Step Down")]
            Bright_Step_Down = 11,
            [Description("Bright Step Up")]
            Bright_Step_Up = 12,
            [Description("Bright Reg")]
            Bright_Reg = 13,
            [Description("Bind")]
            Bind = 15,
            [Description("Roll Colour")]
            RollColour = 16,
            [Description("Switch Colour")]
            SwitchColour = 17,
            [Description("Switch Mode")]
            SwitchMode = 18,
            [Description("Speed  Mode Back")]
            SpeedModeBack = 19,
            [Description("Battery_Low")]
            BatteryLow = 20,
            [Description("Sens Temp Humi")]
            SensTempHumi = 21,
            [Description("Temporary_On")]
            TemporaryOn = 25,
            [Description("Modes")]
            Modes = 26,
            [Description("Read State")]
            ReadState = 128,
            [Description("Write State")]
            WriteState = 129,
            [Description("Send State")]
            SendState = 130,
            [Description("Service")]
            Service = 131,
            [Description("Clear memory")]
            Clearmemory = 132
        }

        public enum CommandIl
        {
            [Description("Передать команду")]
            SendCmd = 0,
            [Description("Передать ШВ комманду")]
            SendCmdSh = 1,
            [Description("Считать ответ")]
            ReadAnswer = 2,
            [Description("Включить привязку")]
            OnBind = 3,
            [Description("Выключить привязку")]
            OffBind = 4,
            [Description("Очистить ячейку (канал)")]
            ClearCell = 5,
            [Description("Очистить память")]
            ClearMemmory = 6,
            [Description("Отвязать адрес от канала")]
            UnBindIdChanel = 7,
            [Description("Передать команду по ID (с каналом)")]
            SendCmdIdChannel = 8,
            [Description("Передать команду по ID (без канала)")]
            SendCmdId = 9,
            [Description("Маршрутизация")]
            Route = 16,
        }
        public Terminal()
        {
            InitializeComponent();
            ValidationTerminalInput validation = new ValidationTerminalInput();
            OperationModeEnum<OperationMode>(operationModecomboBox);
            OperationModeEnum<CommandNoolite>(comandNooLite_comboBox);
            OperationModeEnum<CommandIl>(comboBox_cmdIL);
            operationModecomboBox.SelectedIndex = 0;
            comandNooLite_comboBox.SelectedIndex = 0;
            comboBox_cmdIL.SelectedIndex = 0;
            textBox_ID0.Text = "0";
            textBox_ID1.Text = "0";
            textBox_ID2.Text = "0";
            textBox_ID3.Text = "0";
            numericUpDown_ResTogl.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown_ResTogl.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown_ResTogl); };
            numericUpDown_Chaneel.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown_Chaneel.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown_Chaneel); };
            numericUpDown_FMT.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown_FMT.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown_FMT); };
            numericUpDown2_D0.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown2_D0.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown2_D0); };
            numericUpDown_D1.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown_D1.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown_D1); };
            numericUpDown_D2.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown_D2.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown_D2); };
            numericUpDown_D3.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidatiionKeyPressNum(_sender, _e); };
            numericUpDown_D3.KeyUp += delegate { validation.ValidateNumericDown(numericUpDown_D3); };
            textBox_ID0.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidationKeyPressNumId(_sender, _e); };
            textBox_ID1.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidationKeyPressNumId(_sender, _e); };
            textBox_ID2.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidationKeyPressNumId(_sender, _e); };
            textBox_ID3.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { validation.ValidationKeyPressNumId(_sender, _e); };
        }

        public static void OperationModeEnum<T>(ComboBox comboBox)
        {
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Value";
            comboBox.DataSource = Enum.GetValues(typeof(T))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        private void Label_D3_Click(object sender, EventArgs e)
        {

        }

        private void Button_SendArr_Click(object sender, EventArgs e)
        {
            if (textBox_ID0.Text.Length > 0 && textBox_ID1.Text.Length > 0 && textBox_ID2.Text.Length > 0 && textBox_ID3.Text.Length > 0 && textBox_ID0.Text.Length < 3 && textBox_ID1.Text.Length < 3 && textBox_ID2.Text.Length < 3 && textBox_ID3.Text.Length < 3)
            {
                OperationMode operationMode;
                CommandIl commandIl;
                CommandNoolite commandNoolite;
                Enum.TryParse(operationModecomboBox.SelectedValue.ToString(), out operationMode);
                Enum.TryParse(comboBox_cmdIL.SelectedValue.ToString(), out commandIl);
                Enum.TryParse(comandNooLite_comboBox.SelectedValue.ToString(), out commandNoolite);

                byte Id0 = Convert.ToByte(textBox_ID0.Text, 16);
                byte Id1 = Convert.ToByte(textBox_ID1.Text, 16);
                byte Id2 = Convert.ToByte(textBox_ID2.Text, 16);
                byte Id3 = Convert.ToByte(textBox_ID3.Text, 16);


                using (SerialPort port = portEx.TakeDataAboutPort())
                {

                    port.ReadTimeout = 500;
                    port.WriteTimeout = 500;


                    byte[] buffer = new byte[17] { 171, (byte)operationMode, (byte)commandIl, (byte)numericUpDown_ResTogl.Value, (byte)numericUpDown_Chaneel.Value, (byte)commandNoolite, (byte)numericUpDown_FMT.Value, (byte)numericUpDown2_D0.Value, (byte)numericUpDown_D1.Value, (byte)numericUpDown_D2.Value, (byte)numericUpDown_D3.Value, Id0, Id1, Id2, Id3, 0, 172 };
                    byte[] tx_buffer = device.CRC(buffer);
                    byte[] rx_buffer = new byte[17];
                    device.WriteData(port, tx_buffer);

                    if ((int)operationMode == 2)
                    {
                        try
                        {
                            device.WaitData(port, rx_buffer);
                        }
                        catch
                        {

                        }
                    }

                    if (port.IsOpen) port.Close();

                    ListViewItem listViewItem = new ListViewItem(new string[] { $"{(int)operationMode}", $"{(int)commandIl}", $"{(int)numericUpDown_ResTogl.Value}", $"{(int)numericUpDown_Chaneel.Value}", $"{(int)commandNoolite}", $"{(int)numericUpDown_FMT.Value}", $"{(int)numericUpDown2_D0.Value}", $"{(int)numericUpDown_D1.Value}", $"{(int)numericUpDown_D2.Value}", $"{(byte)numericUpDown_D3.Value}", $"{textBox_ID0.Text}{textBox_ID1.Text}{textBox_ID2.Text}{textBox_ID3.Text}" });
                    listView_Write.Items.Add(listViewItem);
                    ListViewItem listViewItemRead = new ListViewItem(new string[] { $"{rx_buffer[1]}", $"{rx_buffer[2]}", $"{rx_buffer[3]}", $"{rx_buffer[4]}", $"{rx_buffer[5]}", $"{rx_buffer[6]}", $"{rx_buffer[7]}", $"{rx_buffer[8]}", $"{rx_buffer[9]}", $"{rx_buffer[10]}", $"{rx_buffer[11].ToString("X2")}{rx_buffer[12].ToString("X2")}{rx_buffer[13].ToString("X2")}{rx_buffer[14].ToString("X2")}" });
                    listView_Read.Items.Add(listViewItemRead);
                    listView_Write.EnsureVisible(listView_Write.Items.Count - 1);
                    listView_Read.EnsureVisible(listView_Write.Items.Count - 1);
                }
            }
            else
            {
                if (textBox_ID0.Text.Length == 0 || textBox_ID0.Text.Length > 2) { textBox_ID0.BackColor = Color.LightCoral; }
                else { textBox_ID0.BackColor = Color.White; }
                if (textBox_ID1.Text.Length == 0 || textBox_ID1.Text.Length > 2) { textBox_ID1.BackColor = Color.LightCoral; }
                else { textBox_ID1.BackColor = Color.White; }
                if (textBox_ID2.Text.Length == 0 || textBox_ID2.Text.Length > 2) { textBox_ID2.BackColor = Color.LightCoral; }
                else { textBox_ID2.BackColor = Color.White; }
                if (textBox_ID3.Text.Length == 0 || textBox_ID3.Text.Length > 2) { textBox_ID3.BackColor = Color.LightCoral; }
                else { textBox_ID3.BackColor = Color.White; }
            }
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            listView_Write.Items.Clear();
            listView_Read.Items.Clear();
        }

        private void ListView_Write_SelectedIndexChanged(object sender, EventArgs e)
        {
                          
            if (listView_Write.SelectedItems.Count > 0)
            {
                int selectionindex = listView_Write.Items.IndexOf(listView_Write.SelectedItems[0]);
                listView_Read.Select();
                listView_Read.Items[selectionindex].Selected = true;
                listView_Read.EnsureVisible(selectionindex);
            }

        }

        private void Button_closeTerminal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Panel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void Panel9_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Panel9_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;

        }

        private void PanelForWindowDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void PanelForWindowDrop_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

        }

        private void PanelForWindowDrop_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }
        
        private void TextBox_ID0_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation(e);
            if (textBox_ID0.Text.Length<2)
            {
                textBox_ID0.BackColor = Color.White;
            }
            else
            {
                textBox_ID0.BackColor = Color.LightCoral;
            }
        }
        
        private void TextBox_ID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation(e);
        }

        private void TextBox_ID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation(e);
        }

        private void TextBox_ID3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation(e);
        }

        public void Validation(KeyPressEventArgs e)
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

        private void TextBox_ID0_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ID0.Text.Length < 3)
            {
                textBox_ID0.BackColor = Color.White;
            }
            else
            {
                textBox_ID0.BackColor = Color.LightCoral;
            }
        }

        private void TextBox_ID1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ID1.Text.Length < 3)
            {
                textBox_ID1.BackColor = Color.White;
            }
            else
            {
                textBox_ID1.BackColor = Color.LightCoral;
            }
        }

        private void TextBox_ID2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ID2.Text.Length < 3)
            {
                textBox_ID2.BackColor = Color.White;
            }
            else
            {
                textBox_ID2.BackColor = Color.LightCoral;
            }
        }

        private void TextBox_ID3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ID3.Text.Length < 2)
            {
                textBox_ID3.BackColor = Color.White;
            }
            else
            {
                textBox_ID3.BackColor = Color.LightCoral;
            }
        }
    }
}
