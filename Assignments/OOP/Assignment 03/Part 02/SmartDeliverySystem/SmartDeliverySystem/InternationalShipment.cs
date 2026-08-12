namespace SmartDeliverySystem
{
    public class InternationalShipment : Shipment
    {
        public string DestinationCountry { get; set; }
        public decimal CustomsFee { get; set; }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            if (string.IsNullOrWhiteSpace(destinationCountry))
                throw new ArgumentException("DestinationCountry cannot be null, empty, or whitespace.");
            if (customsFee < 0)
                throw new ArgumentException("CustomsFee must be greater than or equal to 0.");
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code       : {TrackingCode}");
            Console.WriteLine($"Description         : {Description}");
            Console.WriteLine($"Weight              : {Weight} KG");
            Console.WriteLine($"Delivery Fee        : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee         : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost      : {EstimatedCost} EGP");
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs report generated for shipment {TrackingCode} to {DestinationCountry}.");
        }
    }
}
