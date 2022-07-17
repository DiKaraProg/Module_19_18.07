using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Module_19
{
    public class SaveToXml:IBookSave
    {
        private string fileName;

        public SaveToXml(string FileName)
        {
            this.fileName = FileName;
        }

        public string CreateXlm(List<IAnimal> animals)
        {
            string temp = string.Empty;
            foreach (var item in animals)
            {
                temp += $"{item.Id} {item.Type} {item.Name} {item.Age} {item.Weight}\n";

            }
            return temp;
        }
        public void SaveBookPages(List<IAnimal> animals)
        {

            SerealizeXML(animals);
        }
        public void SerealizeXML(List<IAnimal> animals)
        {
            XElement myTOWN = new XElement("Animals");
            foreach (var item in animals)
            {
                var temp = $"\n{item.Id} {item.Type} {item.Name} {item.Age} {item.Weight}";
                
                myTOWN.Add(temp);
                myTOWN.Save($"{fileName}.xml");
            }
            
        }
    }
}
