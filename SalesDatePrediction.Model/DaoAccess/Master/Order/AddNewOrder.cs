using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Model.DaoAccess.Master.Order
{
    public class AddNewOrder
    {
        public int Empid { get; set; }
        public int Shipid { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; } 
        public decimal Freight { get; set; }
        public string Shipcountry { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public int Qty { get; set; }
        public float Discount { get; set; }
    }
}
