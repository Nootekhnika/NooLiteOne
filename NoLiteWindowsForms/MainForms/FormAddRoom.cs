using NooLiteServiceSoft.IconClass;
using NooLiteServiceSoft.XML;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public partial class FormAddRoom : Form
    {
        private TabControl _tab;
        private TabPage _page;
        Icons icon = new Icons();
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        XmlGroup xmlGroup = new XmlGroup(); 

        public FormAddRoom(TabControl tab,TabPage mainTabPage)
        {
            InitializeComponent();
            _tab = tab;
            _page = mainTabPage;
        }

        private void FormAddRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("rooms.xml") == false)
            {
                xmlGroup.CreateXmlFile();
            }

            var Xmlroom = new XmlGroup();
            bool uniqueRoomFlag = Xmlroom.CheckUniqueRoom(room_textBox.Text);
            if (uniqueRoomFlag == false)
            {
                var room = new Room
                {
                    Id = Guid.NewGuid().ToString(),
                    RoomName = room_textBox.Text
                };

                if (room_textBox.Text.Length > 0 && room_textBox.Text.Equals("Все") == false && room_textBox.Text.Length < 24)
                {
                    if (File.Exists("rooms.xml") == false)
                    {
                        Xmlroom.CreateXmlFile(room);
                    }
                    else
                    {
                        Xmlroom.LoadXMLFile(room);
                    }

                    CloseFormAddRoom(_tab);
                }
                else
                {
                    room_textBox.BackColor = Color.LightCoral;
                }
            }
            else
            {
                MessageBox.Show("Группа: " + '\u0022' + $"{room_textBox.Text}" + '\u0022' + " уже создана, выберите другое имя");
            }
        }

        private void CloseFormAddRoom(TabControl tabControl)
        {
            Close();
            icon.UpdateRooms(_tab, room_textBox, _page, tabControl);
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }  
    
        private void Validation(object sender, EventArgs e)
        {
            if (room_textBox.Text.Length > 0)
            {
                room_textBox.BackColor = Color.White;
            }
            else
            {
                room_textBox.BackColor = Color.LightCoral;
            }
        }

        private void Button_closeWindow_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
