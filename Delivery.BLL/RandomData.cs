using System;
using System.Collections.Generic;

namespace Delivery.BLL
{
    public static class RandomData
    {
        /// <summary>
        /// Getting random DeliveryBlocks.
        /// </summary>
        /// <param name="quantityOfBlocks"></param>
        /// <returns></returns>
        public static List<DeliveryBlock> GetRandomBlocks(int quantityOfBlocks)
        {
            var output = new List<DeliveryBlock>();

            for (int i = 0; i < quantityOfBlocks; i++)
            {
                output.Add(new DeliveryBlock(i.ToString(), (i + 1).ToString() ));
            }

            return output.Shuffle();
        }

        private static Random rng = new Random();

        /// <summary>
        /// Data shuffle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataToShuffle"></param>
        /// <returns></returns>
        public static List<T> Shuffle<T>(this List<T> dataToShuffle)
        {
            int count = dataToShuffle.Count;
            while (count > 1)
            {
                count--;
                int randomIndex = rng.Next(count + 1);
                T value = dataToShuffle[randomIndex];
                dataToShuffle[randomIndex] = dataToShuffle[count];
                dataToShuffle[count] = value;
            }

            return dataToShuffle;
        }

    }
}
