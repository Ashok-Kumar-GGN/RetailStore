using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Shared.Contracts.Constants
{
    public class Discounts
    {
        public List<KeyValuePair<UserType, double>> DiscountList { get; set; }
        public double AmountBasedDiscount { get; set; }
        public Discounts()
        {
            DiscountList = new List<KeyValuePair<UserType, double>>();
            DiscountList.Add(new KeyValuePair<UserType, double>(UserType.Employee, 30));
            DiscountList.Add(new KeyValuePair<UserType, double>(UserType.Affilate, 10));
            DiscountList.Add(new KeyValuePair<UserType, double>(UserType.RegularCutomer, 5));
            AmountBasedDiscount = 5;
        }
    }
}
