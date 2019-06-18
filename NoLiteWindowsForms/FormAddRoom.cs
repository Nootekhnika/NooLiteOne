using NooLiteServiceSoft.IconClass;
using NooLiteServiceSoft.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public partial class FormAddRoom : Form
    {
        private TabControl _tab;
        Icons icon = new Icons();
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public FormAddRoom(TabControl tab)
        {
            InitializeComponent();
            _tab = tab;
        }

        private void FormAddRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var Xmlroom = new XmlGroup();
            var room = new Room
            {   Id = Guid.NewGuid().ToString(),
                RoomName = room_textBox.Text
            };
            if (room_textBox.Text.Length > 0 && room_textBox.Text.Equals("Все") == false)
            {
                if (File.Exists("rooms.xml") == false)
                {
                    Xmlroom.CreateXmlFile(room);
                }
                else
                {
                    Xmlroom.LoadXMLFile(room);
                }

                CloseFormAddRoom();
            }
            else
            {
                room_textBox.BackColor = Color.LightCoral;
            }
        }

        private void CloseFormAddRoom()
        {       
                Close();
                icon.UpdateRooms(_tab,room_textBox);
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

        private void HidePicture_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ClosePicture_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HidePicture_MouseEnter(object sender, EventArgs e)
        {
            hidePicture.Image = NooLiteServiceSoft.Properties.Resources.mini2;
        }

        private void HidePicture_MouseLeave(object sender, EventArgs e)
        {
            hidePicture.Image = NooLiteServiceSoft.Properties.Resources.mini1;
        }

        private void ClosePicture_MouseEnter(object sender, EventArgs e)
        {
            closePicture.Image = NooLiteServiceSoft.Properties.Resources.close2;
        }

        private void ClosePicture_MouseLeave(object sender, EventArgs e)
        {
            closePicture.Image = NooLiteServiceSoft.Properties.Resources.close1;
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
    }
}
