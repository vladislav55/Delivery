using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Delivery.BLL.UnitTests
{
    public class SortingTests
    {
        [Fact]
        public void SortBlocks_ReturnSortedData()
        {
            // Arrange
            var blocksToSort = new List<DeliveryBlock>
            {
                new DeliveryBlock("5", "6"),
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("4", "5"),
                new DeliveryBlock("3", "4")
            };

            // Act
            blocksToSort.SortBlocks();


            // Assert
            Assert.True(IsSorted(blocksToSort));
        }

        [Fact]
        public void SortBlocks_with_the_same_departure_should_stay_last_found()
        {
            // Arrange
            var expected = new List<DeliveryBlock>
            {
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("2", "4"),
                new DeliveryBlock("4", "5")
            };

            var actual = new List<DeliveryBlock>
            {
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("4", "5"),
                new DeliveryBlock("2", "4")
            };

            // Act
            actual.SortBlocks();

            // Assert
            Assert.True(IsEqual(expected, actual));
        }

        [Fact]
        public void SortBlocks_with_the_same_arrival_should_stay_last_found()
        {
            // Arrange
            var expected = new List<DeliveryBlock>
            {
                new DeliveryBlock("1", "3"),
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("3", "4")
            };

            var actual = new List<DeliveryBlock>
            {
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("1", "3"),
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("3", "4")
            };

            // Act
            actual.SortBlocks();

            // Assert
            Assert.True(IsEqual(expected, actual));
        }

        [Fact]
        public void SortBlocks_the_same_blocks_should_stay_last_found()
        {
            // Arrange
            var expected = new List<DeliveryBlock>
            {
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("3", "4")
            };

            var actual = new List<DeliveryBlock>
            {
                new DeliveryBlock("3", "4"),
                new DeliveryBlock("1", "2"),
                new DeliveryBlock("2", "3"),
                new DeliveryBlock("1", "2")
            };

            // Act
            actual.SortBlocks();

            // Assert
            Assert.True(IsEqual(expected, actual));
        }

        [Fact]
        public void SortBlocks_initialization_with_null_stay_null()
        {
            // Arrange
            List<DeliveryBlock> nullValue = null;

            // Act
            nullValue.SortBlocks();

            // Assert
            Assert.Null(nullValue);
        }

        public static bool IsSorted(List<DeliveryBlock> deliveryBlocks)
        {
            for (int i = 1; i < deliveryBlocks.Count; i++)
            {
                if (deliveryBlocks[i - 1].Arrival != deliveryBlocks[i].Departure)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsEqual(List<DeliveryBlock> expected, List<DeliveryBlock> actual)
        {
            if (expected.Count != actual.Count)
            {
                return false;
            }

            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i].Arrival != actual[i].Arrival)
                {
                    return false;
                }
                else if(expected[i].Departure != actual[i].Departure)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
