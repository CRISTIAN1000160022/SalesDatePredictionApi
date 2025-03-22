using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.Business.Employee;
using SalesDatePrediction.Model.Business.Order;
using SalesDatePrediction.Model.Business.Product;
using SalesDatePrediction.Model.Business.Sales;
using SalesDatePrediction.Model.Business.Shipper;
using SalesDatePrediction.Model.DaoAccess.Master.GetEmployee;
using SalesDatePrediction.Model.DaoAccess.Master.Order;
using SalesDatePrediction.Model.DaoAccess.Master.Product;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;
using SalesDatePrediction.Model.DaoAccess.Master.Shipper;

namespace SalesDatePrediction.Model.Service
{
    public class Facade
    {
        #region Sales
        public List<SalesPrediction> GetSalesDatePrediction()
        {
            return new SalesBL().GetSalesDatePrediction();
        }
        #endregion
        #region Order
        public List<OrderByClient> GetOrderByClient(int CustomerId)
        {
            return new OrderBL().GetOrderByClient(CustomerId);
        }

        public AddNewOrder AddNewOrder(AddNewOrder AddNewOrderRequest)
        {
            return new OrderBL().AddNewOrder(AddNewOrderRequest);
        }
        #endregion
        #region Employee
        public List<GetEmployee> GetEmployee()
        {
            return new EmployeeBL().GetEmployee();
        }
        #endregion
        #region Shipper
        public List<GetShipper> GetShipper()
        {
            return new ShipperBL().GetShipper();
        }
        #endregion
        #region Product
        public List<GetProduct> GetProduct()
        {
            return new ProductBL().GetProduct();
        }
        #endregion
    }
}
