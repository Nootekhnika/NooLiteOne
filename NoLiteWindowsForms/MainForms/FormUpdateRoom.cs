using NooLiteServiceSoft.XML;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public partial class FormUpdateRoom : Form
    {
        TabPage tabPage;
        TabPage tabMainPage;
        XmlGroup xmlGroup = new XmlGroup();
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        public FormUpdateRoom(TabPage page, TabPage mainPage)
        {
            InitializeComponent();
            room_UpdateTextBox.Text = page.Text;
            tabPage = page;
            tabMainPage = mainPage;
        }

        private void SaveUpdateRoom_button_Click(object sender, EventArgs e)
        {
            if (room_UpdateTextBox.Text.Length > 0 && room_UpdateTextBox.Text.Equals("Все") == false && room_UpdateTextBox.Text.Length < 24 && xmlGroup.CheckUniqueRoom(room_UpdateTextBox.Text) == false)
            {
                string roomName = tabPage.Text;
                xmlGroup.UpdateRoom(roomName, room_UpdateTextBox.Text, tabPage, tabMainPage);
                Close();
            }
            else
            {
                room_UpdateTextBox.BackColor = Color.LightCoral;
            }
        }

        private void Button_closeWindow_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
