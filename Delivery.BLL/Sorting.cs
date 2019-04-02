using System.Collections.Generic;
using System.Linq;

namespace Delivery.BLL
{
    public static class Sorting
    {
        /// <summary>
        /// Sorting delivery blocks by arrival.
        /// </summary>
        /// <param name="unsorted">unsorted delivery blocks.</param>
        public static void SortBlocks(this List<DeliveryBlock> unsorted)
        {
            if (unsorted is null)
            {
                return;
            }

            var right = new List<DeliveryBlock>(unsorted);

            for (int i = 0; i < unsorted.Count;)
            {
                var result = FindByDeparture(right);

                if (result is null)
                {
                    unsorted[i] = right[0];
                    right.RemoveAt(0);

                    i++;
                }
                else
                {
                    right = result;
                }
            }
        }

        /// <summary>
        /// Searching for the same arrival with departure. 
        /// </summary>
        /// <param name="right"></param>
        /// <returns>changed blocks or null if arrival doesn't match with departure.</returns>
        private static List<DeliveryBlock> FindByDeparture(List<DeliveryBlock> right)
        {
            var left = right[0];

            for (int i = 1; i < right.Count(); i++)
            {
                if (left.Departure == right[i].Arrival)
                {
                    var temp = right[i];

                    right[i] = left;

                    for (int y = i - 1; y >= 0; y--)
                    {
                        var temp2 = right[y];

                        right[y] = temp;

                        temp = temp2;
                    }

                    return right;
                }
            }

            return null;
        }
    }
}
