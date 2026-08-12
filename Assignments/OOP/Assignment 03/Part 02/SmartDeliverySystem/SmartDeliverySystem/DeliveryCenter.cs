namespace SmartDeliverySystem
{
    public class DeliveryCenter
    {
        private const int MaxShipments = 20;
        private Shipment[] shipments = new Shipment[MaxShipments];
        private int count = 0;

        public string CenterName { get; set; }
        public Driver Driver { get; set; }

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }

        public Shipment this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    return null;
                return shipments[index];
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                        return shipments[i];
                }
                return null;
            }
        }

        public void AddShipment(Shipment shipment)
        {
            if (count >= MaxShipments)
            {
                Console.WriteLine("Delivery Center is full. Cannot add more shipments.");
                return;
            }
            shipments[count] = shipment;
            count++;
            Console.WriteLine("Shipment Added Successfully.");
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }
                    shipments[count - 1] = null;
                    count--;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            for (int i = 0; i < count; i++)
            {
                shipments[i].PrintShipment();
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}
