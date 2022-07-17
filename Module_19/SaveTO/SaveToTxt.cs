using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    public class SaveToTxt:IBookSave
    {
        private string fileName;

        public SaveToTxt(string FileName)
        {
            this.fileName = FileName;
        }

        public string CreateTxt(List<IAnimal> animals)
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
           
            using (StreamWriter sw = new StreamWriter($"{fileName}.txt"))
            {
                sw.WriteLine(CreateTxt(animals));
            }
        }


    }
}
