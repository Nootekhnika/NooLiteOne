using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
    public class SettingSRF1000R : Device
    {
        private RadioButton CalibrationOn;
        private RadioButton CalibrationOff;
        private RadioButton On_State;
        private RadioButton Off_State;
        private Label labelCalibration;
        private RadioButton CmdNlOn;
        private RadioButton CmdNlOff;

        public SettingSRF1000R(Form form, GroupBox stateAfterOn,RadioButton on_State,RadioButton off_State,RadioButton allowReceivingCommandFromNL,RadioButton banReceivingCommandFromNL)
        {
            form.Controls.Remove(stateAfterOn);
            On_State= on_State;
            Off_State = off_State;
            CmdNlOn = allowReceivingCommandFromNL;
            CmdNlOff = banReceivingCommandFromNL;
        }

        public void FormDesign(SettingFTX settingFTX)
        {
            GroupBox Calibration = new GroupBox()
            {
                Left = 207,
                Top = 40,
                Width = 195,
                Height = 96,
                Text = "Калибровка",
                BackColor = Color.FromArgb(239, 239, 239)
            };

            Label calibration = new Label
            {
                Left = 5,
                Top = 50,
                Width = 195,
                Height = 96,
                BackColor = Color.FromArgb(239, 239, 239)
            };

            labelCalibration = calibration;

            RadioButton calibrationOn = new RadioButton
            {
                Text = "Включена",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 34,
                Left = 9
            };
            CalibrationOn = calibrationOn;

            RadioButton calibrationOff = new RadioButton
            {
                Text = "Выключена",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 59,
                Left = 9
            };
            CalibrationOff = calibrationOff;

            settingFTX.Controls.Add(Calibration);
            Calibration.Controls.Add(labelCalibration);
            Calibration.Controls.Add(CalibrationOn);
            Calibration.Controls.Add(CalibrationOff);
        }

        public void SUF11000RStatus(byte[] resultByte)
        {
            if (resultByte[0] == 1)
            {
                On_State.Checked = true;
                Off_State.Checked = false;
            }
            else
            {
                On_State.Checked = false;
                Off_State.Checked = true;
            }

            if (resultByte[2] == 1)
            {

                CmdNlOn.Checked = false;
                CmdNlOff.Checked = true;
            }
            else
            {
                CmdNlOn.Checked = true;
                CmdNlOff.Checked = false;
            }

            if (resultByte[6] == 1)
            {
                CalibrationOn.Checked = true;
                CalibrationOff.Checked = false;
                labelCalibration.Text = "Откалибровано";
            }
            else
            {

                CalibrationOn.Checked = false;
                CalibrationOff.Checked = true;
                labelCalibration.Text = "Неоткалибровано";
            }

            CalibrationOff.Enabled = false;
            CalibrationOn.Enabled = false;
            CalibrationOn.Visible = false;
            CalibrationOn.Visible = false;
        }

        private static byte SaveSRF11000RSetting(RadioButton ColibrationOn, RadioButton on_State, RadioButton allowReceivingCommandFromNL)
        {
            byte[] resultByte = new byte[7];
            string stringByte = "";
            if (ColibrationOn.Checked == true)
            {
                resultByte[0] = 1;
            }
            else
            {
                resultByte[0] = 0;

            }
            if (allowReceivingCommandFromNL.Checked == true)
            {
                resultByte[4] = 0;
            }
            else
            {
                resultByte[4] = 1;
            }

            if (on_State.Checked == true)
            {
                resultByte[6] = 1;

            }
            else
            {
                resultByte[6] = 0;
            }

            foreach (var b in resultByte)
            {
                stringByte += b;
            }
            return Convert.ToByte(stringByte, 2);
        }

        public void WriteSettingSRF11000R(SettingFTX settingFTX, SerialPort port, string devicesChannel, byte typeCode, byte[] idArray)
        {
            try
            {
                byte d0 = SaveSRF11000RSetting(CalibrationOn, On_State, CmdNlOn);
                byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 129, 16, d0, 0, 127, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
                byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
                if (port.IsOpen == false) port.Open();
                port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
                port.DiscardInBuffer();
                if (port.IsOpen) port.Close();
                settingFTX.Close();
            }
            catch
            {
                using (DisconnectMTRF disconnectMTRF = new DisconnectMTRF())
                {
                    disconnectMTRF.ShowDialog();
                }
                Application.Exit();
            }
        }
    }
}
