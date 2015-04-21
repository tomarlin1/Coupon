using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coupon_Web.DAL;
using System.Data.SqlClient;

namespace Coupon_Web.BL
{
    public class BlRequests
    {
        private Queries _query;
        public BlRequests(SqlConnection conn)
        {
            _query = new Queries(conn);
        }

        /// <the next functions are related to various Insert's functions.>
        /// 
        /// </summary>
        public void InsertBusiness(int id, String name, String address, String description, String managerUserName)
        {
            String[] values = new String[] { id.ToString(), name, address, description, managerUserName };
            _query.Insert("Buisness", values);
        }
        public void InsertCategory(int id, String name, String description)
        {
            String[] values = new String[] { id.ToString(), name, description };
            _query.Insert("Category", values);
        }
        public void InsertCoupon(int id, String name, double originalMoney, double discountPrice, DateTime expiredDate, int rating, int businessId)
        {
            String[] values = new String[] { id.ToString(), name, originalMoney.ToString(), discountPrice.ToString(), expiredDate.ToString(), rating.ToString(), businessId.ToString() };
            _query.Insert("Coupon", values);
        }
        public void InsertCouponCategory(int couponId, int categoryId)
        {
            String[] values = new String[] { couponId.ToString(), categoryId.ToString() };
            _query.Insert("CouponCategories", values);
        }
        public void InsertCustomer(String userName, String email, String phone)
        {
            String[] values = new String[] { userName, email, phone };
            _query.Insert("Customer", values);
        }
        public void InsertCustomerPreference(String CustomerUserName, int categoryId)
        {
            String[] values = new String[] { CustomerUserName, categoryId.ToString() };
            _query.Insert("CustomerPerferences", values);
        }
        public void InsertDeal(int id, int status, String serialKey, int couponId, String customerUserName, String paymentMethod)
        {
            String[] values = new String[] { id.ToString(), status.ToString(), serialKey, couponId.ToString(), customerUserName, paymentMethod };
            _query.Insert("Deal", values);
        }
        public void InsertFriend(String userName, String friendUserName)
        {
            String[] values = new String[] { userName, friendUserName };
            _query.Insert("Friends", values);
        }
        public void InsertManager(String userName)
        {
            String[] values = new String[] { userName };
            _query.Insert("Manager", values);
        }
        public void InsertRates(String userName, int couponId, int rateNumber, String description)
        {
            String[] values = new String[] { userName, couponId.ToString(), rateNumber.ToString(), description };
            _query.Insert("Rates", values);
        }
        public void InsertSecurePayment(String method, int securedLevel)
        {
            String[] values = new String[] { method, securedLevel.ToString() };
            _query.Insert("SecurePayment", values);
        }
        public void InsertSystemManager(String userName)
        {
            String[] values = new String[] { userName };
            _query.Insert("SystemManager", values);
        }
        public void InsertUser(String userName, String name, String password)
        {
            String[] values = new String[] { userName, name, password };
            _query.Insert("Users", values);
        }
        /// <the next functions are related to various Delete's functions.>
        /// 
        /// </summary>
        public void DeleteBusiness(int id)
        {
            String[] pkNames = new String[] { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            _query.Delete("Buisness", pkNames, pkValues);
        }

        public void DeleteCategory(int id)
        {
            String[] pkNames = new String[] { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            _query.Delete("Category", pkNames, pkValues);
        }

        public void DeleteCoupon(int couponId)
        {
            String[] pkNames = new String[] { "Id" };
            String[] pkValues = new String[] { couponId.ToString() };
            _query.Delete("Coupon", pkNames, pkValues);
        }

        public void DeleteCouponCategory(int couponId, int categoryId)
        {
            String[] pkNames = new String[] { "CouponId", "CategoryId" };
            String[] pkValues = new String[] { couponId.ToString(), categoryId.ToString() };
            _query.Delete("CouponCategories", pkNames, pkValues);
        }

        public void DeleteCustomer(String userName)
        {
            String[] pkNames = new String[] { "UserName" };
            String[] pkValues = new String[] { userName };
            _query.Delete("Customer", pkNames, pkValues);
        }

        public void DeleteCustomerPreferences(String userName, int categoryId)
        {
            String[] pkNames = new String[] { "CustomerUserName", "CategoryId" };
            String[] pkValues = new String[] { userName, categoryId.ToString() };
            _query.Delete("CustomerPerferences", pkNames, pkValues);
        }

        public void DeleteDeal(int id)
        {
            String[] pkNames = new String[] { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            _query.Delete("Deal", pkNames, pkValues);
        }

        public void DeleteFriend(String userName, String friendUserName)
        {
            String[] pkNames = new String[] { "UserName", "FriendUserName" };
            String[] pkValues = new String[] { userName, friendUserName };
            _query.Delete("Friends", pkNames, pkValues);
        }

        public void DeleteManager(String userName)
        {
            String[] pkNames = new String[] { "UserName" };
            String[] pkValues = new String[] { userName };
            _query.Delete("Manager", pkNames, pkValues);
        }

        public void DeleteRates(String userName, int couponId)
        {
            String[] pkNames = new String[] { "CustomerUserName", "CouponId" };
            String[] pkValues = new String[] { userName, couponId.ToString() };
            _query.Delete("Rates", pkNames, pkValues);
        }

        public void DeleteSecurePayments(String method)
        {
            String[] pkNames = new String[] { "Method" };
            String[] pkValues = new String[] { method };
            _query.Delete("SecurePayment", pkNames, pkValues);
        }

        public void DeleteSystemManager(String userName)
        {
            String[] pkNames = new String[] { "UserName" };
            String[] pkValues = new String[] { userName };
            _query.Delete("SystemManager", pkNames, pkValues);
        }

        public void DeleteUser(String userName)
        {
            String[] pkNames = new String[] { "UserName" };
            String[] pkValues = new String[] { userName };
            _query.Delete("Users", pkNames, pkValues);
        }

        /// <the next functions are related to various Edit's functions.>
        /// 
        /// </summary>

        public void EditBusiness(int id, String fieldToEdit, Object value)
        {
            String[] pkNames = new String[] { "BuisnessId" };
            String[] pkValues = new String[] { id.ToString() };
            _query.EditField("Buisness", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        public void EditCategory(int id, String fieldToEdit, Object value)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            _query.EditField("Category", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        public void EditCoupon(int id, String fieldToEdit, Object value)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            _query.EditField("Coupon", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        public void EditCustomer(String userName, String fieldToEdit, Object value)
        {
            String[] pkNames = { "UserName" };
            String[] pkValues = new String[] { userName };
            _query.EditField("Cutomer", pkNames, pkValues, fieldToEdit, value.ToString());
        }

        public void EditDeal(int id, String fieldToEdit, Object value)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            _query.EditField("Deal", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        public void EditRates(String customerUserName, int couponId, String fieldToEdit, Object value)
        {
            String[] pkNames = { "CustomerUserName", "CouponId" };
            String[] pkValues = new String[] { customerUserName, couponId.ToString() };
            _query.EditField("Rates", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        public void EditSecurePayment(String method, String fieldToEdit, Object value)
        {
            String[] pkNames = { "Method" };
            String[] pkValues = new String[] { method };
            _query.EditField("SecurePayment", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        public void EditUser(String userName, String fieldToEdit, Object value)
        {
            String[] pkNames = { "UserName" };
            String[] pkValues = new String[] { userName };
            _query.EditField("Users", pkNames, pkValues, fieldToEdit, value.ToString());
        }
        /// <the next functions are related to various Edit's functions.>
        /// 
        /// </summary>

        public bool IsBusinessExist(int id)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            return _query.isExist("Buisness", pkNames, pkValues);
        }

        public bool IsCategoryExist(int id)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            return _query.isExist("Category", pkNames, pkValues);
        }

        public bool IsCouponExist(int id)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            return _query.isExist("Coupon", pkNames, pkValues);
        }

        public bool IsCouponCategoryExist(int couponId, int categrotyId)
        {
            String[] pkNames = { "CouponId", "CategoryId" };
            String[] pkValues = new String[] { couponId.ToString(), categrotyId.ToString() };
            return _query.isExist("CouponCategories", pkNames, pkValues);
        }

        public bool IsCustomerExist(String userName)
        {
            String[] pkNames = { "UserName" };
            String[] pkValues = new String[] { userName };
            return _query.isExist("", pkNames, pkValues);
        }

        public bool IsCustomerPreferenceExist(String userName, int categoryId)
        {
            String[] pkNames = { "CustomerUserName", "CategoryId" };
            String[] pkValues = new String[] { userName, categoryId.ToString() };
            return _query.isExist("CustomerPerferences", pkNames, pkValues);
        }

        public bool IsDealExist(int id)
        {
            String[] pkNames = { "Id" };
            String[] pkValues = new String[] { id.ToString() };
            return _query.isExist("Deal", pkNames, pkValues);
        }

        public bool IsFriendExist(String userName, String friendUserName)
        {
            String[] pkNames = { "UserName", "FriendUserName" };
            String[] pkValues1 = new String[] { userName, friendUserName };
            String[] pkValues2 = new String[] { friendUserName, userName };
            return (_query.isExist("Friends", pkNames, pkValues1)
                || _query.isExist("Friends", pkNames, pkValues2));
        }

        public bool IsManagerExist(String userName)
        {
            String[] pkNames = { "UserName" };
            String[] pkValues = new String[] { userName };
            return _query.isExist("Manager", pkNames, pkValues);
        }

        public bool IsRateExist(String customerUserName, int couponId)
        {
            String[] pkNames = { "customerUserName", "CouponId" };
            String[] pkValues = new String[] { customerUserName, couponId.ToString() };
            return _query.isExist("Rates", pkNames, pkValues);
        }

        public bool IsSecurePaymentExist(String method)
        {
            String[] pkNames = { "Method" };
            String[] pkValues = new String[] { method };
            return _query.isExist("SecurePayment", pkNames, pkValues);
        }

        public bool IsSystemManagerExist(String userName)
        {
            String[] pkNames = { "UserName" };
            String[] pkValues = new String[] { userName };
            return _query.isExist("SystemManager", pkNames, pkValues);
        }

        public bool IsUserExist(String userName)
        {
            String[] pkNames = { "UserName" };
            String[] pkValues = new String[] { userName };
            return _query.isExist("Users", pkNames, pkValues);
        }

    }
}