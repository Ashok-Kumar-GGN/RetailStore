using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStore.Shared.Contracts.DataContracts;
using RetailStore.Shared.Contracts.Constants;
using RetailStore.Shared.Billing;
using System.Globalization;

namespace RetailStore.Client.Billing
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = string.Empty;
            CultureInfo cultureInfo = new CultureInfo("en-US");
            do
            {
                BillingDetails billingDetails = new BillingDetails();
                Console.WriteLine("Enter user name :");
                billingDetails.UserDetails.UserName = Console.ReadLine();
                Console.WriteLine("Enter user registration date  in dd/mm/yyyy format:");
                billingDetails.UserDetails.RegistrationDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Press 1 if user is employee");
                Console.WriteLine("Press 2 if user is affiliate");
                Console.WriteLine("Press 3 for others");
                billingDetails.UserDetails.Type = (UserType)Enum.Parse(typeof(UserType), Console.ReadLine());

                do
                {
                    CartItem cartItem = new CartItem();
                    
                    Console.WriteLine("Enter item name :");
                    cartItem.Item.Name = Console.ReadLine();
                    Console.WriteLine("Enter item rate :");
                    cartItem.Item.Rate = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter item quantity :");
                    cartItem.Quantity = double.Parse(Console.ReadLine());
                    billingDetails.ItemList.Add(cartItem);

                    Console.WriteLine("Press N for new item");
                    repeat = Console.ReadLine();
                } while (repeat.ToUpper() == "N");

                Bill bill = new Bill(billingDetails);
                Console.WriteLine("Billing Amount :" + bill.BillingDetails.BillingAmount.ToString("C", cultureInfo));
                Console.WriteLine(String.Format("Discount Rate : {0:P2}.", bill.BillingDetails.DiscountRate / 100));
                Console.WriteLine("Net Discount :" + bill.BillingDetails.NetDiscount.ToString("C", cultureInfo));
                Console.WriteLine("Net Payable Amount :" + bill.BillingDetails.NetPayableAmount.ToString("C", cultureInfo));
                repeat = string.Empty;
                Console.WriteLine("Press N for next bill");
                repeat = Console.ReadLine();
            } while (repeat.ToUpper() == "N");


        }
    }
}
