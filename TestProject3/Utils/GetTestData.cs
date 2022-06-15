using NUnit.Framework;
using System.Xml;

namespace DBAndAPIProject
{
    public static class GetTestData
    {
        private const string fileName = @"/Config.xml";

        public static string Get(string itemName, string nodeName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(TestContext.CurrentContext.TestDirectory + fileName);
            XmlElement xmlElement = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlElement)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    XmlNode attr = xmlNode.Attributes.GetNamedItem(itemName);
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == nodeName)
                            return childNode.InnerText;
                    }
                }
            }
            return "";
        }
    }
}