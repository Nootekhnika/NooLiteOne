using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NooLiteServiceSoft
{
    public class XmlDevice
    {
        public void LoadXMLFile(Device dvc)
        {
            XDocument xdoc = XDocument.Load("devices.xml");

            var deviceElements = from el in xdoc.Descendants().Elements("device") select el;
            XElement device = new XElement("device");
            XElement devices = new XElement("devices");

            foreach (XElement xe in deviceElements)
            {
                devices.Add(xe);
            }
            // создаем атрибут
            XAttribute DeviceNameAttr = new XAttribute("name", dvc.NameDevice);
            XElement TypeDeviceId = new XElement("typeDeviceId", dvc.TypeCode);
            XElement ChannelElem = new XElement("channel", dvc.Channel);
            XElement Mode = new XElement("mode", dvc.Mode);
            XElement DeviceId = new XElement("IdDevice");
            XElement D0 = new XElement("D0", dvc.Id[0]);
            XElement D1 = new XElement("D1", dvc.Id[1]);
            XElement D2 = new XElement("D2", dvc.Id[2]);
            XElement D3 = new XElement("D3", dvc.Id[3]);
            XElement RoomName = new XElement("RoomName", dvc.RoomName);
            DeviceId.Add(D0);
            DeviceId.Add(D1);
            DeviceId.Add(D2);
            DeviceId.Add(D3);
            device.Add(DeviceId);
            device.Add(DeviceNameAttr);
            device.Add(Mode);
            device.Add(TypeDeviceId);
            device.Add(ChannelElem);
            device.Add(RoomName);
            devices.Add(device);
            xdoc.Root.Add(device);
            //сохраняем документ
            xdoc.Save("devices.xml");
        }

        internal void DeviceChannelXmlTX(string[] devicesChannelTX)
        {
            throw new NotImplementedException();
        }

        public void CreateXmlFile(Device dvc)
        {
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));

            XElement device = new XElement("device");
            // create attr
            XAttribute DeviceNameAttr = new XAttribute("name", dvc.NameDevice);
            XElement ChannelElem = new XElement("channel", dvc.Channel);
            XElement TypeDeviceId = new XElement("typeDeviceId", dvc.TypeCode);
            XElement Mode = new XElement("mode", dvc.Mode);
            XElement DeviceId = new XElement("IdDevice");
            XElement D0 = new XElement("D0", dvc.Id[0]);
            XElement D1 = new XElement("D1", dvc.Id[1]);
            XElement D2 = new XElement("D2", dvc.Id[2]);
            XElement D3 = new XElement("D3", dvc.Id[3]);
            XElement RoomName = new XElement("RoomName", dvc.RoomName);

            DeviceId.Add(D0);
            DeviceId.Add(D1);
            DeviceId.Add(D2);
            DeviceId.Add(D3);
            // add attr and elem in first elem
            device.Add(DeviceId);
            device.Add(DeviceNameAttr);
            device.Add(Mode);
            device.Add(TypeDeviceId);
            device.Add(ChannelElem);
            device.Add(RoomName);
            XElement devices = new XElement("devices");

            devices.Add(device);

            xdocs.Add(devices);
            //save document
            xdocs.Save("devices.xml");
        }

        public void CreateXmlFile()
        {
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));            
            XElement devices = new XElement("devices");           
            xdocs.Add(devices);
            //save document
            xdocs.Save("devices.xml");
        }

        public void LoadXMLFileTX(DeviceTX dvc)
        {
            XDocument xdoc = XDocument.Load("devicesTX.xml");

            var deviceElements = from el in xdoc.Descendants().Elements("device") select el;
            XElement device = new XElement("device");
            XElement devices = new XElement("devices");

            foreach (XElement xe in deviceElements)
            {
                devices.Add(xe);
            }
            // create attr
            XAttribute DeviceNameAttr = new XAttribute("name", dvc.NameDevice);
            XElement TypeDeviceId = new XElement("typeDevice", dvc.TypeName);
            XElement ChannelElem = new XElement("channel", dvc.Channel);
            XElement Mode = new XElement("mode", dvc.Mode);
            XElement RoomName = new XElement("RoomName", dvc.RoomName);
            // add attr and elem in first elem
            device.Add(DeviceNameAttr);
            device.Add(Mode);
            device.Add(TypeDeviceId);
            device.Add(ChannelElem);
            device.Add(RoomName);
            devices.Add(device);
            xdoc.Root.Add(device);
            //save document
            xdoc.Save("devicesTX.xml");
        }

        public void CreateXmlFileTX(DeviceTX dvc)
        {
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement device = new XElement("device");
            // создаем атрибут
            XAttribute DeviceNameAttr = new XAttribute("name", dvc.NameDevice);
            XElement ChannelElem = new XElement("channel", dvc.Channel);
            XElement TypeDeviceId = new XElement("typeDevice", dvc.TypeName);
            XElement Mode = new XElement("mode", dvc.Mode);
            XElement RoomName = new XElement("RoomName", dvc.RoomName);
            // добавляем атрибут и элементы в первый элемент    
            device.Add(DeviceNameAttr);
            device.Add(Mode);
            device.Add(TypeDeviceId);
            device.Add(ChannelElem);
            device.Add(RoomName);
            XElement devices = new XElement("devices");
            devices.Add(device);
            xdocs.Add(devices);
            //сохраняем документ
            xdocs.Save("devicesTX.xml");
        }

        public int DeviceCountXml()
        {
            try
            {
                XDocument xdoc = XDocument.Load("devices.xml");
                var deviceElements = from el in xdoc.Descendants().Elements("device") select el;
                int count = 0;
                foreach (XElement xe in deviceElements)
                {
                    count++;
                }
                return count;
            }
            catch (IOException)
            {
                return 0;
            }
        }

        public int DeviceCountXmlTX()
        {
            try
            {
                XDocument xdoc = XDocument.Load("devicesTX.xml");
                var deviceElements = from el in xdoc.Descendants().Elements("device") select el;
                int count = 0;
                foreach (XElement xe in deviceElements)
                {
                    count++;
                }
                return count;
            }
            catch (IOException)
            {
                return 0;
            }
        }


        public string[] DeviceNameXml(string savePath)
        {
            try
            {
                XDocument xdoc = XDocument.Load(savePath);
                int count = 0;
                var deviceElements = from el in xdoc.Root.Elements("device")
                                     select new
                                     {
                                         dName = el.Attribute("name")
                                     };
                string[] deviceName = new string[deviceElements.Count()];
                foreach (var param in deviceElements)
                {
                    deviceName[count] = (string)param.dName;
                    count++;
                }
                return deviceName;
            }
            catch (IOException)
            {
                //MessageBox.Show("Ни одного устройства не добавлено");
            }
            string[] deviceNameReturn = new string[0];
            return deviceNameReturn;
        }

        public string[] DeviceNameXmlInRoom(string roomName, string path)
        {
            try
            {
                XDocument xdoc = XDocument.Load(path);
                int count = 0;
                var deviceElements = from el in xdoc.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName))
                                     select new
                                     {
                                         dName = el.Attribute("name")
                                     };
                string[] deviceInRoom = new string[deviceElements.Count()];
                foreach (var param in deviceElements)
                {
                    deviceInRoom[count] = (string)param.dName;
                    count++;
                }
                return deviceInRoom;
            }
            catch (IOException)
            {
                //MessageBox.Show("Ни одного устройства не добавлено");
                string[] deviceInRoom = new string[0];
                return deviceInRoom;
            }
        }

        public void DeviceElementsXml(string[] deviceChannel, string[] deviceType, string[] idDevice)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devices.xml");
                int count = 0;
                string id;
                var deviceElements = from el in xdoc.Root.Elements("device")
                                     select new
                                     {
                                         dChannel = el.Element("channel").Value,
                                         dType = el.Element("typeDeviceId").Value
                                     };

                var IdDeviceElements = from el in xdoc.Root.Elements("device").Elements("IdDevice")
                                       select new
                                       {
                                           dD0 = el.Element("D0").Value,
                                           dD1 = el.Element("D1").Value,
                                           dD2 = el.Element("D2").Value,
                                           dD3 = el.Element("D3").Value
                                       };
                foreach (var param in deviceElements)
                {
                    deviceChannel[count] = param.dChannel;
                    deviceType[count] = param.dType;
                    count++;
                }
                count = 0;
                foreach (var param in IdDeviceElements)
                {
                    id = param.dD0 + "&" + param.dD1 + "&" + param.dD2 + "&" + param.dD3;
                    idDevice[count] = id;
                    count++;
                }
            }
            catch (IOException)
            {
            }
        }

        public void DeviceElementsXml(string[] deviceChannel, string[] deviceType, string[] idDevice, string roomName)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devices.xml");
                int count = 0;
                string id;
                var deviceElements = from el in xdoc.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName))
                                     select new
                                     {
                                         dChannel = el.Element("channel").Value,
                                         dType = el.Element("typeDeviceId").Value
                                     };

                var IdDeviceElements = from el in xdoc.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName)).Elements("IdDevice")
                                       select new
                                       {
                                           dD0 = el.Element("D0").Value,
                                           dD1 = el.Element("D1").Value,
                                           dD2 = el.Element("D2").Value,
                                           dD3 = el.Element("D3").Value
                                       };
                foreach (var param in deviceElements)
                {
                    deviceChannel[count] = param.dChannel;
                    deviceType[count] = param.dType;
                    count++;
                }
                count = 0;
                foreach (var param in IdDeviceElements)
                {
                    id = param.dD0 + "&" + param.dD1 + "&" + param.dD2 + "&" + param.dD3;
                    idDevice[count] = id;
                    count++;
                }
            }
            catch (IOException)
            {
            }
        }

        public void DeviceElementsXmlTX(string[] deviceName, string[] deviceType)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devicesTX.xml");
                int count = 0;
                var deviceElements = from el in xdoc.Root.Elements("device")
                                     select new
                                     {
                                         dName = el.Element("channel").Value,
                                         dType = el.Element("typeDevice").Value
                                     };
                foreach (var param in deviceElements)
                {
                    deviceName[count] = param.dName;
                    deviceType[count] = param.dType;
                    count++;
                }
            }
            catch (IOException)
            {
            }
        }

        public void DeviceElementsXmlRoomTX(string[] deviceName, string[] deviceType, string roomName)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devicesTX.xml");
                int count = 0;
                var deviceElements = from el in xdoc.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName))
                                     select new
                                     {
                                         dName = el.Element("channel").Value,
                                         dType = el.Element("typeDevice").Value
                                     };
                foreach (var param in deviceElements)
                {
                    deviceName[count] = param.dName;
                    deviceType[count] = param.dType;
                    count++;
                }
            }
            catch (IOException)
            {
            }
        }

        public void DeviceRemoveXml(string[] idArray, string devicesChannel)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devices.xml");
                var removeElement = xdoc.Descendants().Elements("device").Where(
                                    p => p.Element("IdDevice").Element("D0").Value == idArray[0] &&
                                    p.Element("IdDevice").Element("D1").Value == idArray[1] &&
                                    p.Element("IdDevice").Element("D2").Value == idArray[2] &&
                                    p.Element("IdDevice").Element("D3").Value == idArray[3] &&
                                    p.Element("channel").Value == devicesChannel).FirstOrDefault();
                //Attributes("name").Where(p => p.Value == deviceName).FirstOrDefault() ;//TODO
                if (removeElement != null)
                {
                    removeElement.Remove();
                    xdoc.Save("devices.xml");
                }
            }
            catch (IOException)
            {
            }
        }

        public void DeviceRemoveAllXml()
        {
            try
            {
                XDocument xdoc = XDocument.Load("devices.xml");
                var removeElement = xdoc.Descendants().Elements("device");
                //Attributes("name").Where(p => p.Value == deviceName).FirstOrDefault() ;//TODO
                if (removeElement != null)
                {
                    removeElement.Remove();
                    xdoc.Save("devices.xml");
                }
            }
            catch (IOException)
            {
            }
        }


        public void DeviceRemoveXmlTX(string devicesChannel)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devicesTX.xml");
                var removeElement = xdoc.Descendants().Elements("device").Where(p =>
                                   p.Element("channel").Value == devicesChannel);
                //Attributes("name").Where(p => p.Value == deviceName).FirstOrDefault() ;//TODO
                if (removeElement != null)
                {
                    removeElement.Remove();
                    xdoc.Save("devicesTX.xml");
                }
            }
            catch (IOException)
            {
            }
        }

        public bool ValidationBindXML(string[] deviceId, byte deviceChannel)
        {
            try
            {
                XDocument xdoc = XDocument.Load("devices.xml");
                var deviceElements = from el in xdoc.Descendants().Elements("device") select el;
                int count = 0;
                foreach (XElement xe in deviceElements)
                {

                    if (xe.Element("IdDevice").Element("D0").Value == deviceId[0].ToString() &&
                       xe.Element("IdDevice").Element("D1").Value == deviceId[1].ToString() &&
                       xe.Element("IdDevice").Element("D2").Value == deviceId[2].ToString() &&
                       xe.Element("IdDevice").Element("D3").Value == deviceId[3].ToString() &&
                       xe.Element("channel").Value == deviceChannel.ToString())
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }

        public void LoadDeviceinXMLFile(string channel, string id, string typeCode)
        {
            if (File.Exists("devices.xml") != true)
            {
                CreateXmlFile();
            }
            XDocument xdoc = XDocument.Load("devices.xml");
            string[] IdDevice = id.Split('/');
            string name = "";
            XElement device = new XElement("device");
            XElement devices = new XElement("devices");
            switch (int.Parse(typeCode))
            {
                case 1:
                    name = "SLF - 1 - 300";
                    break;
                case 2:
                    name = "SRF-10-1000";
                    break;
                case 3:
                    name = "SRF-1-3000";
                    break;
                case 4:
                    name = "SRF-1-3000M";
                    break;
                case 5:
                    name = "SUF-1-300";
                    break;
                case 6:
                    name = "SRF-1-3000-T";
                    break;
                case 7:
                    name = "SRF-1-1000-R";
                    break;
                default:
                    break;
            }
            // создаем атрибут
            XAttribute DeviceNameAttr = new XAttribute("name", name);
            XElement TypeDeviceId = new XElement("typeDeviceId", typeCode);
            XElement ChannelElem = new XElement("channel", channel);
            XElement Mode = new XElement("mode", "NooLite F-TX");
            XElement DeviceId = new XElement("IdDevice");
            XElement D0 = new XElement("D0", IdDevice[0]);
            XElement D1 = new XElement("D1", IdDevice[1]);
            XElement D2 = new XElement("D2", IdDevice[2]);
            XElement D3 = new XElement("D3", IdDevice[3]);
            XElement RoomName = new XElement("RoomName", "");
            DeviceId.Add(D0);
            DeviceId.Add(D1);
            DeviceId.Add(D2);
            DeviceId.Add(D3);
            device.Add(DeviceId);
            device.Add(DeviceNameAttr);
            device.Add(Mode);
            device.Add(TypeDeviceId);
            device.Add(ChannelElem);
            device.Add(RoomName);
            devices.Add(device);
            xdoc.Root.Add(device);
            //сохраняем документ
            xdoc.Save("devices.xml");
        }
    }
}



