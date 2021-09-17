using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test.Controllers;
using Test.Interfaces;
using Test.Models;

namespace Test.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTests
    {
        [TestMethod]
        public void Test_GetByID_ValidID()
        {
            //Arrange
            var mockOrderRepo = new Mock<IOrderRepository>();
            var orderID = 2;
            mockOrderRepo.Setup(x => x.GetByIdAsync(orderID)).ReturnsAsync(new Order {Id = 2});
            var controller = new OrdersController(mockOrderRepo.Object);

            //Act
            var response = controller.GetByID(orderID);
            var contentResult = response.Result as OkNegotiatedContentResult<Order>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(orderID, contentResult.Content.Id);
        }

        [TestMethod]
        public void Test_GetByID_InvalidID()
        {
            //Arrange
            var mockOrderRepo = new Mock<IOrderRepository>();
            var orderID = 6;
            mockOrderRepo.Setup(x => x.GetByIdAsync(orderID)).ReturnsAsync((Order) null);
            var controller = new OrdersController(mockOrderRepo.Object);

            //Act
            var response = controller.GetByID(orderID);
            var contentResult = response.Result as NotFoundResult;

            //Assert
            Assert.IsNotNull(contentResult);
        }
    }
}
