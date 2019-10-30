using System.IO;
using System.Linq;
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
            XAttribute GroupNameAttr = new XAttribute("name", room.RoomName);
            XElement groupId = new XElement("roomId", room.Id);
            group.Add(GroupNameAttr);
            group.Add(groupId);
            xdocs.Root.Add(group);
            xdocs.Save("rooms.xml");
        }

        public void CreateXmlFile(Room room)
        {
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement group = new XElement("room");
            XAttribute GroupNameAttr = new XAttribute("name", room.RoomName);
            XElement groupId = new XElement("roomId", room.Id);
            XElement groups = new XElement("rooms");
            group.Add(GroupNameAttr);
            group.Add(groupId);
            groups.Add(group);
            xdocs.Add(groups);
            xdocs.Save("rooms.xml");
        }

        public void CreateXmlFile()
        {
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement groups = new XElement("rooms");
            xdocs.Add(groups);
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
                    roomName[count] = (string)param.dName;
                    count++;
                }
                return roomName;
            }
            catch (IOException)
            {
            }
            return null;
        }

        public bool CheckUniqueRoom(string roomName)
        {
            XDocument xdoc = XDocument.Load("rooms.xml");
            var roomElements = xdoc.Root.Elements("room").Where(s => s.Attribute("name").Value.Equals(roomName));
            if (roomElements.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateRoom(string roomName, string newRoomName, TabPage page, TabPage mainPage)
        {
            XDocument xdoc = XDocument.Load("rooms.xml");
            XDocument xdocdevice = XDocument.Load("devices.xml");
            XDocument xdocdeviceTX = XDocument.Load("devicesTX.xml");
            var query = from c in xdoc.Root.Elements("room")
                        select c;
            var queryDevice = from c in xdocdevice.Root.Elements("device")
                              select c;
            var queryDeviceTX = from c in xdocdeviceTX.Root.Elements("device")
                                select c;
            foreach (XElement p in query)
            {
                if (p.Attribute("name").Value.Equals(roomName))
                {
                    p.Attribute("name").Value = newRoomName;

                    xdoc.Save("rooms.xml");
                    page.Text = newRoomName;
                }
            }

            foreach (XElement p in queryDevice)
            {
                if (p.Element("RoomName").Value.Equals(roomName))
                {
                    p.Element("RoomName").Value = newRoomName;

                    xdocdevice.Save("devices.xml");
                }
            }

            foreach (XElement p in queryDeviceTX)
            {
                if (p.Element("RoomName").Value.Equals(roomName))
                {
                    p.Element("RoomName").Value = newRoomName;

                    xdocdeviceTX.Save("devicesTX.xml");
                }
            }
            foreach (PictureBox p in mainPage.Controls)
            {
                UpdatePictureBox(p);
            };

            void UpdatePictureBox(PictureBox p)
            {
                foreach (var g in p.Controls)
                {
                    if (g is Label label)
                    {
                        string name = label.Name.Substring(0, 4);
                        if (name.Equals("room"))
                        {
                            if (label.Text.Equals(roomName))
                            {
                                label.Text = newRoomName;
                            }
                        }
                    }
                }
            }
        }


        public void RemoveRoom(string roomName)
        {
            XDocument xdoc = XDocument.Load("rooms.xml");
            var roomElements = xdoc.Root.Elements("room").Where(s => s.Attribute("name").Value.Equals(roomName));
            roomElements.Remove();
            xdoc.Save("rooms.xml");
            if (File.Exists("devices.xml") == true)
            {
                XDocument xdevice = XDocument.Load("devices.xml");
                var deviceElements = xdevice.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName));
                foreach (var p in deviceElements)
                {
                    p.Element("RoomName").Value = "";
                }
                xdevice.Save("devices.xml");
            }
            if (File.Exists("devicesTX.xml") == true)
            {
                XDocument xdeviceTX = XDocument.Load("devicesTX.xml");
                var deviceElementsTX = xdeviceTX.Root.Elements("device").Where(s => s.Element("RoomName").Value.Equals(roomName));
                foreach (XElement p in deviceElementsTX)
                {
                    p.Element("RoomName").Value = "";
                }
                xdeviceTX.Save("devicesTX.xml");
            }
        }
    }
}
