﻿using System;
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

            //SqlCommand cmdSql = new SqlCommand("insert into [users] values (@UserName,@Name,@Password)", conn.getSqlCon());
           
            conn.open();

            /*cmdSql.Parameters.AddWithValue("@UserName", "shimi2");
            cmdSql.Parameters.AddWithValue("@Name", "shimisv");
            cmdSql.Parameters.AddWithValue("@Password", "1234");

            cmdSql.ExecuteNonQuery();*/
            
            //bl.InsertUser("asdsdasd", "asds", "svds svcv");
            bl.InsertUser("Amitay140", "amitay", "12345678"); // customer
            bl.InsertUser("shimi", "amitay", "12345678"); // manager
            bl.InsertCategory(2, "Entertainment", "stand-ups, tv-Shows, etc...");
            bl.InsertSecuredPayment("Paypal", 5);
            bl.InsertManager("shimi");
            bl.InsertBusiness(123, "Hamashbir", "menashe kapara 33 Rehovot", "in the shop you can find a lot of things", "shimi");
            bl.InsertCoupon(1234, "dead-sea-soap", 100, 70, new DateTime(2014, 04, 06), 1, 123);
            bl.InsertCouponCategory(1234, 2);
            bl.InsertCustomer("Amitay140", "amitay@gmail.com", "0542819491");
            bl.InsertCustomerPreference("Amitay140", 2);
            bl.InsertDeal(111, 0, "11111", 1234, "Amitay140");
            bl.InsertPaidBy(111, "Paypal");
            bl.InsertRates("Amitay", 1234, 3, "good");
            
            Label1.Text = "avar beshalom!";

            conn.close();
        }
    }
}