using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    public static class AnimalFactory
    {
        public static IAnimal GetAnimal(string Type, string Name, int Age, double Weight)
        {
            switch (Type)
            {
                case "Birds":return new Bird(Type, Name, Age, Weight);
                case "Amphibians":return new Amphibians(Type, Name, Age, Weight);
                case "Mammals":return new Mammals(Type, Name, Age, Weight);
                default:
                    return new NullAnimal(Type, Name, Age, Weight);

            }
        }
    }
}
