using System;
using System.Collections;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //****Select Function*****//
            List<int> ints = new List<int> { 8, 3, 9, 4, 5 };
            List<string> ints2 = ints.Select(i => i + "    ").ToList();
            ints2.ForEach(i => Console.Write(i));
            Console.WriteLine("\n");

            ////*****Where Function*****//
            List<string> names = new List<string>() { "Dog", "Cat", "Bird", "Moneky", "Elephent", "Tiger" };
            List<string> namesLengthBiggerThan4 = names.Where(i => i.Length > 4).ToList();
            namesLengthBiggerThan4.ForEach(i => Console.Write(i + "    "));
            Console.WriteLine("\n");

            ////*****OrderBy Function*****//
            ints2 = ints2.OrderBy(i => i).ToList();
            ints2.ForEach(i => Console.Write(i));
            Console.WriteLine("\n");
            names = names.OrderBy(i => i).ToList();
            names.ForEach(i => Console.Write(i + "    "));
            Console.WriteLine("\n");

            ////*****OrderByDescending Function**///
            ints2 = ints2.OrderByDescending(i => i).ToList();
            ints2.ForEach(i => Console.Write(i));
            Console.WriteLine("\n");
            names = names.OrderByDescending(i => i).ToList();
            names.ForEach(i => Console.Write(i + "    "));
            Console.WriteLine("\n");

            //********Create 2 numbers list******//
            List<int> numbers1 = new List<int>() { 8, 5, 4, 7, 3, 1 };
            List<int> numbers2 = new List<int>() { 6, 5, 4, 11, 13 };
            List<int> Commonnumbers = numbers1.Intersect(numbers2).ToList();
            Commonnumbers.ForEach(i => Console.Write(i + "    ")); //Print Common numbers//
            Console.WriteLine("\n");
            List<int> numbersOnlyAtLeftList = numbers1.Except(numbers2).ToList();
            numbersOnlyAtLeftList.ForEach(i => Console.Write(i + "    ")); //Print numbers1 without numbers at numbers2
            Console.WriteLine("\n");
            List<int> connectListsWithoutDup = numbers1.Union(numbers2).ToList();
            connectListsWithoutDup.ForEach(i => Console.Write(i + "    "));//Print 2 lists without dup
            Console.WriteLine("\n");

            Console.WriteLine(connectListsWithoutDup.First(i => i > 12)+"\n");//print first element bigger than 12

            //*****Print max numbers between the lists *****//
            int[] Max = { numbers1.Max(i => i), numbers2.Max(i => i) };
            if (Max[0] >= Max[1])
                Console.WriteLine(Max[0] + "\n");
            else 
                Console.WriteLine(Max[1] + "\n");

            //******Create customer, agent and order lists lists******//
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Eli", 4, 1));
            customers.Add(new Customer("Avi", 3, 2));


            List<Agent> agents = new List<Agent>();
            agents.Add(new Agent("Moti", 1));
            agents.Add(new Agent("Ohad", 2));
            agents.Add(new Agent("Omer", 3));
            agents.Add(new Agent("Roei", 4));


            List<Order> orders = new List<Order>();
            orders.Add(new Order("Car", 1, 1000));
            orders.Add(new Order("Airplane", 1, 600));
            orders.Add(new Order("Ship", 2, 700));
            orders.Add(new Order("Bed", 2, 200));

            //******Join function*****//
            var GroupAgentWithCustumers = agents.Join(customers,
                customer => customer.CustomerNumber,
                agent => agent.CustomerNumber,
                  (customer, agent) => new
                  {
                      custumer = agent.Name,
                      agent = customer.Name
                  }).ToList();
            Console.Write(GroupAgentWithCustumers[0]+"      ");
            Console.WriteLine(GroupAgentWithCustumers[1]);

            //*********GroupJoin function*****//
            var GroupCustumersWithOrders = customers.GroupJoin(orders,
                customers => customers.OrderNumber,
                orders => orders.OrderNumber,
                (customer, orderByNumber) => new
                {
                    customerName = customer.Name,
                    orders = orderByNumber.ToList()

                }).ToList();

            //*******Print customers names that have 2 orders bigger than 500*****///
            int counter;
            foreach (var Customers in GroupCustumersWithOrders)
            {
                counter = 0;
                foreach (var order in Customers.orders)
                {
                    if (order.Price > 500)
                        counter++;
                }
                if (counter >= 2)
                    Console.WriteLine(Customers.customerName);
            }

            //*******Query Syntax*******//

            //*****Print numbers with ,****///
            var numbers = from Int in ints select Int + ",";
            foreach (var item in numbers)
                Console.Write(item);
            Console.WriteLine();

            //*********Print Names chars bigger than 4*****///
            var namesBiggerThan4Chars = from name in names where name.Length > 4 select name;
            foreach (var item in namesBiggerThan4Chars)
                Console.WriteLine(item);

            //*****orderby int******//
            var orderByInts = from item in ints orderby item select item;
            foreach (var item in orderByInts)            
                Console.WriteLine(item);

            //*****orderbyDescending int******//
            var orderByDescendingInts = from x in ints orderby x descending select x;
            foreach (var item in orderByDescendingInts)          
                Console.WriteLine(item);

            //*****orderby names******//
            var orderByNames = from item in names orderby item select item;
            foreach (var item in orderByNames)          
                Console.WriteLine(item);

            //*****orderbyDescending names******//
            var orderByDescendingNames = from x in names orderby x descending select x;
            foreach (var item in orderByDescendingNames)          
                Console.WriteLine(item);
            
        }
    }
}