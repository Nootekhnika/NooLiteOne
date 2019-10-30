using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public class SettingSRF13000:Device
    {
        public void WriteSettingSRF13000(SettingFTX settingFTX, SerialPort port, string devicesChannel, byte typeCode, byte[] idArray, RadioButton on_State, RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
        {
            try
            {
                byte d0 = SaveSRF13000Setting(on_State, off_State, on_StateAfterOn, off_StateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL);
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

        public void SRF13000Status(byte[] resultByte, RadioButton on_State, RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
        {
            if (resultByte[0] == 1)
            {
                on_State.Checked = true;
                off_State.Checked = false;
                on_StateAfterOn.Enabled = false;
                off_StateAfterOn.Enabled = false;
            }
            else
            {
                off_State.Checked = true;
                on_State.Checked = false;
            }
            if (resultByte[2] == 1)
            {
                allowReceivingCommandFromNL.Checked = false;
                banReceivingCommandFromNL.Checked = true;
            }
            else
            {
                allowReceivingCommandFromNL.Checked = true;
                banReceivingCommandFromNL.Checked = false;
            }
            if(resultByte[5] == 1)
            {
                on_StateAfterOn.Checked = true;
                off_StateAfterOn.Checked = false;
            }
            else
            {
                on_StateAfterOn.Checked = false;
                off_StateAfterOn.Checked = true;
            }
        }
        public void BlockedRadioButton(RadioButton on_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn)
        {
            if(on_State.Checked == true)
            {
                on_StateAfterOn.Enabled = false;
                off_StateAfterOn.Enabled = false;
            }
        }

        public void UnBlockedRadioButton(RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn)
        {
            if (off_State.Checked == true)
            {
                on_StateAfterOn.Enabled = true;
                off_StateAfterOn.Enabled = true;
            }
        }

        private static byte SaveSRF13000Setting(RadioButton on_State, RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
        {
            byte[] resultByte = new byte[6];
            string stringByte = "";
            if (on_State.Checked == true)
            {
                resultByte[5] = 1;
            }
            else
            {
                resultByte[5] = 0;

            }
            if (allowReceivingCommandFromNL.Checked == false)
            {
                resultByte[3] = 1;
            }
            else
            {
                resultByte[3] = 0;
            }

            if (on_StateAfterOn.Checked == true)
            {
                resultByte[0] = 1;

            }
            else
            {
                resultByte[0] = 0;
            }

            foreach (var b in resultByte)
            {
                stringByte += b;
            }
            return Convert.ToByte(stringByte,2);         
        }
    }
}
