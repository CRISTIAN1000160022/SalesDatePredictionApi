using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Product;
using SalesDatePrediction.Model.Service;

namespace SalesDatePrediction.Model.DaoAccess.Process.Product
{
    public class ProductDAO
    {
        readonly string connection = Constants.DBConnection;
        public List<GetProduct> GetProduct()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<GetProduct> ProductList = new List<GetProduct>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Production.GetProducts", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                GetProduct ObjProduct;
                while (rd.Read())
                {
                    ObjProduct = new GetProduct();
                    ObjProduct.Productid = rd["Productid"] == DBNull.Value ? 0 : Convert.ToInt32(rd["Productid"]);
                    ObjProduct.Productname = rd["Productname"] == DBNull.Value ? "" : rd["Productname"].ToString().Trim();
                    ProductList.Add(ObjProduct);
                }
                return ProductList;
            }
        }
    }
}
