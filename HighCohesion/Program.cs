using System;

namespace HighCohesion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HighCohesion");
            Sale sale = new Sale();
            sale.Price = 100;

            ECommerce ec = new ECommerce();
            if (ec.makePayment(sale))
            {
                Console.WriteLine("Paiement OK !");
            }
        }
    }

    public class ECommerce
    {
        public bool makePayment(Sale currentSale) {
            // On vérifie si le compte de l'utilisateur existe et si non, on le crée
            UserService userSrv = new UserService();
            SalesService salesSrv = new SalesService();
            PaymentService paySrv = new PaymentService();

            if (userSrv.accountExist())
            {
                // on stocke la vente
                if (salesSrv.addSale(currentSale))
                {
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
                else
                {
                    return false;
                }
            }
            else
            {
                userSrv.createAccount();

                 // on stocke la vente
                if (salesSrv.addSale(currentSale))
                {
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
                else
                {
                    return false;
                }
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

    internal class SalesService
    {
        internal bool addSale(Sale currentSale)
        {
            // Ajoute la vente
            return true;
        }
    }

    public class UserService
    {
        internal bool accountExist()
        {
            return true;
        }

        internal void createAccount()
        {
            // crée le compte
        }
    }
}
