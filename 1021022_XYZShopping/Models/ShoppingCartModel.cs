using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _1021022_XYZShopping.Models
{
    public class ShoppingCartModel
    {
        const string CONNSTR = "server= LAPTOP-LDM385CT;integrated security=true;database=XYZEVEDB";
        [Display(Name = "Username")]
        public string Email_Id { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Please send us in your feedback..")]
        public string feedback { get; set; }
        public string checkUser(string username, string password)
        {
            string changedValue;
            using (SqlConnection conn = new SqlConnection())

            {

                conn.ConnectionString = CONNSTR;
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select UserID from Users where Username='" + username + "' and Password='" + password + "'", conn);

                changedValue = cmd.ExecuteScalar().ToString();

                if (changedValue != null)
                {

                    return changedValue;

                }

                return changedValue;

            }
        }
        public bool updateFeedback(string userID, string feedback)
        {
            bool value = false;
            int changedValue = 0;
            using (SqlConnection conn = new SqlConnection())

            {

                conn.ConnectionString = CONNSTR;
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into FeedBackTable(UserID,Feedback) values('" + userID + "','" + feedback + "')", conn);

                changedValue = cmd.ExecuteNonQuery();

                if (changedValue > 0)
                {
                    value = true;
                    return value;

                }

                return value;

            }
        }
        public List<OrderDetailsModel> getOrderDetails()
        {
            OrderDetailsModel orderModel = null;
            List<OrderDetailsModel> orderList = new List<OrderDetailsModel>();
            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = CONNSTR;
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from OrderDetails", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())

                {

                    orderModel = new OrderDetailsModel();
                    orderModel.OrderDetailID = Convert.ToString(rd.GetSqlValue(0));
                    orderModel.OrderNo = Convert.ToString(rd.GetSqlValue(1));
                    orderModel.ItemNo = Convert.ToString(rd.GetSqlValue(2));
                    orderModel.ItemDesc = Convert.ToString(rd.GetSqlValue(3));
                    orderModel.Qty = Convert.ToString(rd.GetSqlValue(4));
                    orderModel.Price = Convert.ToString(rd.GetSqlValue(5));
                    orderList.Add(orderModel);

                }

                return orderList;
            }
        }

        public List<ProductsModel> getProducts()
        {
            ProductsModel prodModel = null;
            List<ProductsModel> prodList = new List<ProductsModel>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNSTR;
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Products", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    prodModel = new ProductsModel();
                    prodModel.productId = Convert.ToString(rd.GetSqlValue(0));
                    prodModel.CatID = Convert.ToString(rd.GetSqlValue(1));
                    prodModel.ProductSDesc = Convert.ToString(rd.GetSqlValue(2));
                    prodModel.ProductLDesc = Convert.ToString(rd.GetSqlValue(3));
                    prodModel.Price = Convert.ToString(rd.GetSqlValue(5));
                    prodModel.Instock = Convert.ToString(rd.GetSqlValue(6));
                    prodModel.Inventory = Convert.ToString(rd.GetSqlValue(7));
                    prodList.Add(prodModel);
                }
                return prodList;
            }
        }
        public List<ProfileDataModel> getCustomerDetails(string userID)
        {

            ProfileDataModel profile = null;
            List<ProfileDataModel> profList = new List<ProfileDataModel>();
            using (SqlConnection conn = new SqlConnection())

            {
                conn.ConnectionString = CONNSTR;
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from CustomerInfos where UserID = '" + userID + "'", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())

                {

                    profile = new ProfileDataModel();
                    profile.UserID = Convert.ToString(rd.GetSqlValue(0));
                    profile.FirstName = Convert.ToString(rd.GetSqlValue(1));
                    profile.LastName = Convert.ToString(rd.GetSqlValue(2));
                    profile.Address = Convert.ToString(rd.GetSqlValue(3)) + Convert.ToString(rd.GetSqlValue(4)) + Convert.ToString(rd.GetSqlValue(5)) + Convert.ToString(rd.GetSqlValue(6));
                    profile.CCNumber = Convert.ToString(rd.GetSqlValue(7));
                    profile.Email = Convert.ToString(rd.GetSqlValue(10));
                    profList.Add(profile);

                }

                return profList;
            }

        }
    }
}