using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Order;
using SalesDatePrediction.Model.Service;

namespace SalesDatePrediction.Model.DaoAccess.Process
{
    public class OrderDao
    {
        readonly string connection = Constants.DBConnection;
        public List<OrderByClient> GetOrderByClient(int CustomerId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<OrderByClient> OrderByClientList = new List<OrderByClient>();
                SqlCommand cmd = new SqlCommand("Sales.GetClientOrders", con);
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                OrderByClient ObjOrderByClient;
                while (rd.Read())
                {
                    ObjOrderByClient = new OrderByClient();
                    ObjOrderByClient.orderid = rd["orderid"] == DBNull.Value ? "" : rd["orderid"].ToString().Trim();
                    ObjOrderByClient.requireddate = rd["requireddate"] == DBNull.Value ? "" : rd["requireddate"].ToString().Trim();
                    ObjOrderByClient.shippeddate = rd["shippeddate"] == DBNull.Value ? "" : rd["shippeddate"].ToString().Trim();
                    ObjOrderByClient.shipname = rd["shipname"] == DBNull.Value ? "" : rd["shipname"].ToString().Trim();
                    ObjOrderByClient.shipaddress = rd["shipaddress"] == DBNull.Value ? "" : rd["shipaddress"].ToString().Trim();
                    ObjOrderByClient.shipcity = rd["shipcity"] == DBNull.Value ? "" : rd["shipcity"].ToString().Trim();
                    OrderByClientList.Add(ObjOrderByClient);
                }
                return OrderByClientList;
            }
        }
        public AddNewOrder AddNewOrder(AddNewOrder AddNewOrderRequest)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Sales.AddNewOrder", con);
                cmd.Parameters.AddWithValue("@Empid", AddNewOrderRequest.Empid);
                cmd.Parameters.AddWithValue("@Shipid", AddNewOrderRequest.Shipid);
                cmd.Parameters.AddWithValue("@Shipname", AddNewOrderRequest.Shipname);
                cmd.Parameters.AddWithValue("@Shipaddress", AddNewOrderRequest.Shipaddress);
                cmd.Parameters.AddWithValue("@Shipcity", AddNewOrderRequest.Shipcity);
                cmd.Parameters.AddWithValue("@Orderdate", AddNewOrderRequest.Orderdate);
                cmd.Parameters.AddWithValue("@Requireddate", AddNewOrderRequest.Requireddate);
                cmd.Parameters.AddWithValue("@Shippeddate", AddNewOrderRequest.Shippeddate);
                cmd.Parameters.AddWithValue("@Freight", AddNewOrderRequest.Freight);
                cmd.Parameters.AddWithValue("@Shipcountry", AddNewOrderRequest.Shipcountry);
                cmd.Parameters.AddWithValue("@Productid", AddNewOrderRequest.Productid);
                cmd.Parameters.AddWithValue("@Unitprice", AddNewOrderRequest.Unitprice);
                cmd.Parameters.AddWithValue("@Qty", AddNewOrderRequest.Qty);
                cmd.Parameters.AddWithValue("@Discount", AddNewOrderRequest.Discount);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();

                return AddNewOrderRequest;
            }
        }
    }
}
