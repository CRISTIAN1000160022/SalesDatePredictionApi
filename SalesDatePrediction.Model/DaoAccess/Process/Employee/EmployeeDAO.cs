using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.GetEmployee;
using SalesDatePrediction.Model.Service;

namespace SalesDatePrediction.Model.DaoAccess.Process.Employee
{
    public class EmployeeDAO
    {
        readonly string connection = Constants.DBConnection;
         public List<GetEmployee> GetEmployee()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                List<GetEmployee> GetEmployeeList = new List<GetEmployee>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HR.GetEmployees", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rd = cmd.ExecuteReader();
                GetEmployee ObjGetEmployee;

                while (rd.Read())
                {
                    ObjGetEmployee = new GetEmployee();

                    ObjGetEmployee.Empid = rd["Empid"] == DBNull.Value ? "" : rd["Empid"].ToString().Trim();
                    ObjGetEmployee.FullName = rd["FullName"] == DBNull.Value ? "" : rd["FullName"].ToString().Trim();

                    GetEmployeeList.Add(ObjGetEmployee);
                }
                return GetEmployeeList;
            }
        }
    }
}
