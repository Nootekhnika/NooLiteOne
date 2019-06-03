using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.DeviceProperties
{
    public partial class DeviceProperty : Form
    {
        XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();

        const byte SRF101000 = 2;
        
       

        public DeviceProperty(byte[] deviceParams, byte[] secondDeviceParams,byte[] activeChannel,string status)
        {
            InitializeComponent();
            labelValue_TypeDevice.Text = xmlTypeDevice.TypeDeviceNameXml(deviceParams[7]);
            labelValue_IdDevice.Text = $"{secondDeviceParams[11].ToString("X2")}{secondDeviceParams[12].ToString("X2")}{secondDeviceParams[13].ToString("X2")}{secondDeviceParams[14].ToString("X2")}";
            labelValue_VersionSoftware.Text = deviceParams[8].ToString();
            labelValue_Status.Text = status;
            label_ParamDevice.Text = $"{xmlTypeDevice.DeviceParamXml(deviceParams[7])}:";
            labelValue_ParamDevice.Text = $"{ xmlTypeDevice.DeviceParamNowXml(deviceParams)} { xmlTypeDevice.DeviceMeansureXml(deviceParams[7])}";
            labelValue_FreeNooLite.Text = secondDeviceParams[9].ToString();
            labelValue_NooLiteF.Text = secondDeviceParams[10].ToString();
            if (deviceParams[7] == SRF101000)
            {
                label_ActiveChannel.Visible = true;
                labelValue_ActiveChannel.Visible = true;
                labelValue_ActiveChannel.Text = activeChannel[9].ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
