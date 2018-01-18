using System;
using System.Collections;
using System.Collections.Generic;

namespace InformationExpert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("InformationExpert");

            Product p1 = new Product(){Id=1, Name="p1", Price=10};
            Product p2 = new Product(){Id=1, Name="p2", Price=150};
            Product p3 = new Product(){Id=1, Name="p3", Price=50};

            CommandLine cl1 = new CommandLine(){CLProduct = p1, Quantity = 2};
            CommandLine cl2 = new CommandLine(){CLProduct = p2, Quantity = 10};
            CommandLine cl3 = new CommandLine(){CLProduct = p3, Quantity = 1};

            Command c = new Command();
            c.CommandDate = DateTime.Now;
            c.CommandLines.Add(cl1);
            c.CommandLines.Add(cl2);
            c.CommandLines.Add(cl3);

            Console.WriteLine("Total Cmd : "+ c.GetTotal());
        }
    }

    public class Command {
        public DateTime CommandDate { get; set; }        
        public List<CommandLine> CommandLines { get; set; }   

        public Command()
        {
            CommandLines = new List<CommandLine>();
        }

        internal int GetTotal()
        {
            int res = 0;
            
            foreach (CommandLine item in CommandLines)
            {
                res = res + (item.Quantity * item.CLProduct.Price); 
            }

            return res;
        }
    }

    public class CommandLine
    {
        public int Quantity { get; set; }
        public Product CLProduct { get; set; }
    }

    public class Product
    {
        public int Price { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
