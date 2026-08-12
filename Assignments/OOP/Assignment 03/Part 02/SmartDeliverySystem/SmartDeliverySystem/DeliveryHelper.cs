namespace SmartDeliverySystem
{
    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();

            string label = shipment switch
            {
                StandardShipment => "Standard Shipment",
                ExpressShipment => "Express Shipment",
                InternationalShipment => "International Shipment",
                _ => "Shipment"
            };
            Console.WriteLine($"{label} Printed Successfully.");
            Console.WriteLine();
        }
    }
}
