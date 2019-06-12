using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Settings
{
    public class SettingSUF1300:Device
    {
        private RadioButton RelayRB;
        private RadioButton DimerRB;
        private RadioButton RetranslOn;
        private RadioButton RetranslOff;
        private RadioButton SwitchOff;
        private RadioButton Button;
        private RadioButton OffMode;
        private RadioButton NotUsing;
        private TextBox MinValue;
        private TextBox MaxValue;
        private TextBox MinLvlValue;


        public void FormDesign(SettingFTX settingFTX, Button buttonSave, Button buttonCancel)
        {
            settingFTX.Width = 625;
            settingFTX.Height = 440;
            settingFTX.MaximumSize = new Size(625,440);
            settingFTX.MinimumSize = new Size(625, 440);
            buttonSave.Top = 360;
            buttonCancel.Top = 360;
            GroupBox exitType = new GroupBox
            {
                Left = 8,
                Top = 140,
                Width = 195,
                Height = 100,
                Text = "Тип выхода",
                BackColor = Color.FromArgb(239, 239, 239),
                TabIndex = 4
            };
            RadioButton relay = new RadioButton
            {
                Text = "Релейный",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            RelayRB = relay;

            RadioButton dimer = new RadioButton
            {
                Text = "Диммирование",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5
            };
            DimerRB = dimer;

            settingFTX.Controls.Add(exitType);
            exitType.Controls.Add(RelayRB);
            exitType.Controls.Add(DimerRB);

            GroupBox functionRetranclationNooLite = new GroupBox
            {
                Left = 207,
                Top = 140,
                Width = 195,
                Height = 100,
                Text = "Функция Ретрансляции NooLite",
                BackColor = Color.FromArgb(239, 239, 239),
                TabIndex = 5
            };
            RadioButton onRetranslation = new RadioButton
            {
                Text = "Включена",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            RetranslOn = onRetranslation;

            RadioButton offRetranslation = new RadioButton
            {
                Text = "Выключена",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5

            };
            RetranslOff = offRetranslation;
            settingFTX.Controls.Add(functionRetranclationNooLite);
            functionRetranclationNooLite.Controls.Add(RetranslOn);
            functionRetranclationNooLite.Controls.Add(RetranslOff);

            GroupBox operationModeControlInput = new GroupBox
            {
                Left = 406,
                Top = 140,
                Width = 195,
                Height = 210,
                Text = "Режим работы входа управления",
                BackColor = Color.FromArgb(239, 239, 239),
                TabIndex = 6

            };
            RadioButton switchingSwitch = new RadioButton
            {
                Text = "Переключающий выключатель",
                Width = 250,
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5

            };
            SwitchOff = switchingSwitch;

            RadioButton button = new RadioButton
            {
                Text = "Кнопка",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5

            };
            Button = button;

            RadioButton offMode = new RadioButton
            {
                Text = "Выключатель",
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 90,
                Left = 5

            };
            OffMode = offMode;

            RadioButton notUsing = new RadioButton
            {
                Text = "Не используется",
                Width = 200,
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 115,
                Left = 5

            };
            NotUsing = notUsing;

            settingFTX.Controls.Add(operationModeControlInput);
            operationModeControlInput.Controls.Add(SwitchOff);
            operationModeControlInput.Controls.Add(Button);
            operationModeControlInput.Controls.Add(OffMode);
            operationModeControlInput.Controls.Add(NotUsing);

            GroupBox InputDimerValue = new GroupBox
            {
                Left = 8,
                Top = 245,
                Width = 195,
                Height = 105,
                Text = "Коррекция Диммирования",
                BackColor = Color.FromArgb(239, 239, 239),
                TabIndex = 7

            };
            Label minValueLabel = new Label
            {
                Text = "min,%",

                Width = 40,
                Height = 20,
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };
            minValueLabel.Font = new Font("Microsoft Sans Serif", 10);

            Label maxValueLabel = new Label
            {
                Text = "max,%",
                Width = 40,
                Height = 20,
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 65,
                Left = 5
            };
            maxValueLabel.Font = new Font("Microsoft Sans Serif", 10);


            TextBox minValue = new TextBox
            {
                Text = "",
                Width = 50,
                Height = 5,
                BackColor = Color.White,
                Top = 40,
                Left = 45
            };
            MinValue = minValue;
            TextBox maxValue = new TextBox
            {
                Name = "minDimer",
                Text = "",
                Width = 50,
                Height = 5,
                BackColor = Color.White,
                Top = 65,
                Left = 45,
                TabIndex = 3
            };
            MaxValue = maxValue;
            settingFTX.Controls.Add(InputDimerValue);
            InputDimerValue.Controls.Add(minValueLabel);
            InputDimerValue.Controls.Add(maxValueLabel);
            InputDimerValue.Controls.Add(MinValue);
            InputDimerValue.Controls.Add(MaxValue);

            GroupBox InputLvlOn = new GroupBox
            {
                Left = 207,
                Top = 245,
                Width = 195,
                Height = 105,
                Text = "Коррекция уровня включения",
                BackColor = Color.FromArgb(239, 239, 239),
                TabIndex = 8

            };

            Label minLvlValueLabel = new Label
            {
                Text = "Минимальный уровень включения, %",

                Width = 110,
                Height = 100,
                BackColor = Color.FromArgb(239, 239, 239),
                Top = 40,
                Left = 5
            };

            TextBox minLvlValue = new TextBox
            {
                Text = "",
                Width = 50,
                Height = 5,
                BackColor = Color.White,
                Top = 50,
                Left = 125
            };
            MinLvlValue = minLvlValue;
            settingFTX.Controls.Add(InputLvlOn);
            InputLvlOn.Controls.Add(minLvlValueLabel);
            InputLvlOn.Controls.Add(MinLvlValue);

            //cобытия
            dimer.Click += delegate (object _sender, EventArgs _e) { BlockedRadioButton(dimer, onRetranslation, offRetranslation); };//Если выбрано диммирование тогда заблокировать ретрансляцию
            relay.Click += delegate (object _sender, EventArgs _e) { UnBlockedRadioButton(relay, onRetranslation, offRetranslation); };//Если выбрано релле тогда разблокировать ретрансляцию
            minValue.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { ValidatiionKeyPressForTextBox(_sender, _e); };
            maxValue.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { ValidatiionKeyPressForTextBox(_sender, _e); };
            minLvlValue.KeyPress += delegate (object _sender, KeyPressEventArgs _e) { ValidatiionKeyPressForTextBox(_sender, _e); };
        }


        public void BlockedRadioButton(RadioButton DimerRB, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn)
        {
            if (DimerRB.Checked == true)
            {
                MaxValue.Enabled = true;
                MinValue.Enabled = true;
                RetranslOn.Enabled = false;
                RetranslOff.Enabled = false;
                RetranslOff.Checked = true;
                MinLvlValue.Enabled = true;

            }
        }

        public void UnBlockedRadioButton(RadioButton RelayRB, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn)
        {
            if (RelayRB.Checked == true)
            {
                MaxValue.Enabled = false;
                MinValue.Enabled = false;
                RetranslOn.Enabled = true;
                RetranslOff.Enabled = true;
                MinLvlValue.Enabled = false;
            }
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


        public byte[] SUF1300(SerialPort port, string devicesChannel, byte typeCode, byte[] idArray)
        {
            byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 16, 0, 0, 0, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
            byte[] rx_bufferSettingRequest = new byte[17];
            byte[] bufferValueProperties = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 17, 0, 26, 255, 255, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferValueProperties = CRC(bufferValueProperties);
            byte[] rx_bufferValueProperties = new byte[17];
            byte[] bufferLvlValueProperties = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 128, 18, 0, 0, 0, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferLvlValueProperties = CRC(bufferLvlValueProperties);
            byte[] rx_bufferLvlValueProperties = new byte[17];

            if (port.IsOpen == false) port.Open();
            port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
            WaitData(port, rx_bufferSettingRequest);
            port.DiscardInBuffer();
            port.Write(tx_bufferValueProperties, 0, tx_bufferValueProperties.Length);
            WaitData(port, rx_bufferValueProperties);
            port.DiscardInBuffer();
            port.Write(tx_bufferLvlValueProperties, 0, tx_bufferLvlValueProperties.Length);
            WaitData(port, rx_bufferLvlValueProperties);
            if (port.IsOpen) port.Close();
            string stringByte = Convert.ToString(rx_bufferSettingRequest[7], 2);
            byte[] arrayByte = new byte[8] {0,0,0,0,0,0,0,0};
            int count = stringByte.Length-1;
            foreach (var b in stringByte)
            {
                arrayByte[count] = byte.Parse(b.ToString());
                count--;
            }
            //заполнение полей коррекции диммирования 
            MaxValue.Text = (int.Parse(rx_bufferValueProperties[7].ToString()) * 100 / 255).ToString();
            MinValue.Text = (int.Parse(rx_bufferValueProperties[8].ToString()) * 100 / 255).ToString();
            //минимальный уровень включения
            MinLvlValue.Text = (int.Parse(rx_bufferLvlValueProperties[7].ToString()) * 100 / 255).ToString();

            return arrayByte;
        }

        public void WriteSettingSUF1300(SettingFTX settingFTX, SerialPort port, string devicesChannel, byte typeCode, byte[] idArray, RadioButton on_State, RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
        {
            byte d0 = SaveSUF13000Setting(on_State, off_State, on_StateAfterOn, off_StateAfterOn, allowReceivingCommandFromNL, banReceivingCommandFromNL);
            byte minLvlValue;
            byte minValueDim;
            byte maxValueDim;
            minValueDim = byte.Parse(Math.Ceiling((ValueFromTextBox(MinValue) * 255 / 100)).ToString());
            maxValueDim = byte.Parse(Math.Ceiling((ValueFromTextBox(MaxValue) * 255 / 100)).ToString());
            if (int.Parse(MinLvlValue.Text) == 50)//минимальный уровень включения.
            {
                minLvlValue = 128;
            }
            else
            {
                minLvlValue = byte.Parse(Math.Ceiling((ValueFromTextBox(MinLvlValue) * 255 / 100)).ToString());//немного не правильно округляет
            }
            byte[] bufferMainPropertiesFirstWrite = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 129, 16, d0, 0, 127, 0, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferSettingWrite = CRC(bufferMainPropertiesFirstWrite);
            byte[] bufferValueProperties = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 129, 17, maxValueDim, minValueDim, 255, 255, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferValueProperties = CRC(bufferValueProperties);
            //TODO коррекция min max диммирование
            byte[] bufferLvlValueProperties = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 129, 18, minLvlValue, 0, 255, 255, idArray[0], idArray[1], idArray[2], idArray[3], 0, 172 };
            byte[] tx_bufferLvlValueProperties = CRC(bufferLvlValueProperties);
            if (port.IsOpen == false) port.Open();
            port.Write(tx_bufferSettingWrite, 0, tx_bufferSettingWrite.Length);
            port.DiscardInBuffer();
            if (DimerRB.Checked == true)
            {
                //await Task.Delay(TimeSpan.FromMilliseconds(1000));
                port.Write(tx_bufferValueProperties, 0, tx_bufferValueProperties.Length);
                port.DiscardInBuffer();
                Thread.Sleep(300);
                port.Write(tx_bufferLvlValueProperties, 0, tx_bufferLvlValueProperties.Length);
                port.DiscardInBuffer();
            }
            if (port.IsOpen) port.Close();
            settingFTX.Close();
        }

        private byte SaveSUF13000Setting(RadioButton on_State, RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
        {
            byte[] resultByte = new byte[7];
            string stringByte = "";

            if (on_State.Checked == true)
            {
                resultByte[6] = 1;//1 бит
            }
            else
            {
                resultByte[6] = 0;
            }
            
            if (DimerRB.Checked == true)
            {
                resultByte[5] = 1;//2 бит
            }
            else
            {
                resultByte[5] = 0;
            }

            if (banReceivingCommandFromNL.Checked == true)
            {
                resultByte[4] = 1;//3 бит
            }
            else
            {
                resultByte[4] = 0;
            }

            // 1 из 4 выбор
            if (Button.Checked == true)
            {
                resultByte[3] = 1;// 4  и 5 бит
                resultByte[2] = 0;
            }

            if(OffMode.Checked == true)
            {
                resultByte[3] = 0;
                resultByte[2] = 1;
            }

            if(NotUsing.Checked == true)
            {
                resultByte[3] = 1;
                resultByte[2] = 1;
            }

            if(SwitchOff.Checked == true)
            {
                resultByte[3] = 0;
                resultByte[2] = 0;
            }
            ///
            if (on_StateAfterOn.Checked == true)
            {
                resultByte[1] = 1;
            }
            else
            {
                resultByte[1] = 0;
            }

            if(RetranslOn.Checked == true)
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

        public double ValueFromTextBox(TextBox minLvlValue)
        {
            return double.Parse(minLvlValue.Text);
        }
//Статус сделал
        public void SUF1300Status(byte[] resultByte, RadioButton on_State, RadioButton off_State, RadioButton on_StateAfterOn, RadioButton off_StateAfterOn, RadioButton allowReceivingCommandFromNL, RadioButton banReceivingCommandFromNL)
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

            if (resultByte[1] == 1)
            {
                RelayRB.Checked = false;
                DimerRB.Checked = true;
                RetranslOn.Enabled = false;
                RetranslOff.Enabled = false;
                MaxValue.Enabled = true;
                MinValue.Enabled = true;
            }
            else
            {
                DimerRB.Checked = false;
                RelayRB.Checked = true;
                MaxValue.Enabled = false;
                MinValue.Enabled = false;
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

            if(resultByte[3] ==1 && resultByte[4] != 1)
            {
                Button.Checked = true;
                SwitchOff.Checked = false;
                OffMode.Checked = false;
                NotUsing.Checked = false;
            }
            else
            {if(resultByte[3] != 1 && resultByte[4] == 1)
                {
                    Button.Checked = false;
                    SwitchOff.Checked = false;
                    OffMode.Checked = true;
                    NotUsing.Checked = false;
                }
                else
                {
                    if (resultByte[3] == 1 && resultByte[4] == 1)
                    {
                        Button.Checked = false;
                        SwitchOff.Checked = false;
                        OffMode.Checked = false;
                        NotUsing.Checked = true;
                    }
                    else
                    {
                        Button.Checked = false;
                        SwitchOff.Checked = true;
                        OffMode.Checked = false;
                        NotUsing.Checked = false;
                    }
                }
            }

            if (resultByte[5] == 1)
            {
                on_StateAfterOn.Checked = true;
                off_StateAfterOn.Checked = false;
            }
            else
            {
                on_StateAfterOn.Checked = false;
                off_StateAfterOn.Checked = true;
            }

            if (resultByte[6] == 1)
            {
                RetranslOn.Checked = true;
                RetranslOff.Checked = false;
            }
            else
            {
                RetranslOn.Checked = false;
                RetranslOff.Checked = true;
            }
        }

        public void ValidatiionKeyPressForTextBox(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
