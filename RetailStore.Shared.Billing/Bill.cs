using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStore.Shared.Contracts.DataContracts;
using RetailStore.Shared.Contracts.Constants;
namespace RetailStore.Shared.Billing
{
    public class Bill
    {
        Discounts discounts;
        public BillingDetails BillingDetails { get;}

        public Bill(BillingDetails billingDetails)
        {
            this.BillingDetails = billingDetails;
            discounts = new Discounts();
            IdentifyDiscountRate();
            CalculateBillingAmount();
            CalculatePercentageDiscount();
            CalculateAmountBasedDiscount();
            CalculateNetPayableAmount();
        }

        private void CalculateNetPayableAmount()
        {
            this.BillingDetails.NetPayableAmount = this.BillingDetails.BillingAmount - this.BillingDetails.NetDiscount;
        }

        private void CalculateBillingAmount()
        {

            foreach (CartItem objItem in this.BillingDetails.ItemList)
            {
                this.BillingDetails.BillingAmount = objItem.Item.Rate * objItem.Quantity;
            }            
        }

        private void IdentifyDiscountRate()
        {
            switch (this.BillingDetails.UserDetails.Type)
            {
                case UserType.Employee:
                case UserType.Affilate:
                    this.BillingDetails.DiscountRate = discounts.DiscountList.Where(q => q.Key == this.BillingDetails.UserDetails.Type).FirstOrDefault().Value;
                    break;
                case UserType.RegularCutomer:
                    if (this.BillingDetails.UserDetails.RegistrationDate <= DateTime.Today.Date.AddYears(-2))
                    {
                        this.BillingDetails.DiscountRate = discounts.DiscountList.Where(q => q.Key == this.BillingDetails.UserDetails.Type).FirstOrDefault().Value;
                    }
                    break;
                default:
                    this.BillingDetails.DiscountRate = 0;
                    break;
            }
        }

        private void CalculatePercentageDiscount()
        {

            foreach (CartItem objItem in this.BillingDetails.ItemList.Where(q => q.Item.ItemType != ItemType.Grocery).ToList())
            {
                this.BillingDetails.NetDiscount = (objItem.Item.Rate * objItem.Quantity * this.BillingDetails.DiscountRate) / 100;
            }
        }

        private void CalculateAmountBasedDiscount()
        {
            this.BillingDetails.NetDiscount = this.BillingDetails.NetDiscount + (int)(this.BillingDetails.BillingAmount / 100) * discounts.AmountBasedDiscount;
        }
    }
}
