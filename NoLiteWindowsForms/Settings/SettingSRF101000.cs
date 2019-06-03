using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
   public  class SettingSRF101000:Device
    {
        private RadioButton on_StateAfterOn;
        private RadioButton off_StateAfterOn;
        private GroupBox stateAfterOn;
        private RadioButton allowReceivingCommandFromNL;
        private RadioButton banReceivingCommandFromNL;
        private GroupBox TakeCommandNL;
        private RadioButton on_State;
        private RadioButton off_State;
        private GroupBox stateMemorization;


        public SettingSRF101000(RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, GroupBox stateAfterOn,RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL, GroupBox takeCommandNL,RadioButton on_State,RadioButton off_State,GroupBox stateMemorization)
        {
            this.on_StateAfterOn = on_StateAfterOn;
            this.off_StateAfterOn = off_StateAfterOn;
            this.stateAfterOn = stateAfterOn;
            this.allowReceivingCommandFromNL = allowReceivingCommandFromNL;
            this.banReceivingCommandFromNL = banReceivingCommandFromNL;
            TakeCommandNL = takeCommandNL;
            this.on_State = on_State;
            this.off_State = off_State;
            this.stateMemorization = stateMemorization;
            
        }

        public void OperationWithElements()
        {
            off_StateAfterOn.Visible = false;
            on_StateAfterOn.Visible = false;
            stateAfterOn.Visible = false;
            stateMemorization.Left = 107;
            TakeCommandNL.Left = 307;
        }

        //public byte[] SRF101000(SerialPort port, string devicesChannel, byte typeCode, byte[] idArray)
        //{
        //    byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 16, 0, 0, 0, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
        //    byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
        //    byte[] rx_bufferSettingRequest = new byte[17];

        //    if (port.IsOpen == false) port.Open();
        //    port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
        //    WaitData(port, rx_bufferSettingRequest);
        //    port.DiscardInBuffer();
        //    if (port.IsOpen) port.Close();

        //    string stringByte = Convert.ToString(rx_bufferSettingRequest[7], 2);
        //    //byte[] arrayByte = new byte[stringByte.Length];

        //    byte[] arrayByte = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
        //    int count = stringByte.Length - 1;
        //    foreach (var b in stringByte)
        //    {
        //        arrayByte[count] = byte.Parse(b.ToString());
        //        count--;
        //    }
        //    return arrayByte;
        //}

        public void WriteSettingSRF101000(SettingFTX settingFTX, SerialPort port, string devicesChannel, byte typeCode, byte[] idArray, RadioButton on_State, RadioButton off_State, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
        {
            byte d0 = SaveSRF101000Setting(on_State, off_State, allowReceivingCommandFromNL, banReceivingCommandFromNL);
            byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 129, 16, d0, 0, 127, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
            if (port.IsOpen == false) port.Open();
            port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
            port.DiscardInBuffer();
            if (port.IsOpen) port.Close();
            settingFTX.Close();
        }

        public void SRF101000Status(byte[] resultByte, RadioButton on_State, RadioButton off_State, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
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
        }


        private byte SaveSRF101000Setting(RadioButton on_State, RadioButton off_State,RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
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
            foreach (var b in resultByte)
            {
                stringByte += b;
            }
            return Convert.ToByte(stringByte, 2);
        }
    }
}
