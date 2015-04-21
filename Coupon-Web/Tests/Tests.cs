using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_Web.BL;
using Coupon_Web.DAL;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private BlRequests bl;
        private Connection conn;

        [TestInitialize]
        public void SetUp()
        {
           
            conn = new Connection();
            bl = new BlRequests(conn.getSqlCon());
            try
            {
                conn.open();
                bl.InsertUser("Amitay", "amitay", "12345678"); // customer
                bl.InsertUser("shimi", "amitay", "12345678"); // manager
                bl.InsertCategory(1, "Entertainment", "stand-ups, tv-Shows, etc...");
                bl.InsertSecurePayment("Paypal", 5);
                bl.InsertManager("shimi");
                bl.InsertBusiness(1, "Hamashbir", "menashe kapara 33 Rehovot", "in the shop you can find a lot of things", "shimi");
                bl.InsertCoupon(1, "dead-sea-soap", 100, 70, new DateTime(2014, 04, 06).Date, 1, 1);
                bl.InsertCouponCategory(1, 1);
                bl.InsertCustomer("Amitay", "amitay@gmail.com", "0542819491");
                bl.InsertCustomerPreference("Amitay", 1);
                bl.InsertDeal(1, 0, "11111", 1, "Amitay", "Paypal");
                bl.InsertRates("Amitay", 1, 3, "good");

                bl.InsertUser("haliliAsaf", "asaf", "mordchai");
                bl.InsertUser("Fahima", "fahima", "vdvldms!ds");
                bl.InsertSecurePayment("Cash", 3);
                bl.InsertCategory(4, "Pnay", "some staff");
            }
            catch (Exception)
            { }
        }

        [TestMethod]
        public void InsertBusinessTest()
        {
            bool before = bl.IsBusinessExist(2);
            bl.InsertBusiness(2, "Academon", "meonot 3", "shop for students", "shimi");
            bool after = bl.IsBusinessExist(2);

            Assert.AreNotEqual(before, after, "should not be equal");
        }

        [TestMethod]
        public void InsertUserTest()
        {
            bool before = bl.IsUserExist("Tomer");
            bl.InsertUser("Tomer", "kof", "1234");
            bool after = bl.IsUserExist("Tomer");

            Assert.AreNotEqual(before, after, "should not be equal");
        }

        [TestMethod]
        public void InsertCouponTest()
        {
            bool before = bl.IsCouponExist(2);
            bl.InsertCoupon(2, "dead-sea-cream", 400, 300, new DateTime(2015, 04, 03).Date, 3, 1);
            bool after = bl.IsCouponExist(2);

            Assert.AreNotEqual(before, after, "should not be equal");
        }

        [TestMethod]
        public void InsertManagerTest()
        {
            bool before = bl.IsManagerExist("haliliAsaf");
            bl.InsertManager("haliliAsaf");
            bool after = bl.IsManagerExist("haliliAsaf");
            Assert.AreNotEqual(before, after, "should not be equal");
        }

        [TestMethod]
        public void InsertDealTest()
        {
            bool before = bl.IsDealExist(2);
            bl.InsertDeal(2, 0, "ADGR-DSD1-d345", 1, "Amitay", "Paypal");
            bool after = bl.IsDealExist(2);

            Assert.AreNotEqual(before, after, "should not be equal");
        }

        [TestMethod]
        public void DeleteRateTest()
        {
            bl.DeleteRates("Amitay", 1);
            bool after = bl.IsRateExist("Amitay", 1);
            Assert.AreEqual(after, false, "after should be false");
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            bl.DeleteUser("Fahima");
            bool after = bl.IsUserExist("Fahima");
            Assert.AreEqual(after, false, "after should be false");
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            bl.DeleteCategory(4);
            bool after = bl.IsCategoryExist(4);
            Assert.AreEqual(after, false, "after should be false");
        }

        [TestMethod]
        public void DeleteSecurePaymentTest()
        {
            bl.DeleteSecurePayments("Cash");
            bool after = bl.IsSecurePaymentExist("Cash");
            Assert.AreEqual(after, false, "after should be false");
        }

        [TestMethod]
        public void DeleteSystemManagerTest()
        {
            bl.DeleteSystemManager("shimi");
            bool after = bl.IsSystemManagerExist("shimi");
            Assert.AreEqual(after, false, "after should be false");
        }


        [TestCleanup]
        public void TearDown()
        {
            try
            {
                //added during the tests
                bl.InsertCategory(4, "Pnay", "some staff");
                bl.DeleteBusiness(2);
                bl.DeleteUser("Tomer");
                bl.DeleteManager("haliliAsaf");
                bl.DeleteUser("haliliAsaf");
                bl.DeleteDeal(2);
                bl.DeleteCoupon(2);
               
                //added in set up.
                bl.DeleteSecurePayments("Cash");
                bl.DeleteUser("Fahima");
                bl.DeleteRates("Amitay", 1);
                bl.DeleteDeal(1);
                bl.DeleteCustomerPreferences("Amitay", 1);
                bl.DeleteCustomer("Amitay");
                bl.DeleteCouponCategory(1, 1);
                bl.DeleteCoupon(1);
                bl.DeleteBusiness(1);
                bl.DeleteManager("shimi");
                bl.DeleteSecurePayments("Paypal");
                bl.DeleteCategory(1);
                bl.DeleteUser("shimi");
                bl.DeleteUser("Amitay");
            }
            catch (Exception)
            { }
            finally
            {
                conn.close();
            }
        }
    }
}