using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUPOS_Project.Class_s
{
    internal class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }

        public Product(string name, int quantity, string price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        //Default Cons
        public Product()
        {
            Name = "Item Name";
            Quantity = 0;
            Price = "0.0";
        }
    }
}
