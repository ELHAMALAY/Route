namespace SmartDeliverySystem
{
    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");
            Console.WriteLine();
            base.PrintShipment();
        }
    }
}
