using System;
using Xunit;

namespace Delivery.BLL.UnitTests
{
    public class DeliveryBlockTests
    {
        [Fact]
        public void DeliveryBlock_initialization_with_null_arguments_should_fail()
        {
            // Arrange
            string departure = null;
            string arrival = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => new DeliveryBlock(departure, arrival));
        }

        [Fact]
        public void DeliveryBlock_should_be_not_null()
        {
            // Arrange
            string departure = "departure";
            string arrival = "arrival";

            // Assert
            Assert.NotNull(new DeliveryBlock(departure, arrival));
        }
    }
}
