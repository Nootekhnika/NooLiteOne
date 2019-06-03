using NooLiteServiceSoft.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NooLiteServiceSoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
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
                Application.Run(new FormMain());
            }
            catch
            {
                Application.Run(new DisconnectMTRF());

            }
        }
    }
}
