using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using SalesDatePrediction.Api.Controllers.Order;
using SalesDatePrediction.Model.DaoAccess.Master.Order;
using SalesDatePrediction.Model.Service;
using Xunit;
using static SalesDatePrediction.Api.Models.Order.ResponseOrder;

namespace SalesDatePrediction.Tests
{
    public class OrderControllerTests
    {
        private readonly OrderController _controller;
        private readonly Mock<IOrderService> _mockOrderService;

        public OrderControllerTests()
        {
            _mockOrderService = new Mock<IOrderService>();
            _controller = new OrderController(_mockOrderService.Object);
        }

        [Fact]
        public void GetOrderByClient_ReturnsOkResult()
        {
            // Arrange
            int customerId = 1;
            var orderList = new List<OrderByClient> { new OrderByClient { orderid = "1" } };
            _mockOrderService.Setup(service => service.GetOrderByClient(customerId)).Returns(orderList);

            // Act
            IHttpActionResult actionResult = _controller.GetOrderByClient(customerId);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseOrderByClient>;

            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.True(contentResult.Content.success);
            Assert.Equal("Lista de ordenes por cliente generada correctamente", contentResult.Content.message);
            Assert.NotNull(contentResult.Content.Data);
            Assert.Equal(orderList, contentResult.Content.Data);
        }

        [Fact]
        public void AddNewOrder_ReturnsOkResult()
        {
            // Arrange
            var newOrder = new AddNewOrder
            {
                Empid = 1,
                Shipid = 2,
                Shipname = "Nombre del envío",
                Shipaddress = "Dirección del envío",
                Shipcity = "Bogotá D.C.",
                Orderdate = new DateTime(2025, 3, 21),
                Requireddate = new DateTime(2025, 3, 28),
                Shippeddate = new DateTime(2025, 3, 22),
                Freight = 100.50m,
                Shipcountry = "País del envío",
                Productid = 3,
                Unitprice = 50.75m,
                Qty = 10,
                Discount = 0.1f
            };
            _mockOrderService.Setup(service => service.AddNewOrder(newOrder)).Returns(newOrder);

            // Act
            IHttpActionResult actionResult = _controller.AddNewOrder(newOrder);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseAddNewOrder>;

            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.True(contentResult.Content.success);
            Assert.Equal("Orden generada correctamente", contentResult.Content.message);
            Assert.NotNull(contentResult.Content.Data);
            Assert.Equal(newOrder, contentResult.Content.Data);
        }

        [Fact]
        public void AddNewOrder_ReturnsBadRequest_WhenShipnameTooLong()
        {
            // Arrange
            var newOrder = new AddNewOrder { Empid = 1, Shipname = new string('a', 41) };

            // Act
            IHttpActionResult actionResult = _controller.AddNewOrder(newOrder);
            var contentResult = actionResult as NegotiatedContentResult<ResponseAddNewOrder>;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(HttpStatusCode.BadRequest, contentResult.StatusCode);
            Assert.NotNull(contentResult.Content);
            Assert.False(contentResult.Content.success);
            Assert.Equal("Error: El campo 'Shipname' supera la longitud permitida de 40 caracteres.", contentResult.Content.message);
            Assert.Null(contentResult.Content.Data);
        }
    }
}