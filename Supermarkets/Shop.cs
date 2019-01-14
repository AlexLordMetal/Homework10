using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkets
{
    public class Shop : BaseClass
    {
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
