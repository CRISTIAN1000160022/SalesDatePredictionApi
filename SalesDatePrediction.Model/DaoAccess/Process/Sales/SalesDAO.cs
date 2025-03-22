using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.Service;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;

namespace SalesDatePrediction.Model.DaoAccess.Process.Sales
{
    public class SalesDAO
    {
        readonly string connection = Constants.DBConnection;
        public List<SalesPrediction> GetSalesDatePrediction()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<SalesPrediction> SalesPredictionList = new List<SalesPrediction>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.GetSalesDatePrediction", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                SalesPrediction ObjSalesPrediction;

                while (rd.Read())
                {
                    ObjSalesPrediction = new SalesPrediction();

                    ObjSalesPrediction.CustomerName = rd["CustomerName"] == DBNull.Value ? "" : rd["CustomerName"].ToString().Trim();
                    ObjSalesPrediction.LastOrderDate = rd["LastOrderDate"] == DBNull.Value ? "" : rd["LastOrderDate"].ToString().Trim();
                    ObjSalesPrediction.NextPredictedOrder = rd["NextPredictedOrder"] == DBNull.Value ? "" : rd["NextPredictedOrder"].ToString().Trim();

                    SalesPredictionList.Add(ObjSalesPrediction);
                }
                return SalesPredictionList;
            }
        }
    }
}
