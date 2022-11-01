using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Customer
    {
        public string Name { get; set; }
        public int CustomerNumber { get; set; }
        public int OrderNumber { get; set; }

        public Customer(string name, int customerNumber,int orderNumber)
        {
            Name = name;
            CustomerNumber = customerNumber;
            OrderNumber = orderNumber;
        }
    }
}
