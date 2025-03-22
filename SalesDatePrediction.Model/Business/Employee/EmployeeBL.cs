using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.GetEmployee;
using SalesDatePrediction.Model.DaoAccess.Process.Employee;

namespace SalesDatePrediction.Model.Business.Employee
{
    public class EmployeeBL
    {
        public List<GetEmployee> GetEmployee()
        {
            return new EmployeeDAO().GetEmployee();
        }
    }
}
