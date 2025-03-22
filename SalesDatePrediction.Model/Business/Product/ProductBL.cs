using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatePrediction.Model.DaoAccess.Master.Product;
using SalesDatePrediction.Model.DaoAccess.Process.Product;

namespace SalesDatePrediction.Model.Business.Product
{
    public class ProductBL
    {
        public List<GetProduct> GetProduct()
        {
            return new ProductDAO().GetProduct();
        }
    }
}
