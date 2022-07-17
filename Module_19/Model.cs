using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Module_19
{
    public class Model
    {
        private Animal currentAnimal;
        private AnimalDataBase currentDataBase;
        private string path;
        private BooKWriter writer;
        
        private SaveToTxt toTxt;
        private SaveToXml toXml;

        
        public Animal CurrentAnimal { get => currentAnimal;set { currentAnimal = value; } }
        public AnimalDataBase CurrentDataBase { get => currentDataBase; set => currentDataBase = value; }

        public static void Popup(string Text)
        {
            
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Exception";
            popup.ContentText = Text;
            popup.Popup();
        }
        public Model(string Path)
        {
            
            this.path = Path;
            currentDataBase = new AnimalDataBase();
            toTxt = new SaveToTxt(path);
            writer = new BooKWriter(toTxt);
            toXml = new SaveToXml(path);
        }
        public void SaveTo(int index)
        {
            if (index == -1)
            {
                Popup("You must choose a save method");
                return;
            }
            switch (index)
            {
                case 0: writer.Mode = toTxt; writer.Save(currentDataBase.Storage); break;
                case 1: writer.Mode = toXml; writer.Save(currentDataBase.Storage); break;
                default:
                    break;
            }

        }
        public List<IAnimal> LoadAnimals()
        {
            if (!File.Exists($"{path}.json")) { return currentDataBase.Storage; }
            var str = File.ReadAllText($"{path}.json");
            if (str == string.Empty) { return currentDataBase.Storage; }
            var list = JsonConvert.DeserializeObject<List<Animal>>(str);
            currentDataBase.Storage.Clear();
            foreach (var item in list)
            {
                currentDataBase.AddAnimal(AnimalFactory.GetAnimal(item.Type,item.Name,item.Age,item.Weight));
            }
            return currentDataBase.Storage;
        }
        public void SaveToJson()
        {
            try
            {
                JArray array = new JArray();
                foreach (var item in currentDataBase.Storage)
                {
                    JObject o = new JObject
                    {
                        ["Id"] = item.Id,
                        ["Type"] = item.Type,
                        ["Name"] = item.Name,
                        ["Age"] = item.Age,
                        ["Weight"] = item.Weight
                    };
                    array.Add(o);
                }
                var json = array.ToString();
                File.WriteAllText($"{path}.json", json);
            }
            catch (Exception e)
            {
                Popup(e.Message);
                
            }
           
        }
        public void Edit(IAnimal animal)
        {
            try
            {
                if (animal.Age == -1 || animal.Weight == -1)
                {
                    Popup("Incorrect value entered");
                }
                
                foreach (var item in currentDataBase.Storage)
                {
                    if (animal.Name == item.Name)
                    {
                        item.Age = animal.Age;
                        item.Weight = animal.Weight;
                    }
                }
            }
            catch(Exception e)
            {
                Popup(e.Message);
            }
           
        }
    }
}
