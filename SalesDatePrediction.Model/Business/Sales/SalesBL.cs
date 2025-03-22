using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;
using SalesDatePrediction.Model.DaoAccess.Process.Sales;

namespace SalesDatePrediction.Model.Business.Sales
{
    public class SalesBL
    {
        public List<SalesPrediction> GetSalesDatePrediction()
        {
            return new SalesDAO().GetSalesDatePrediction();
        }
    }
}
