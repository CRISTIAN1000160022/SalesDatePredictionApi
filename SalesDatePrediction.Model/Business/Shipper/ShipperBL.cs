using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Shipper;
using SalesDatePrediction.Model.DaoAccess.Process.Shipper;

namespace SalesDatePrediction.Model.Business.Shipper
{
    public class ShipperBL
    {
        public List<GetShipper> GetShipper()
        {
            return new ShipperDAO().GetShipper();
        }

    }
}
