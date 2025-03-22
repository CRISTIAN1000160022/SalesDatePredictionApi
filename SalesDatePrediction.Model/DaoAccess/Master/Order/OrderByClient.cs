using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Model.DaoAccess.Master.Order
{
    public class OrderByClient
    {
        public string orderid { get; set; }
        public string requireddate { get; set; }
        public string shippeddate { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
    }
}
