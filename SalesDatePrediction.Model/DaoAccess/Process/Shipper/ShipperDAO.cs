using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Shipper;
using SalesDatePrediction.Model.Service;

namespace SalesDatePrediction.Model.DaoAccess.Process.Shipper
{
    public class ShipperDAO
    {
        readonly string connection = Constants.DBConnection;
        public List<GetShipper> GetShipper()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<GetShipper> ShipperList = new List<GetShipper>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.GetShippers", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                GetShipper ObjShipper;
                while (rd.Read())
                {
                    ObjShipper = new GetShipper();
                    ObjShipper.Shipperid = rd["Shipperid"] == DBNull.Value ? "" : rd["Shipperid"].ToString().Trim();
                    ObjShipper.Companyname = rd["Companyname"] == DBNull.Value ? "" : rd["Companyname"].ToString().Trim();
                    ShipperList.Add(ObjShipper);
                }
                return ShipperList;
            }
        }
    }
}
