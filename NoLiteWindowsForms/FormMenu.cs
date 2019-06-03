using NooLiteServiceSoft.XML;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public partial class FormMenu : Form
    {
        Device dvcForm1 = new Device();
        DeviceTX dvcForm1TX = new DeviceTX();
        XmlDevice xmlDevice = new XmlDevice();
        XmlTypeDevice typeDevice = new XmlTypeDevice();
        XmlGroup xmlGroup = new XmlGroup();
        ValidatorForm2 validator = new ValidatorForm2();
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        FormMain formMain;


        public FormMenu(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            comboBox_typeDeviceTx.DropDownStyle = ComboBoxStyle.DropDownList;
        }

       
        private void ShowFormOne_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            Visible = false;
            main.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            string[] roomName = xmlGroup.RoomNameXml();
            ControlBox = false;
            string[] channel = dvcForm1.ChannelCount();
            comboBoxSelectChannel.Items.AddRange(channel);
            comboBox_mode.Items.AddRange(dvcForm1.ModeServ());
            comboBox_typeDeviceTx.Items.AddRange(dvcForm1.TypeDevicesTX());        
            if (roomName != null)
            {
                comboBoxGroup.Items.Add("Все устройства");
                comboBoxGroup.Items.AddRange(roomName);
                comboBoxGroup.SelectedIndex = 0;
            }
            else
            {

                comboBoxGroup.Items.Add("Все устройства");
                comboBoxGroup.SelectedIndex = 0;
            }
            comboBox_mode.SelectedIndex = 0;
            comboBoxSelectChannel.SelectedIndex = 0;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
          
            if (comboBox_mode.Text.Equals("NooLite TX"))
            {

                DialogResult dialogResult = MessageBox.Show("Вы подтвердили привязку, нажав кнопку на устройстве?", "Окно подтверждения", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dvcForm1TX.NameDevice = textBox_name.Text;
                    int channel = int.Parse(comboBoxSelectChannel.Text) - 1;
                    dvcForm1TX.Channel = byte.Parse(channel.ToString());
                    dvcForm1TX.Mode = comboBox_mode.Text;
                    dvcForm1TX.TypeName = comboBox_typeDeviceTx.Text;
                    dvcForm1TX.RoomName = validator.ComboBoxValidation(comboBoxGroup.Text);

                    using (FormMain fm = new FormMain(dvcForm1TX))
                    {
                        Hide();
                        fm.ShowDialog();
                    }
                }
            }
            else
            {
                dvcForm1.NameDevice = textBox_name.Text;
                int channel = int.Parse(comboBoxSelectChannel.Text) - 1;
                dvcForm1.Channel = byte.Parse(channel.ToString());
                dvcForm1.Mode = comboBox_mode.Text;
                dvcForm1.RoomName = validator.ComboBoxValidation(comboBoxGroup.Text);
                using (FormMain fm = new FormMain(dvcForm1))
                {
                    formMain.Hide();
                    Hide();
                    fm.ShowDialog();
                }
            }
        }

        private void ComboBoxSelectChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_mode.SelectedIndex == 1)
            {
                validator.Form2ValidationSecond(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode, comboBox_typeDeviceTx);
            }
            else
            {
                validator.Form2Validation(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode);
            }
        }

        private void TextBox_name_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_mode.SelectedIndex == 1)
            {
                validator.Form2ValidationSecond(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode,comboBox_typeDeviceTx);
            }
            else
            {
                validator.Form2Validation(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode);
            }
        }

        private void ComboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox_mode.SelectedIndex == 1)
            {
                validator.Form2ValidationSecond(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode,comboBox_typeDeviceTx);
                comboBox_typeDeviceTx.Visible = true;
                label_typeDeviceTX.Visible = true;
                label_typeDeviceTX.Top = 290;
                comboBox_typeDeviceTx.Top = 315;
                comboBox_typeDeviceTx.Left = 44;
                buttonAdd.Left = 125;
                buttonAdd.Top = 435;
                comboBoxGroup.Top = 390;
                labelname_group.Top = 365;
            }
            else
            {
                validator.Form2Validation(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode);
                comboBox_typeDeviceTx.Visible = false;
                label_typeDeviceTX.Visible = false;
                comboBoxGroup.Top = 320;
                labelname_group.Top = 290;
                buttonAdd.Top = 360;
            };
        }

        private void ComboBox_typeDeviceTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            validator.Form2ValidationSecond(textBox_name, comboBoxSelectChannel, buttonAdd, comboBox_mode, comboBox_typeDeviceTx);
        }

        private void PictureClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void PictureClose_MouseEnter(object sender, EventArgs e)
        {
            pictureClose.Image = NooLiteServiceSoft.Properties.Resources.close2;
        }

        private void PictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.Image = NooLiteServiceSoft.Properties.Resources.close1;
        }
    }
}
