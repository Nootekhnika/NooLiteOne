using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NooLiteServiceSoft
{
    public class XmlTypeDevice
    {
        public void CreateXmlFile()
        {

            XDocument xdocs = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement types = new XElement("types");
            string[] typeNames = new string[] { "MTRF-64", "SLF-1-300", "SRF-10-1000", "SRF-1-3000", "SRF-1-3000M", "SUF-1-300", "SRF-1-3000-T", "SRF-1-1000-R" };
            string[] codeElements = new string[] { "0", "1", "2", "3", "4", "5", "6", "7" };
            string[] prmtrs = new string[] { "", "Яркость", "Яркость", "Яркость", "Яркость", "Яркость", "Температура", "Состояние" };
            string[] prmtrsMeasurements = new string[] { "", "%", "%", "%", "%", "%", "C", "%" };

            for (int i = 0; i < typeNames.Length; i++)
            {
                XElement typeName = new XElement("typeName");
                XAttribute typeNameAttr = new XAttribute("name", typeNames[i]);
                XElement codeElem = new XElement("codeElem", codeElements[i]);
                XElement prmtr = new XElement("param", prmtrs[i]);
                XElement prmtrsMeasurement = new XElement("measurement", prmtrsMeasurements[i]);

                typeName.Add(typeNameAttr);
                typeName.Add(codeElem);
                typeName.Add(prmtr);
                typeName.Add(prmtrsMeasurement);
                types.Add(typeName);
            }
            xdocs.Add(types);
            xdocs.Save("deviceTypes.xml");
        }


        public string TypeDeviceNameXml(byte typeName)
        {
            if (File.Exists("deviceTypes.xml") == false)
            {
                CreateXmlFile();
            }
            XDocument xdoc = XDocument.Load("deviceTypes.xml");
            var TypeDeviceName = xdoc.Descendants().Elements("typeName").Where(p => p.Element("codeElem").Value == typeName.ToString()).SingleOrDefault();

            return TypeDeviceName.Attribute("name").Value;
        }

        public string DeviceParamXml(byte typeName)
        {
            if (File.Exists("deviceTypes.xml") == false)
            {
                CreateXmlFile();
            }
            XDocument xdoc = XDocument.Load("deviceTypes.xml");
            var TypeDeviceName = xdoc.Descendants().Elements("typeName").Where(p => p.Element("codeElem").Value == typeName.ToString()).SingleOrDefault();

            return TypeDeviceName.Element("param").Value;
        }

        public string DeviceMeansureXml(byte typeName)
        {
            if (File.Exists("deviceTypes.xml") == false)
            {
                CreateXmlFile();
            }
            XDocument xdoc = XDocument.Load("deviceTypes.xml");
            var TypeDeviceName = xdoc.Descendants().Elements("typeName").Where(p => p.Element("codeElem").Value == typeName.ToString()).SingleOrDefault();

            return TypeDeviceName.Element("measurement").Value;
        }

        public string DeviceParamNowXml(byte[] buffer)
        {
            if (File.Exists("deviceTypes.xml") == false)
            {
                CreateXmlFile();
            }
            XDocument xdoc = XDocument.Load("deviceTypes.xml");
            var TypeDeviceName = xdoc.Descendants().Elements("typeName").Where(p => p.Element("codeElem").Value == buffer[7].ToString()).SingleOrDefault();

            if (TypeDeviceName.Element("measurement").Value.Equals("%"))
            {
                return ((int.Parse(buffer[10].ToString()) * 100) / 255).ToString();
            }

            if (TypeDeviceName.Element("measurement").Value.Equals("C"))
            {
                return buffer[10].ToString();
            }
            return null;
        }
    }
}

