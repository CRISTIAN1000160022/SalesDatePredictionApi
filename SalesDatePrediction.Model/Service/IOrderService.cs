using System.Collections.Generic;
using SalesDatePrediction.Model.DaoAccess.Master.Order;

namespace SalesDatePrediction.Model.Service
{
    public interface IOrderService
    {
        List<OrderByClient> GetOrderByClient(int customerId);
        AddNewOrder AddNewOrder(AddNewOrder addNewOrderRequest);
    }
}

