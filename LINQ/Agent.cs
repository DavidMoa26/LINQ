using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Agent
    {
        public string Name { get; set; }
        public int CustomerNumber { get; set; }

        public Agent(string name, int customerNumber)
        {
            Name = name;
            CustomerNumber = customerNumber;
        }
    }
}
