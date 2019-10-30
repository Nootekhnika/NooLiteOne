using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Xml.Linq;

namespace NooLiteServiceSoft.XML
{
    public class XmlPort
    {
        public void CreateXmlFile(SerialPort port, byte[] idPort)
        {
            string _idPort = idPort[0].ToString() + "/" + idPort[1].ToString() + "/" + idPort[2].ToString() + "/" + idPort[3].ToString();
            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement ports = new XElement("port");
            XAttribute GroupNameAttr = new XAttribute("name", port.PortName);
            XElement mports = new XElement("ports");
            XElement idPortsEl = new XElement("IdPort", _idPort);
            XElement baudRate = new XElement("baudRate", 9600);
            ports.Add(GroupNameAttr);
            ports.Add(baudRate);
            ports.Add(idPortsEl);
            mports.Add(ports);
            xdocs.Add(mports);
            xdocs.Save("port.xml");
        }

        public void UpdatePortName(SerialPort port, byte[] idPort)
        {
            XmlPort xmlPort = new XmlPort();
            string[] idArray = xmlPort.PortIdXml();
            bool PortIdflag = true;
            for (int i = 0; i < 4; i++)//TO DO
            {
                if (idArray[i].Equals(idPort[i].ToString()))
                {
                    PortIdflag = true;
                }
                else
                {
                    PortIdflag = false;
                }
                if (PortIdflag == false) break;
            }
            if (PortIdflag == false)
            {
                string _idPort = idPort[0].ToString() + "/" + idPort[1].ToString() + "/" + idPort[2].ToString() + "/" + idPort[3].ToString();
                XDocument xdoc = XDocument.Load("port.xml");
                var ports = xdoc.Root.Elements("port");
                foreach (var p in ports)
                {
                    p.Attribute("name").Value = port.PortName;
                    p.Element("IdPort").Value = _idPort;
                }
                xdoc.Save("port.xml");
            }
        }

        public int BaudRate()
        {
            XDocument xdoc = XDocument.Load("port.xml");
            int value = 9600;
            var portElement = from el in xdoc.Root.Elements("port")
                              select new
                              {
                                  dBaudRate = el.Element("baudRate").Value,
                              };
            foreach (var param in portElement)
            {
                value = int.Parse(param.dBaudRate);
            }
            return value;
        }

        public string PortNameXml()
        {
            try
            {
                XDocument xdoc = XDocument.Load("port.xml");
                var roomElements = from el in xdoc.Root.Elements("port")
                                   select new
                                   {
                                       dName = el.Attribute("name")
                                   };
                foreach (var param in roomElements)
                {
                    return (string)param.dName;
                }
            }
            catch (IOException)
            {
            }
            return null;
        }

        public void UpdatePortValue(string text)
        {
            XDocument xdoc = XDocument.Load("port.xml");
            XNode xNodeTwo = xdoc.Root.Nodes().ElementAt(0);
            ((XElement)xNodeTwo).Element("baudRate").Remove();
            XElement baudRate = new XElement("baudRate", text);
            ((XElement)xNodeTwo).Add(baudRate);
            xdoc.Save("port.xml");
        }

        public string[] PortIdXml()
        {

            string PortId = "";
            XDocument xdoc = XDocument.Load("port.xml");
            var portElements = from el in xdoc.Root.Elements("port")
                               select new
                               {
                                   IdPort = el.Element("IdPort")
                               };
            foreach (var param in portElements)
            {
                PortId = (string)param.IdPort;
            }

            string[] idArray = PortId.Split('/');
            return idArray;
        }
    }
}
