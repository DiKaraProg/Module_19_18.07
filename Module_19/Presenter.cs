using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    internal class Presenter
    {
        Model model;
        IView view;

        public Presenter(IView view)
        {
            this.view = view;
            model = new Model("Data");
        }
        public List<IAnimal> LoadAnimals()
        {
           return model.LoadAnimals();
        }
        public void AddAnimal()
        {
            if (view.Age == -1 || view.Weight == -1) return;
            
            model.CurrentDataBase.AddAnimal(AnimalFactory.GetAnimal(view.Type,view.Name, view.Age, view.Weight));
        }
        public void RemoveAnimal()
        {
            if (view.Age == -1 || view.Weight == -1) return;
            var animal = AnimalFactory.GetAnimal(view.Type, view.Name, view.Age, view.Weight);

            model.CurrentDataBase.RemoveAnimal(animal);
        }
        public void SaveAnimalBase()
        {
            model.SaveToJson();
        }
        public List<IAnimal> GetAllAnimal()
        {
            return model.CurrentDataBase.Storage;
        }
        public void Edit(IAnimal animal)
        {
            
            model.Edit(animal);

        }
        public void SaveTO(int index)
        {
            
            model.SaveTo(index);
        }
    }
}
