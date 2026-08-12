namespace SmartDeliverySystem
{
    public class ExpressShipment : Shipment
    {
        public decimal ExtraFee { get; set; }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            if (extraFee < 0)
                throw new ArgumentException("ExtraFee must be greater than or equal to 0.");
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + ExtraFee;

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }
}
