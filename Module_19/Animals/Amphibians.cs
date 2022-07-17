using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    internal class Amphibians:IAnimal
    {
        private int id;
        private string type;
        private string name;
        private int age;
        private double weight;

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public double Weight { get => weight; set => weight = value; }

        public Amphibians(string Type, string Name, int Age, double Weight)
        {
            this.id = id++;
            this.type =
            this.name = Name;
            this.weight = Weight;
            this.age = Age;
        }
    }
}
