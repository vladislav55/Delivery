using Delivery.Api.Controllers;
using Delivery.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Delivery.Api.UnitTests
{
    public class DeliveryControllerTest
    {
        [Fact]
        public void Get_sorted_deliveryBlocks_success()
        {
            //Arrange

            //Act
            var deliveryController = new DeliveryController();
            var actionResult = deliveryController.GetDeliveryBlocks();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<DeliveryBlock>>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
    }
}
