using System;
using System.IO.Ports;
using System.Windows.Forms;
using NooLiteServiceSoft.IconClass;
using System.IO;
using System.Drawing;
using NooLiteServiceSoft.Design;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace NooLiteServiceSoft
{
    public partial class FormMain : Form
    {
        XmlDevice xmlDevice = new XmlDevice();
        XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        Icons icons = new Icons();
        Form form = new Form();
        Port port = new Port();
        bool flagSplash=true;
        OperationWithMainForm operationWithMainForm = new OperationWithMainForm();
        SerialPort _port = Port.TakeDataPort();
        FormSplashScreen screen = new FormSplashScreen();   
        UpdateFW.UpdateDeviceFW update = new UpdateFW.UpdateDeviceFW();
        MyRenderer m = new MyRenderer();
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public FormMain()
        {
            InitializeComponent();
            if (flagSplash) screen.Show();
            menuStrip1.Renderer = new MyRenderer();
            port.CreatePort(false);
            icons.StatusMtrf(label_Mtrf);
            if (File.Exists("rooms.xml") == false)
            {
                xmlTypeDevice.CreateXmlFile();
                if (File.Exists("devices.xml") == false) xmlDevice.CreateXmlFile();
                if (File.Exists("devicesTX.xml") == false) xmlDevice.CreateXmlFileTX();
            }
            icons.IconAddallDevices(tabControl, tabPage1);
            icons.AddRooms(tabControl, tabPage1);
            operationWithMainForm.CheckScroll(tabControl, tabPage1);
            if (contextToolStripMenuItem.Checked == true) { contextToolStripMenuItem.ForeColor = Color.White; }
            if (flagSplash)
            {
                flagSplash = false;
                screen.Hide();
            }
        }



        public FormMain(DeviceTX deviceForm2)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            icons.StatusMtrf(label_Mtrf);
            try
            {
                icons.IconAddallDevices(tabControl,tabPage1);
                icons.AddRooms(tabControl,tabPage1);
                operationWithMainForm.CheckScroll(tabControl, tabPage1);
            }
            catch (IOException)
            {
            }
        }


        public FormMain(Device deviceForm2)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            icons.StatusMtrf(label_Mtrf);
            Device device = new Device();
            try
            {
                device.BindCommandFTX(deviceForm2);
                icons.IconAddallDevices(tabControl,tabPage1);
                icons.AddRooms(tabControl,tabPage1);
            }
            catch (IOException)
            {
            }            
        }

        private void StartForm()
        {
            Application.Run(new FormSplashScreen());            
        }


        private void FormMain_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddRoomStripMenuItem_Click(object sender, EventArgs e)
        {
            contextToolStripMenuItem.ForeColor = Color.Black;
            Thread.Sleep(100);
            FormAddRoom rooms = new FormAddRoom(tabControl, tabPage1);
            rooms.ShowDialog();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextToolStripMenuItem.ForeColor = Color.Black;
            using (FormMenu menu = new FormMenu(this))
            {
                menu.ShowDialog();
            }
        }

        private void UpdateAllDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           serviceToolStripMenuItem.ForeColor = Color.Black;
            Thread.Sleep(100);
            icons.IconAddallDevices(tabControl,tabPage1);
        }
       
        private void TabPage1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
                context.Items.AddRange(new ToolStripMenuItem[] { menuItem1});
                menuItem1.Text = "Обновить все устройства";
                menuItem1.Click += delegate (object _sender, EventArgs _e) { icons.IconAddallDevices(tabControl,tabPage1); };
                context.Show(Cursor.Position);
            }
        }

        private void ComPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextToolStripMenuItem.ForeColor = Color.Black;
            Thread.Sleep(100);
            using (Route menu = new Route())
            {
                menu.ShowDialog();
            }         
        }
        private void WebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoToolStripMenuItem.ForeColor = Color.Black;
            Thread.Sleep(100);
            Process.Start("https://noo.by/");
        }
 
        private void ContextToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            contextToolStripMenuItem.ForeColor = Color.White;
        }
      
        private void HidePicture_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void ClosePicture_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
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

        private void UpdatePoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string DEFAULTVALUEFORMTRF64 = "0";
            const string DEFAULTVALUEFORMTRF64ID = "0&0&0&0";
            Cursor.Current = Cursors.WaitCursor;
            update.PreUpdateFW(_port, DEFAULTVALUEFORMTRF64, DEFAULTVALUEFORMTRF64ID, DEFAULTVALUEFORMTRF64);
        }

        private void AboutProgrammToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (FormAboutProgram form = new FormAboutProgram())
            {
                form.ShowDialog();
            }
        }

        private void ShowTerminal(object sender, EventArgs e)
        {
            using (Terminal.Terminal terminal = new Terminal.Terminal())
            {
                terminal.ShowDialog();
            }
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }
    }
}
