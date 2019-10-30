using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace NooLiteServiceSoft.UpdateFW
{
    public class UpdateDeviceFW : Device
    {

        public byte[] BufferBootOff()
        {
            byte[] bufferBootOff = new byte[17] { 171, 5, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_bufferBootOff = CRC(bufferBootOff);
            return tx_bufferBootOff;
        }
        public byte[] BuffeEraseBoot(string[] idArray)
        {
            byte[] bufferErazeBootSend = new byte[26] { 175, 5, 12, 0, 170, 85, 170, 85, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] tx_bufferBootSendOff = CRC(bufferErazeBootSend);
            return tx_bufferBootSendOff;
        }

        public byte[] BuffeResetBoot(string[] idArray)
        {
            byte[] bufferResetOkBootSend = new byte[26] { 175, 5, 14, 0, 170, 85, 170, 85, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] tx_bufferBootSendOff = CRC(bufferResetOkBootSend);
            return tx_bufferBootSendOff;
        }

        public byte[] BuffeWriteUpdateFW(string[] idArray)
        {
            byte[] buffeWriteUpdateFW = new byte[26] { 175, 5, 13, 0, 170, 85, 170, 85, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] tx_bufferBootSendOff = CRC(buffeWriteUpdateFW);
            return tx_bufferBootSendOff;
        }

        private byte[] BuffeResetCRC32(byte[] test, byte[] idDevices)
        {
            byte[] bufferResetOkBootSend = new byte[26] { 175, 5, 14, 0, test[7], test[6], test[5], test[4], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, idDevices[0], idDevices[1], idDevices[2], idDevices[3], 0, 172 };
            byte[] tx_bufferBootSendOff = CRC(bufferResetOkBootSend);
            return tx_bufferBootSendOff;
        }

        public bool FileValidation(string pathDirectory)
        {
            string[] arrPartPathDirectory = pathDirectory.Split('.');
            bool status = false;
            foreach (var p in arrPartPathDirectory)
            {
                if (p.Equals("bin")) status = true;
            }
            return status;
        }

        public bool FileValidation(byte[] file, byte typeDevice)
        {
            if (file[0] == 119 && file[1] == 119 && file[3] == typeDevice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateFWValidationMethod(string pathDirectory, byte typeDevice)
        {
            bool statusValidation = false;
            if (FileValidation(pathDirectory))
            {

                byte[] test = new byte[4];
                using (BinaryReader reader = new BinaryReader(new FileStream(pathDirectory, FileMode.Open)))
                {
                    reader.Read(test, 0, 4);
                }
                if (FileValidation(test, typeDevice))
                {
                    statusValidation = true;
                }
                return statusValidation;
            }

            return statusValidation;
        }

        public int PackageLengthMethod(string pathDirectory)
        {
            byte[] test = new byte[12];
            int resultData = 0;
            using (BinaryReader reader = new BinaryReader(new FileStream(pathDirectory, FileMode.Open)))
            {
                reader.Read(test, 0, 12);
            }
            int packageIntHexOne = test[10];
            int packageIntHexTwo = test[11];
            string hexResultData = packageIntHexOne.ToString("X") + packageIntHexTwo.ToString("X");//TODO
            resultData = int.Parse(hexResultData, System.Globalization.NumberStyles.HexNumber);
            return resultData;
        }

        public void UpdateFW(SerialPort port, byte[] tx_bufferEraseBoot, byte[] idDevices, int fWcount, string pathDirectory, ProgressBar bar, byte typeDevice)
        {
            byte[] rx_bufferResetOk = new byte[17];
            bar.Minimum = 0;
            bar.Maximum = fWcount;
            bar.Step = 1;
            if (port.IsOpen == false) port.Open();
            port.Write(tx_bufferEraseBoot, 0, tx_bufferEraseBoot.Length);
            Thread.Sleep(500);
            using (FileStream reader = new FileStream(pathDirectory, FileMode.Open))
            {
                bool flag = false;
                int count = 0;
                byte[] test = new byte[(fWcount * 16) + 16];
                reader.Read(test, 0, (fWcount * 16) + 16);
                reader.Close();
                port.DiscardInBuffer();
                for (int i = 0; i < fWcount; i++)
                {
                    if (flag)
                    {
                        i--;
                        flag = false;
                    }

                    int toogle = i + 1;
                    byte toogleByte = ToogleByte(toogle);
                    int skip = (i + 1) * 16;
                    byte[] buffeWriteUpdateFW = new byte[26] { 175, 5, 13, toogleByte, test[skip], test[skip + 1], test[skip + 2], test[skip + 3], test[skip + 4], test[skip + 5], test[skip + 6], test[skip + 7], test[skip + 8], test[skip + 9], test[skip + 10], test[skip + 11], test[skip + 12], test[skip + 13], test[skip + 14], test[skip + 15], idDevices[0], idDevices[1], idDevices[2], idDevices[3], 0, 172 };
                    byte[] tx_bufferWriteUpdateFW = CRC(buffeWriteUpdateFW);
                    byte[] rx_bufferWriteUpfateFW = new byte[17];
                    if (i < 3) Thread.Sleep(100);//при обновлении 1-ые пакеты отправляются с задержкой
                    port.Write(tx_bufferWriteUpdateFW, 0, tx_bufferWriteUpdateFW.Length);
                    Thread.Sleep(10);
                    if (typeDevice != 0)
                    {
                        WaitData(port, rx_bufferWriteUpfateFW);
                        if (rx_bufferWriteUpfateFW[0] != 173)
                        {
                            flag = true;
                            count++;
                        }
                    }
                    if (count == 10) break;

                    bar.PerformStep();
                }
                Thread.Sleep(500);
                port.Write(BuffeResetCRC32(test, idDevices), 0, BuffeResetCRC32(test, idDevices).Length);
                if (typeDevice != 0) WaitData(port, rx_bufferResetOk);
                if (ResetAgree(rx_bufferResetOk[2]) == true)
                {
                    port.Write(BufferBootOff(), 0, BufferBootOff().Length);
                }
                if (port.IsOpen) port.Close();
                MessageBox.Show("Обновление завершено");
            }
        }

        private byte ToogleByte(int toogle)
        {
            while (toogle > 255)
            {
                toogle = toogle - 255;
            }
            byte toogleByte = byte.Parse(toogle.ToString());
            if (toogleByte == 0)
            {
                toogleByte++;
            }
            return toogleByte;
        }

        private bool ResetAgree(byte answer)
        {
            if (answer == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PreUpdateFW(SerialPort port, string devicesChannel, string idDevices, string deviceType)
        {
            string[] idArray = idDevices.Split('&');
            byte[] bufferM = new byte[17] { 171, 2, 8, 0, byte.Parse(devicesChannel), 133, 0, 170, 85, 170, 85, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] tx_bufferM = CRC(bufferM);
            byte[] rx_bufferM = new byte[17];
            byte[] buffer = new byte[17] { 171, 5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172 };
            byte[] tx_buffer = CRC(buffer);
            byte[] bufferBoot = new byte[26] { 175, 5, 11, 0, 170, 85, 170, 85, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, byte.Parse(idArray[0]), byte.Parse(idArray[1]), byte.Parse(idArray[2]), byte.Parse(idArray[3]), 0, 172 };
            byte[] tx_bufferBoot = CRC(bufferBoot);
            byte[] rx_bufferBoot = new byte[17];
            WriteData(port, tx_bufferM);
            WaitData(port, rx_bufferM);
            port.Write(tx_buffer, 0, tx_buffer.Length);
            Thread.Sleep(500);
            port.Write(tx_bufferBoot, 0, tx_bufferBoot.Length);
            WaitData(port, rx_bufferBoot);

            if ((rx_bufferBoot[7] == int.Parse(deviceType) && rx_bufferBoot[11] == byte.Parse(idArray[0]) && rx_bufferBoot[12] == byte.Parse(idArray[1]) && rx_bufferBoot[13] == byte.Parse(idArray[2]) && rx_bufferBoot[14] == byte.Parse(idArray[3])) || rx_bufferBoot[7] == 0)
            {
                if (port.IsOpen) port.Close();
                byte[] tx_bufferBootOff = BufferBootOff();
                byte[] tx_bufferEraseBoot = BuffeEraseBoot(idArray);
                byte[] tx_bufferResetBoot = BuffeResetBoot(idArray);
                byte[] tx_bufferWriteUpdate = BuffeWriteUpdateFW(idArray);
                Device device = new Device()
                {
                    TypeCode = rx_bufferBoot[7],
                    Id = new byte[4] { rx_bufferBoot[11], rx_bufferBoot[12], rx_bufferBoot[13], rx_bufferBoot[14] }
                };
                using (UpdateFW updateFW = new UpdateFW(device, tx_bufferBootOff, tx_bufferEraseBoot, tx_bufferResetBoot))
                {
                    updateFW.ShowDialog();
                }
            }
            else
            {
                byte[] tx_bufferError = BufferBootOff();
                port.Write(tx_bufferError, 0, tx_bufferError.Length);
                if (port.IsOpen) port.Close();
                MessageBox.Show("Ошибка! Попробуйте ещё раз");
            }
        }
    }
}
