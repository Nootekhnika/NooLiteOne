using NooLiteServiceSoft.Settings;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public partial class SettingFTX : Form
    {
        XmlTypeDevice xmlTypeDevice = new XmlTypeDevice();
        Port portEx = new Port();

        public SettingFTX(Device device)
        {
            InitializeComponent();

            using (SerialPort port = portEx.TakeDataAboutPort())
            {
                byte[] idArray = new byte[4];
                Array.Copy(device.Id, idArray, 4);

                if (device.TypeCode == 2)
                {
                    SettingSRF101000 settingSRF101000 = new SettingSRF101000(on_StateAfterOn, off_StateAfterOn, stateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL, TakeNooLiteCommand, on_State, off_State, stateMemorization);
                    settingSRF101000.OperationWithElements();
                    labelDeviceSetting.Text = $"Настройка устройства: {xmlTypeDevice.TypeDeviceNameXml(byte.Parse(device.TypeCode.ToString()))}";
                    byte[] resultRequest = settingSRF101000.DeviceSettings(port, device.Channel.ToString(), 2, idArray);
                    byte[] resultByte = new byte[resultRequest.Length];
                    Array.Copy(resultRequest, resultByte, resultRequest.Length);
                    settingSRF101000.SRF101000Status(resultByte, on_State, off_State, allowReceivingCommandFromNL, banReceivingCommandFromNL);
                    save_btn.Click += delegate (object _sender, EventArgs _e) { settingSRF101000.WriteSettingSRF101000(this, port, device.Channel.ToString(), 3, idArray, on_State, off_State, allowReceivingCommandFromNL, banReceivingCommandFromNL); };
                }

                if (device.TypeCode == 3 || device.TypeCode == 4)
                {
                    SettingSRF13000 settingsSRF13000 = new SettingSRF13000();
                    labelDeviceSetting.Text = $"Настройка устройства: {xmlTypeDevice.TypeDeviceNameXml(byte.Parse(device.TypeCode.ToString()))}";
                    byte[] resultRequest = settingsSRF13000.DeviceSettings(port, device.Channel.ToString(), 3, idArray);
                    byte[] resultByte = new byte[resultRequest.Length];
                    Array.Copy(resultRequest, resultByte, resultRequest.Length);
                    settingsSRF13000.SRF13000Status(resultByte, on_State, off_State, on_StateAfterOn, off_StateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL);
                    save_btn.Click += delegate (object _sender, EventArgs _e) { settingsSRF13000.WriteSettingSRF13000(this, port, device.Channel.ToString(), 3, idArray, on_State, off_State, on_StateAfterOn, off_StateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL); };
                    on_State.Click += delegate (object _sender, EventArgs _e) { settingsSRF13000.BlockedRadioButton(on_State, on_StateAfterOn, off_StateAfterOn); };
                    off_State.Click += delegate (object _sender, EventArgs _e) { settingsSRF13000.UnBlockedRadioButton(off_State, on_StateAfterOn, off_StateAfterOn); };
                }

                if (device.TypeCode == 5)
                {
                    SettingSUF1300 settingSUF1300 = new SettingSUF1300();
                    labelDeviceSetting.Text = $"Настройка устройства: {xmlTypeDevice.TypeDeviceNameXml(byte.Parse(device.TypeCode.ToString()))}";
                    settingSUF1300.FormDesign(this, save_btn, cancel_btn, panel3, panel4, panel1);
                    byte[] resultRequest = settingSUF1300.SUF1300(port, device.Channel.ToString(), 5, idArray);
                    byte[] resultByte = new byte[resultRequest.Length];
                    Array.Copy(resultRequest, resultByte, resultRequest.Length);
                    settingSUF1300.SUF1300Status(resultByte, on_State, off_State, on_StateAfterOn, off_StateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL);
                    save_btn.Click += delegate (object _sender, EventArgs _e) { settingSUF1300.WriteSettingSUF1300(this, port, device.Channel.ToString(), 5, idArray, on_State, off_State, on_StateAfterOn, off_StateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL); };
                    on_State.Click += delegate (object _sender, EventArgs _e) { settingSUF1300.BlockedRadioButtonOnState(on_State, on_StateAfterOn, off_StateAfterOn); };
                    off_State.Click += delegate (object _sender, EventArgs _e) { settingSUF1300.UnBlockedRadioButtonOffState(off_State, on_StateAfterOn, off_StateAfterOn); };
                }

                if (device.TypeCode == 6)
                {
                    SettingSRF103000T settingSRF103000T = new SettingSRF103000T(this, stateAfterOn, TakeNooLiteCommand, stateMemorization);
                    labelDeviceSetting.Text = $"Настройка устройства: {xmlTypeDevice.TypeDeviceNameXml(byte.Parse(device.TypeCode.ToString()))}";
                    settingSRF103000T.FormDesign(this, save_btn, cancel_btn, panel4);
                    byte[] resultRequest = settingSRF103000T.DeviceSettings(port, device.Channel.ToString(), 6, idArray);
                    byte[] resultByte = new byte[resultRequest.Length];
                    Array.Copy(resultRequest, resultByte, resultRequest.Length);
                    settingSRF103000T.SUF13000TStatus(resultByte);
                    save_btn.Click += delegate (object _sender, EventArgs _e) { settingSRF103000T.WriteSettingSRF13000T(this, port, device.Channel.ToString(), 6, idArray); };
                }

                if (device.TypeCode == 7)
                {
                    SettingSRF1000R settingSRF1000R = new SettingSRF1000R(this, stateAfterOn, on_State, off_State, allowReceivingCommandFromNL, banReceivingCommandFromNL);
                    labelDeviceSetting.Text = $"Настройка устройства: {xmlTypeDevice.TypeDeviceNameXml(byte.Parse(device.TypeCode.ToString()))}";
                    settingSRF1000R.FormDesign(this);
                    byte[] resultRequest = settingSRF1000R.DeviceSettings(port, device.Channel.ToString(), 7, idArray);
                    byte[] resultByte = new byte[resultRequest.Length];
                    Array.Copy(resultRequest, resultByte, resultRequest.Length);
                    settingSRF1000R.SUF11000RStatus(resultByte);
                    save_btn.Click += delegate (object _sender, EventArgs _e) { settingSRF1000R.WriteSettingSRF11000R(this, port, device.Channel.ToString(), 7, idArray); };
                }
            }
        }

        private void Remove_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
