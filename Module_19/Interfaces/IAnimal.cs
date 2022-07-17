using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    public interface IAnimal
    {
        int Id { get; set; }
        string Type { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        double Weight { get; set; }
    }
}
