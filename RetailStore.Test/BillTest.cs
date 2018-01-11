using System;
using RetailStore.Shared.Contracts.DataContracts;
using RetailStore.Shared.Contracts.Constants;
using RetailStore.Shared.Billing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RetailStore.Test
{
    [TestClass]
    public class BillTest
    {
        [TestMethod]
        public void TestEmployeeDiscount()
        {
            BillingDetails billingDetails = new BillingDetails();
            CartItem cartItem;
            billingDetails.UserDetails.UserName = "Ashok Kumar";
            billingDetails.UserDetails.RegistrationDate = DateTime.Parse("01/01/2016");
            billingDetails.UserDetails.Type = UserType.Employee;
            cartItem = new CartItem();
            cartItem.Item.Name = "Item 1";
            cartItem.Item.Rate = 99;
            cartItem.Quantity = 10;
            billingDetails.ItemList.Add(cartItem);
            Bill bill = new Bill(billingDetails);
            Assert.AreEqual(bill.BillingDetails.DiscountRate, 30);
            Assert.AreEqual(bill.BillingDetails.NetDiscount, 342);
            Assert.AreEqual(bill.BillingDetails.NetPayableAmount, 648);
        }

        public void TestAffiliateDiscount()
        {
            BillingDetails billingDetails = new BillingDetails();
            CartItem cartItem;
            billingDetails.UserDetails.UserName = "Ashok Kumar";
            billingDetails.UserDetails.RegistrationDate = DateTime.Parse("01/01/2016");
            billingDetails.UserDetails.Type = UserType.Affilate;
            cartItem = new CartItem();
            cartItem.Item.Name = "Item 1";
            cartItem.Item.Rate = 99;
            cartItem.Quantity = 10;
            billingDetails.ItemList.Add(cartItem);
            Bill bill = new Bill(billingDetails);
            Assert.AreEqual(bill.BillingDetails.DiscountRate, 10);
            Assert.AreEqual(bill.BillingDetails.NetDiscount, 144);
            Assert.AreEqual(bill.BillingDetails.NetPayableAmount, 846);
        }

        public void TestTwoYearOldCustomerDiscount()
        {
            BillingDetails billingDetails = new BillingDetails();
            CartItem cartItem;
            billingDetails.UserDetails.UserName = "Ashok Kumar";
            billingDetails.UserDetails.RegistrationDate = DateTime.Parse("01/01/2016");
            billingDetails.UserDetails.Type = UserType.RegularCutomer;
            cartItem = new CartItem();
            cartItem.Item.Name = "Item 1";
            cartItem.Item.Rate = 99;
            cartItem.Quantity = 10;
            billingDetails.ItemList.Add(cartItem);
            Bill bill = new Bill(billingDetails);
            Assert.AreEqual(bill.BillingDetails.DiscountRate, 5);
            Assert.AreEqual(bill.BillingDetails.NetDiscount, 94.5);
            Assert.AreEqual(bill.BillingDetails.NetPayableAmount, 895.5);
        }

        public void TestRegularCustomerDiscount()
        {
            BillingDetails billingDetails = new BillingDetails();
            CartItem cartItem;
            billingDetails.UserDetails.UserName = "Ashok Kumar";
            billingDetails.UserDetails.RegistrationDate = DateTime.Parse("01/01/2017");
            billingDetails.UserDetails.Type = UserType.RegularCutomer;
            cartItem = new CartItem();
            cartItem.Item.Name = "Item 1";
            cartItem.Item.Rate = 99;
            cartItem.Quantity = 10;
            billingDetails.ItemList.Add(cartItem);
            Bill bill = new Bill(billingDetails);
            Assert.AreEqual(bill.BillingDetails.DiscountRate, 0);
            Assert.AreEqual(bill.BillingDetails.NetDiscount, 45);
            Assert.AreEqual(bill.BillingDetails.NetPayableAmount, 945);
        }
    }
}
