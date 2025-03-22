using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Model.Service
{
    public static class Constants
    {
        public static readonly string DBConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}
