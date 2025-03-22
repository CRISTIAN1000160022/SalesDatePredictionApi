using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Model.DaoAccess.Master.Sales
{
    public class SalesPrediction
    {
        public string CustomerName { get; set; }
        public string LastOrderDate { get; set; }
        public string NextPredictedOrder { get; set; }
    }
}
