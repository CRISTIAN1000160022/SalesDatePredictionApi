using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SalesDatePrediction.Api.Controllers;
using SalesDatePrediction.Model.DaoAccess.Master.Sales;
using SalesDatePrediction.Model.Service;
using static SalesDatePrediction.Api.Models.Sales.ResponseSales;
using System.Web.Http.Results;
using System.Web.Http;
using Xunit;

namespace SalesDatePrediction.Tests
{
    public class SalesControllerTests
    {
        private readonly SalesController _controller;
        private readonly Mock<ISalesService> _mockSalesService;

        public SalesControllerTests()
        {
            _mockSalesService = new Mock<ISalesService>();
            _controller = new SalesController(_mockSalesService.Object);
        }

        [Fact]
        public void GetSalesDatePrediction_ReturnsOkResult()
        {
            // Arrange
            var salesPredictionList = new List<SalesPrediction> { new SalesPrediction { CustomerName = "Cliente 1" } };
            _mockSalesService.Setup(f => f.GetSalesDatePrediction()).Returns(salesPredictionList);

            // Act
            IHttpActionResult actionResult = _controller.GetSalesDatePrediction();
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseSalesDatePrediction>;

            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.True(contentResult.Content.success);
            Assert.Equal("Lista de predicción de fechas de venta generada correctamente", contentResult.Content.message);
            Assert.NotNull(contentResult.Content.Data);
            Assert.Equal(salesPredictionList, contentResult.Content.Data);
        }
    }
}
