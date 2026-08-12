namespace SmartDeliverySystem
{
    public class Shipment
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Destination { get; set; }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee)
            : this(trackingCode, description, weight, deliveryFee, new DeliveryAddress())
        {
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
                throw new ArgumentException("TrackingCode cannot be null, empty, or whitespace.");
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null, empty, or whitespace.");
            if (weight <= 0)
                throw new ArgumentException("Weight must be greater than 0.");
            if (deliveryFee < 0)
                throw new ArgumentException("DeliveryFee must be greater than or equal to 0.");

            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public virtual decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee < 0)
                throw new ArgumentException("DeliveryFee must be greater than or equal to 0.");
            DeliveryFee = newFee;
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight <= 0)
                throw new ArgumentException("Weight must be greater than 0.");
            Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            if (newWeight <= 0)
                throw new ArgumentException("Weight must be greater than 0.");
            if (extraPackingWeight < 0)
                throw new ArgumentException("Extra packing weight must be greater than or equal to 0.");
            Weight = newWeight + extraPackingWeight;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }
}
