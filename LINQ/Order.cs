using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Order
    {
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public int Price { get; set; }

        public Order(string name,int orderNumber,int price)
        {
            Name = name;
            OrderNumber = orderNumber;
            Price = price;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
