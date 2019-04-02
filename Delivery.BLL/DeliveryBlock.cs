using System;

namespace Delivery.BLL
{
    public class DeliveryBlock
    {
        public DeliveryBlock(string departure, string arrival)
        {
            Departure = departure ?? throw new ArgumentNullException(nameof(departure), $"The {nameof(departure)} can't be null.");
            Arrival = arrival ?? throw new ArgumentNullException(nameof(arrival), $"The {nameof(arrival)} can't be null.");
        }

        public string Departure { get; }

        public string Arrival { get; }
    }
}
