using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    public class AnimalDataBase
    {
        private List<IAnimal> storage;
        
        public List<IAnimal> Storage { get => storage;set => storage = value; }

        public AnimalDataBase() 
        {
            storage = new List<IAnimal>();
        }
        public void AddAnimal(IAnimal animal)
        {
            
            if (!storage.Contains(animal))
            {
                
                animal.Id = storage.Count+1;
                storage.Add(animal);
            }
        }
        public void RemoveAnimal(IAnimal animal)
        {
            List<Animal> list = new List<Animal>();
            int id = 0;
            foreach (var item in storage)
            {
                if (item.Name == animal.Name)
                {
                    storage.Remove(item);
                    break;
                }
            }
            foreach (var item in storage)
            {
                id++;
                item.Id = id;
            }
        }
    }
}
