using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;

namespace SalesDatePrediction.Model.Service
{
    public interface ISalesService
    {
        List<SalesPrediction> GetSalesDatePrediction();
    }
}
