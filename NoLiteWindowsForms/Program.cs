using NooLiteServiceSoft.XML;
using System;
using System.Diagnostics;
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
                    LaunchCommandLineApp(Properties.Resources.CDM21228_Setup.ToString());
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

        static void LaunchCommandLineApp(string dir)
        {
            string file_exe = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\\CDM21228_Setup.exe";
            FileStream fs = new FileStream(file_exe, FileMode.Create);
            fs.Write(Properties.Resources.CDM21228_Setup, 0, Properties.Resources.CDM21228_Setup.Length);
            fs.Close();
            Process process = Process.Start(file_exe);
            process.WaitForExit();
            string file2_exe = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\\dotNetFx40_Full_x86_x64.exe";
            FileStream fs2 = new FileStream(file2_exe, FileMode.Create);
            fs2.Write(Properties.Resources.dotNetFx40_Full_x86_x64, 0, Properties.Resources.dotNetFx40_Full_x86_x64.Length);
            fs2.Close();
            Process process2 = Process.Start(file2_exe);
            process2.WaitForExit();
        }
    }
}
