using NooLiteServiceSoft.XML;
using System;
using System.IO;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormSplashScreen screen = new FormSplashScreen();
            screen.Show();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Port port = new Port();
                XmlPort xmlPort = new XmlPort();
                if (File.Exists("port.xml") != true)
                {
                    port.CreatePort(true);
                    port.ValidationPortId(port);
                }
                else
                {
                    string[] portOldId = xmlPort.PortIdXml();
                    File.Delete("port.xml");
                    port.CreatePort(true);
                    port.ValidationPortId(port, portOldId);
                }
                screen.Hide();
                Application.Run(new FormMain());
            }
            catch
            {
                Application.Run(new DisconnectMTRF());
            }
        }
    }
}
