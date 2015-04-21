using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Coupon_Web.DAL;

namespace Coupon_Web.PL
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            BL.BlRequests bl = new BL.BlRequests(conn.getSqlCon());

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


                bool ans = bl.IsBusinessExist(1);
                Label1.Text = ans.ToString();

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

                //Label1.Text = "avar beshalom!";

            }
            catch (Exception ee)
            {
                Label1.Text = ee.ToString();
            }
            finally
            {
                conn.close();
            }
        }

    }
}