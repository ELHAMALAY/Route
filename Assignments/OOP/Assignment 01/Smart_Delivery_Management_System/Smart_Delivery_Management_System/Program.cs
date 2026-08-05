using System;

namespace Smart_Delivery_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryCenter center = new DeliveryCenter(10);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nEnter Shipment {i + 1}");

                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.Write("Weight: ");
                decimal weight = decimal.Parse(Console.ReadLine());

                Console.Write("Delivery Fee: ");
                decimal deliveryFee = decimal.Parse(Console.ReadLine());

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Street: ");
                string street = Console.ReadLine();

                Console.Write("Building Number: ");
                int buildingNumber = int.Parse(Console.ReadLine());

                DeliveryAddress address = new DeliveryAddress(city, street, buildingNumber);

                Shipment shipment = new Shipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    address);

                if (center.AddShipment(shipment))
                    Console.WriteLine("Shipment Added Successfully.");
                else
                    Console.WriteLine("Delivery Center is Full.");
            }

            Console.WriteLine("\n========== All Shipments ==========");

            for (int i = 0; i < 3; i++)
            {
                center[i].PrintShipment();
                Console.WriteLine("----------------------------------");
            }

            Console.Write("\nEnter Tracking Code to Search: ");
            string code = Console.ReadLine();

            Shipment result = center[code];

            if (result.TrackingCode != null)
            {
                Console.WriteLine("\nShipment Found:");
                result.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }

            Console.WriteLine("\n========== Struct Copy Test ==========");

            DeliveryAddress address1 = new DeliveryAddress("Cairo", "Nasr City", 10);
            DeliveryAddress address2 = address1;

            address2.City = "Alex";

            Console.WriteLine("Address 1:");
            Console.WriteLine(address1.GetFullAddress());

            Console.WriteLine("Address 2:");
            Console.WriteLine(address2.GetFullAddress());
        }
    }
}