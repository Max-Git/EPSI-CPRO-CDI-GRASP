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
            Product p2 = new Product(){Id=2, Name="p2", Price=150};
            Product p3 = new Product(){Id=3, Name="p3", Price=50};

            CommandLine cl1 = new CommandLine();
            CommandLine cl2 = new CommandLine();
            CommandLine cl3 = new CommandLine();

            cl1.AddProduct(p1, 10);
            cl2.AddProduct(p2, 50);
            cl3.AddProduct(p3, 5);

            Command c = new Command();
            c.CommandDate = DateTime.Now;

            c.AddCommandLine(cl1);
            c.AddCommandLine(cl2);
            c.AddCommandLine(cl3);

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

        public void AddCommandLine(CommandLine cl)
        {
            // ....
            this.CommandLines.Add(cl);
        }

        internal int GetTotal()
        {
            int res = 0;
            
            foreach (CommandLine item in CommandLines)
            {
                res = res + item.GetSubTotal(); 
            }

            return res;
        }
    }

    public class CommandLine
    {
        public int Quantity { get; set; }
        public Product CLProduct { get; set; }

        public int GetSubTotal()
        {
            return this.Quantity * this.CLProduct.GetPrice();
        }

        public void AddProduct (Product p, int qte)
        {
            this.CLProduct = p;
            this.Quantity = qte;
        }
    }

    public class Product
    {
        public int Price { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public int GetPrice ()
        {
            return this.Price;
        }
    }
}
