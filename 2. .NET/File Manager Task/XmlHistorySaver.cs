using System.Xml.Linq;

namespace File_Manager_Task
{
    public class XmlHistorySaver : IHistorySaver
    {
        public void Save(string data)
        {
            // This approach is kinda crappy. I load a file, append new value and save it.
            // Now imagine what happens if 10k lines file is loaded.
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "History.xml";
            XDocument history;
            try
            {
                history = XDocument.Load(filePath);
            }
            catch (FileNotFoundException)
            {
                history = new XDocument(new XElement("history"));
            }

            XElement line = new XElement("path") { Value = data };
            history.Element("history").Add(line);
            history.Save(filePath);
        }
    }
}