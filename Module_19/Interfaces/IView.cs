using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Module_19
{
    internal interface IView
    {
        int Id { get; }
        string Type { get;  }
        string Name { get; set; }
        int Age { get; set; }
        double Weight { get; set; }
        

    }
}
