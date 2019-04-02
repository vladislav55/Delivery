using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Delivery.BLL.UnitTests
{
    public class RandomDataTests
    {
        [Fact]
        public void Shuffle_return_the_same_data()
        {
            // Arrange
            List<int> testData = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // Act
            var actual = testData.Shuffle();

            var uniqueItems = actual.Union(testData);

            // Assert
            Assert.True(actual.Count() == testData.Count());
            Assert.True(uniqueItems.Count() == testData.Count());
        }
    }
}
