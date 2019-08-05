using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace NooLiteServiceSoft.UpdateFW
{
    public partial class UpdateFW : Form
    {
        SerialPort port = Port.TakeDataPort();
        byte[] IdDevice;
        byte TypeDevice;
        XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        UpdateDeviceFW updateFile = new UpdateDeviceFW();
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        byte[] tx_bufferBootOff;
        byte[] tx_bufferEraseBoot;
        byte[] tx_bufferResetOk;
        private const int CS_DROPSHADOW = 0x20000;
        string FilePath { get; set; }
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public UpdateFW(Device device,byte[] _bufferBootOff,byte[] _bufferEraseBoot,byte[] _bufferResetOk)
        {
            InitializeComponent();
            IdDevice = device.Id;
            TypeDevice = byte.Parse(device.TypeCode.ToString());
            tx_bufferBootOff = _bufferBootOff;
            tx_bufferEraseBoot = _bufferEraseBoot;
            tx_bufferResetOk = _bufferResetOk;
            label_TypeDeviceName.Text = xmlTypeDevice.TypeDeviceNameXml(byte.Parse(device.TypeCode.ToString()));
            label_DeviceIdValue.Text = device.Id[0].ToString("X2") + device.Id[1].ToString("X2") + device.Id[2].ToString("X2") + device.Id[3].ToString("X2");
            ValidatePathDirectory(Label_PathFileUpdateDirectory);
        }

        private void OpenFileUpdate_Button_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    ////Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();
                }
            }
            FilePath = filePath;
            if (filePath.Length > 22)
            {
                Label_PathFileUpdateDirectory.Text = filePath.Substring(0, filePath.Length - 10) + "...";
            }
            else
            {
                Label_PathFileUpdateDirectory.Text = filePath;

            }
            ValidatePathDirectory(Label_PathFileUpdateDirectory);
        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            string pathDirectory = FilePath;
            int packageCount = updateFile.PackageLengthMethod(pathDirectory);
            if (updateFile.UpdateFWValidationMethod(pathDirectory, TypeDevice))
            {
                using (SerialPort port = Port.TakeDataPort())
                {
                    try
                    {
                        updateFile.UpdateFW(port, tx_bufferEraseBoot, IdDevice, packageCount, pathDirectory, progressBar1, TypeDevice);
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка во время обновления. Повторите ещё раз.");
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите другой файл");
            }
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

        private void ValidatePathDirectory(Label label_PathDirectory)
        {
            if (label_PathDirectory.Text.Length > 0)
            {
                button_Update.Enabled = true;
            }
            else
            {
                button_Update.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SerialPort port = Port.TakeDataPort())
            {

                //byte[] rx_bufferBoot = new byte[17];
                if (port.IsOpen == false) port.Open();
                port.Write(tx_bufferResetOk, 0, tx_bufferResetOk.Length);
                Thread.Sleep(500); // TO DO
                port.Write(tx_bufferBootOff, 0, tx_bufferBootOff.Length);
            }
            Close();
        }

       
    }
}
