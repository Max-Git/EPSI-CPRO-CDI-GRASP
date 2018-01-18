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

    public interface IPayment
    {
        void MakePayment(int amount);
    }

    public class CBPayment : IPayment
    {
        CBService CBSrv = new CBService();
        public void MakePayment(int amount)
        {
            CBSrv.MakeCBPayment(amount);
        }
    }

    public class BankPayment : IPayment
    {
        BankService BankSrv = new BankService();
        public void MakePayment(int amount)
        {
            BankSrv.MakeBankPayment(amount);
        }
    }

    public class PaypalPayment : IPayment
    {
        PaypalService PaypalSrv = new PaypalService();

        public void MakePayment(int amount)
        {
            PaypalSrv.MakePaypalPayment(amount);
        }
    }

    public class PaymentFactory{
        public IPayment createPaymentMethod(string paymentMode)
        {
            CBPayment cbp = new CBPayment();
            BankPayment bp = new BankPayment();
            PaypalPayment pp = new PaypalPayment();

            switch (paymentMode)
            {
                case "CB" :
                    return new CBPayment();
                case "PAYPAL" :
                    return new PaypalPayment();
                case "BANK" :
                    return new BankPayment();
                default: 
                    return null;
            }
        }
    }
    internal class ECommerce
    {
        internal void MakePayment(int amount, string paymentMode)
        {
            PaymentFactory factory = new PaymentFactory();
            IPayment paymentMethod = factory.createPaymentMethod(paymentMode);

            paymentMethod.MakePayment(amount);
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
