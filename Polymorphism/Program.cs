using System;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polymorphism");

            ECommerce ec = new ECommerce();
            ec.MakePayment(100, "CB");
            ec.MakePayment(200, "PAYPAL");
            ec.MakePayment(50, "BANK");
        }
    }

    internal class ECommerce
    {
        internal void MakePayment(int amount, string paymentMode)
        {
            CBService CBSrv = new CBService();
            PaypalService PaypalSrv = new PaypalService();
            BankService BankSrv = new BankService();

            switch (paymentMode)
            {
                case "CB" :
                    CBSrv.MakeCBPayment(amount);
                    break;
                case "PAYPAL" :
                    PaypalSrv.MakePaypalPayment(amount);
                    break;
                case "BANK" :
                    BankSrv.MakeBankPayment(amount);
                    break;
                default:
                    break;
            }
        }
    }

    internal class BankService
    {
        internal void MakeBankPayment(int amount)
        {
            Console.WriteLine("MakeBankPayment : "+ amount);
        }
    }

    internal class PaypalService
    {
        internal void MakePaypalPayment(int amount)
        {
            Console.WriteLine("MakePaypalPayment : "+ amount);
        }
    }

    internal class CBService
    {
        internal void MakeCBPayment(int amount)
        {
            Console.WriteLine("MakeCBPayment : "+ amount);
        }
    }
}
