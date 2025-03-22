using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Order;
using SalesDatePrediction.Model.DaoAccess.Process;

namespace SalesDatePrediction.Model.Business.Order
{
    public class OrderBL
    {
        public List<OrderByClient> GetOrderByClient(int CustomerId)
        {
            return new OrderDao().GetOrderByClient(CustomerId);
        }
        public AddNewOrder AddNewOrder(AddNewOrder AddNewOrderRequest)
        {
            return new OrderDao().AddNewOrder(AddNewOrderRequest);
        }
    }
}
