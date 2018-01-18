using System;

namespace HighCohesion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HighCohesion & LowCoupling Hello");
            Sale sale = new Sale();
            sale.Price = 100;

            CustomerManager cm = new CustomerManager();
            SaleManager sm = new SaleManager();
            ECommerce ec = new ECommerce();

            if (cm.accountExist())
            {
                if (sm.addSale(sale))
                {
                    if (ec.makePayment(sale))
                    {
                        Console.WriteLine("Paiement OK !");
                    }
                }
            }
        }
    }

    public class CustomerManager
    {
        UserService userSrv = new UserService();

        public bool accountExist()
        {
            return userSrv.accountExist();
        }

        public bool createAccount()
        {
            return userSrv.createAccount();
        }
    }

    public class SaleManager
    {
        SalesService salesSrv = new SalesService();

        public bool addSale(Sale currentSale)
        {
            return salesSrv.addSale(currentSale);
        }
    }

    public class ECommerce
    {
        public bool makePayment(Sale currentSale) {
            
            PaymentService paySrv = new PaymentService();
           
            // on fait le paiement
            if (paySrv.performPayment(currentSale.Price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    internal class PaymentService
    {
        internal bool performPayment(int price)
        {
            return true;
        }
    }

    public class Sale
    {
        public int Price { get; set; }
        
    }

    public class SalesService
    {
        public bool addSale(Sale currentSale)
        {
            // Ajoute la vente
            return true;
        }
    }

    public class UserService
    {
        public bool accountExist()
        {
            return true;
        }

        public bool createAccount()
        {
            return true;
            // crée le compte
        }
    }
}
