using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_19
{
    public class BooKWriter
    {
        public IBookSave Mode { get; set; }


        public string Pages { get; set; }

        public BooKWriter(IBookSave Method)
        {
            this.Mode = Method;
        }
        
        public void Save(List<IAnimal> animals)
        {
            Mode.SaveBookPages(animals);
        }
    }
}
