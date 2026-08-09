using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System
{
    class DeliveryCenter
    {
        public string CenterName { get; set; }

        private Shipment[] shipments;

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
            shipments = new Shipment[20];
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }

                return default;
            }

            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null &&
                        shipments[i].TrackingCode == trackingCode)
                    {
                        return shipments[i];
                    }
                }

                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null &&
                    shipments[i].TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }

            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Delivery Center : {CenterName}");
            Console.WriteLine("========================================");

            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null)
                {
                    Console.WriteLine();

                    if (shipments[i] is StandardShipment)
                    {
                        Console.WriteLine("Standard Shipment");
                    }
                    else if (shipments[i] is ExpressShipment)
                    {
                        Console.WriteLine("Express Shipment");
                    }
                    else if (shipments[i] is InternationalShipment)
                    {
                        Console.WriteLine("International Shipment");
                    }

                    Console.WriteLine();

                    shipments[i].PrintShipment();

                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------");
                }
            }
        }
    }
}
