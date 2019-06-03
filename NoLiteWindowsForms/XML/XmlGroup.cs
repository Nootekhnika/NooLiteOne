using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NooLiteServiceSoft.XML
{
    public class XmlGroup
    {
        public void LoadXMLFile(Room room)
        {
            XDocument xdocs = XDocument.Load("rooms.xml");

            var roomElements = xdocs.Descendants().Elements("room");

            XElement group = new XElement("room");
            XElement rooms = new XElement("rooms");

            foreach (XElement xe in roomElements)
            {
                rooms.Add(xe);
            }
            // create attr
            XAttribute GroupNameAttr = new XAttribute("name", room.RoomName);
            XElement groupId = new XElement("roomId", room.Id);
            group.Add(GroupNameAttr);
            group.Add(groupId);
            xdocs.Root.Add(group);
            //save document
            xdocs.Save("rooms.xml");
        }

        public void CreateXmlFile(Room room)
        {
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));

            XElement group = new XElement("room");
            // create attr
            XAttribute GroupNameAttr = new XAttribute("name", room.RoomName);
            XElement groupId = new XElement("roomId",room.Id);
            XElement groups = new XElement("rooms");
            group.Add(GroupNameAttr);
            group.Add(groupId);
            groups.Add(group);
            xdocs.Add(groups);
            //save document
            xdocs.Save("rooms.xml");
        }

        public string[] RoomNameXml()
        {
            try
            {
                
                XDocument xdoc = XDocument.Load("rooms.xml");
                int count = 0;
                var roomElements = from el in xdoc.Root.Elements("room")
                                     select new
                                     {
                                         dName = el.Attribute("name")
                                     };
                var roomName = new string[roomElements.Count()];
                foreach (var param in roomElements)
                {
                    roomName[count] =(string)param.dName;
                    count++;
                }
                return roomName;
            }
            catch (IOException)
            {
                //MessageBox.Show("Ни одной комнаты не добавлено");
            }
            return null;
        }

        public void RemoveRoom(string roomName)
        {
            XDocument xdoc = XDocument.Load("rooms.xml");
            var roomElements = xdoc.Root.Elements("room").Where(s=>s.Attribute("name").Value.Equals(roomName));                             
            roomElements.Remove();
            xdoc.Save("rooms.xml");
            if (File.Exists("devices.xml")==true)
            {
                XDocument xdevice = XDocument.Load("devices.xml");
                var deviceElements = xdoc.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName));
                foreach (var p in deviceElements)
                {
                    p.Element("device").Element("RoomName").Value = "";
                }
                xdevice.Save("devices.xml");
            }
            if (File.Exists("devicesTX.xml") == true)
            {
                XDocument xdeviceTX = XDocument.Load("devicesTX.xml");
                var deviceElementsTX = xdoc.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName));
                foreach (var p in deviceElementsTX)
                {
                    p.Element("device").Element("RoomName").Value = "";
                }
                xdeviceTX.Save("devicesTX.xml");
            }         
        }
    }
}
