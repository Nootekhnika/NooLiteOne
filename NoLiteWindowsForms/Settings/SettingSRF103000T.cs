using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
    public class SettingSRF103000T : Device
    {
        private RadioButton HandsModeRB;
        private RadioButton CalendarRB;
        private RadioButton NLCommandOn;
        private RadioButton NLCommandOff;
        private RadioButton SensorFloor;
        private RadioButton SensorAir;
        private RadioButton SensorRF;
        private RadioButton SaveStateOn;
        private RadioButton SaveStateOff;
        private RadioButton StateOn;
        private RadioButton StateOff;

        public SettingSRF103000T(Form form, GroupBox stateAfterOn, GroupBox takeCommandNL, GroupBox stateMemorization)
        {
            form.Controls.Remove(stateAfterOn);
            form.Controls.Remove(takeCommandNL);
            form.Controls.Remove(stateMemorization);
        }

        public void FormDesign(SettingFTX settingFTX, Button buttonSave, Button buttonCancel)
        {
            settingFTX.Width = 625;
            settingFTX.Height = 350;
            buttonSave.Top = 255;
            buttonCancel.Top = 255;
            GroupBox SelectModeGroupBox = new GroupBox()
            {
                Left = 8,
                Top = 40,
                Width = 195,
                Height = 100,
                Text = "Выбор режима",
                BackColor = Color.FromArgb(239, 239, 239)
            };

            RadioButton handsModeRB = new RadioButton
            {
                Text = "Ручной",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            HandsModeRB = handsModeRB;

            RadioButton сalendarRB = new RadioButton
            {
                Text = "Календарный",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5
            };
            CalendarRB = сalendarRB;

            settingFTX.Controls.Add(SelectModeGroupBox);
            SelectModeGroupBox.Controls.Add(HandsModeRB);
            SelectModeGroupBox.Controls.Add(CalendarRB);

            GroupBox TakeNLCommand = new GroupBox
            {
                Left = 207,
                Top = 40,
                Width = 195,
                Height = 100,
                Text = "Приём NooLite",
                BackColor = Color.FromArgb(239, 239, 239)
            };
            RadioButton nlCommandOn = new RadioButton
            {
                Text = "Разрешён",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            NLCommandOn = nlCommandOn;

            RadioButton nlCommandOff = new RadioButton
            {
                Text = "Запрещён",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5

            };
            NLCommandOff = nlCommandOff;
            settingFTX.Controls.Add(TakeNLCommand);
            TakeNLCommand.Controls.Add(NLCommandOn);
            TakeNLCommand.Controls.Add(NLCommandOff);

            GroupBox SelectSensor = new GroupBox
            {
                Left = 406,
                Top = 40,
                Width = 195,
                Height = 100,
                Text = "Выбор активного датчика",
                BackColor = Color.FromArgb(239, 239, 239)
            };
            RadioButton sensorFloor = new RadioButton
            {
                Text = "Датчик пола",
                Width = 250,
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 20,
                Left = 5

            };
            SensorFloor = sensorFloor;

            RadioButton sensorAir = new RadioButton
            {
                Text = "Датчик воздуха",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 45,
                Left = 5,
                Width = 150,
                Height = 20

            };
            SensorAir = sensorAir;

            RadioButton sensorRF = new RadioButton
            {
                Text = "RF датчик",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5

            };
            SensorRF = sensorRF;

            settingFTX.Controls.Add(SelectSensor);
            SelectSensor.Controls.Add(SensorFloor);
            SelectSensor.Controls.Add(SensorAir);
            SelectSensor.Controls.Add(SensorRF);

            GroupBox SaveState = new GroupBox
            {
                Left = 5,
                Top = 145,
                Width = 195,
                Height = 100,
                Text = "Запоминание состояния",
                BackColor = Color.FromArgb(239, 239, 239)
            };
            RadioButton saveStateOn = new RadioButton
            {
                Text = "Включено",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            SaveStateOn = saveStateOn;

            RadioButton saveStateOff = new RadioButton
            {
                Text = "Выключено",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5

            };
            SaveStateOff = saveStateOff;
            settingFTX.Controls.Add(SaveState);
            SaveState.Controls.Add(SaveStateOn);
            SaveState.Controls.Add(SaveStateOff);

            GroupBox StateStatus = new GroupBox
            {
                Left = 207,
                Top = 145,
                Width = 195,
                Height = 100,
                Text = "Статус состояния",
                BackColor = Color.FromArgb(239, 239, 239)
            };
            RadioButton stateOn = new RadioButton
            {
                Text = "Включено",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            StateOn = stateOn;

            RadioButton stateOff = new RadioButton
            {
                Text = "Выключено",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5

            };
            StateOff = stateOff;
            settingFTX.Controls.Add(StateStatus);
            StateStatus.Controls.Add(StateOn);
            StateStatus.Controls.Add(StateOff);
            SaveStateOn.Click += delegate (object _sender, EventArgs _e) { BlockedRadioButtonOnState(SaveStateOn, StateOn, StateOff); };
            SaveStateOff.Click += delegate (object _sender, EventArgs _e) { UnBlockedRadioButtonOffState(SaveStateOff, StateOn, StateOff); };

        }


        public void BlockedRadioButtonOnState(RadioButton radioButton, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn)
        {
            if (radioButton.Checked == true)
            {
                on_StateAfterOn.Enabled = false;
                off_StateAfterOn.Enabled = false;
            }
        }
        public void UnBlockedRadioButtonOffState(RadioButton radioButton, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn)
        {
            if (radioButton.Checked == true)
            {
                on_StateAfterOn.Enabled = true;
                off_StateAfterOn.Enabled = true;
            }
        }


        //public byte[] SUF130000T(SerialPort port, string devicesChannel, byte typeCode, byte[] idArray)
        //{
        //    byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 16, 0, 0, 0, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
        //    byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
        //    byte[] rx_bufferSettingRequest = new byte[17];
        //    if (port.IsOpen == false) port.Open();
        //    port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
        //    WaitData(port, rx_bufferSettingRequest);
        //    if (port.IsOpen) port.Close();
        //    string stringByte = Convert.ToString(rx_bufferSettingRequest[7], 2);
        //    byte[] arrayByte = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
        //    int count = stringByte.Length - 1;
        //    foreach (var b in stringByte)
        //    {
        //        arrayByte[count] = byte.Parse(b.ToString());
        //        count--;
        //    }
        //    return arrayByte;
        //}

        public void SUF13000TStatus(byte[] resultByte)
        {
            if (resultByte[0] == 1)
            {
                HandsModeRB.Checked = true;
                CalendarRB.Checked = false;
                CalendarRB.Enabled = false;
            }
            else
            {
                CalendarRB.Checked = true;
                CalendarRB.Enabled = false;
                HandsModeRB.Checked = false;
            }

            if (resultByte[1] == 1)
            {
                SensorRF.Checked = true;
            }

            else
            {
                SensorRF.Checked = false;
            }

            if (resultByte[2] == 1)
            {
                NLCommandOn.Checked = false;
                NLCommandOff.Checked = true;
            }
            else
            {
                NLCommandOn.Checked = true;
                NLCommandOff.Checked = false;
            }
            if (resultByte[3] == 1)
            {
                SensorFloor.Checked = false;
                SensorAir.Checked = true;
            }
            else
            {
                SensorFloor.Checked = true;
                SensorAir.Checked = false;
            }


            if (resultByte[4] == 1)
            {
                SaveStateOn.Checked = true;
                SaveStateOff.Checked = false;
                StateOn.Enabled = false;
                StateOff.Enabled = false;
            }
            else
            {
                SaveStateOn.Checked = false;
                SaveStateOff.Checked = true;
                StateOn.Enabled = true;
                StateOff.Enabled = true;
            }

            if (resultByte[5] == 1)
            {
                StateOn.Checked = true;
                StateOff.Checked = false;
            }
            else
            {
                StateOn.Checked = false;
                StateOff.Checked = true;
            }

        }



        public void WriteSettingSRF13000T(SettingFTX settingFTX, SerialPort port, string devicesChannel, byte typeCode, byte[] idArray)
        {
            byte d0 = SaveSUF13000TSetting(HandsModeRB, NLCommandOn, SensorFloor, SensorRF, SaveStateOn, StateOn);
            byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 129, 16, d0, 0, 127, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
            if (port.IsOpen == false) port.Open();
            port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
            port.DiscardInBuffer();
            if (port.IsOpen) port.Close();
            settingFTX.Close();
        }

        private byte SaveSUF13000TSetting(RadioButton HandsModeRB, RadioButton NLCommandOn, RadioButton SensorFloor,RadioButton SensorRF, RadioButton SaveStateOn, RadioButton StateOn)
        {
            byte[] resultByte = new byte[6];
            string stringByte = "";

            if (HandsModeRB.Checked == true)
            {
                resultByte[5] = 1;//1 бит
            }
            else
            {
                resultByte[5] = 0;
            }

            if(SensorRF.Checked == true)
            {
                resultByte[4] = 1;
            }
            else
            {
                resultByte[4] = 0;
            }
            if (NLCommandOn.Checked == true)
            {
                resultByte[3] = 0;
            }
            else
            {
                resultByte[3] = 1;
            }

            if (SensorFloor.Checked == true)
            {
                resultByte[2] = 0;
            }
            else
            {
                resultByte[2] = 1;
            }

            if (SaveStateOn.Checked == true)
            {
                resultByte[1] = 1;
            }
            else
            {
                resultByte[1] = 0;
            }

            if (StateOn.Checked == true)
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

            return Convert.ToByte(stringByte, 2);

        }
    }
}
