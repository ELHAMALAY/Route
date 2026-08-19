using System;
using SmartDeliveryManagementSystem.Models;
using SmartDeliveryManagementSystem.Extensions;
using SmartDeliveryManagementSystem.Utilities;

namespace SmartDeliveryManagementSystem
{
    internal class Program
    {
        private static void Main()
        {
            DeliveryUtilities.PrintSystemTitle();
            Console.WriteLine();
            DeliveryUtilities.PrintSectionTitle("Creating Shipments...");
            Console.WriteLine();

            Shipment shipment1 = new Shipment("SH001", "Standard", 3, new DeliveryAddress("Cairo"));
            Console.WriteLine("Standard Shipment Created");
            Shipment shipment2Source = new Shipment("SH002", "Express", 2, new DeliveryAddress("Alexandria"));
            Console.WriteLine("Express Shipment Created");
            Shipment shipment3 = new Shipment("SH003", "International", 8, new DeliveryAddress("Luxor"));
            Console.WriteLine("International Shipment Created");

            shipment2Source.UpdateTrackingStatusSilently("Out For Delivery");
            shipment1.UpdateTrackingStatusSilently("In Transit");
            shipment3.UpdateTrackingStatusSilently("Delivered");

            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();

            DeliveryUtilities.PrintSectionTitle("Object Copying");
            Console.WriteLine();

            Shipment referenceAssigned = shipment1; 
            Console.WriteLine($"Original Shipment : {shipment1.TrackingCode}");
            Console.WriteLine($"Assigned Shipment : {referenceAssigned.TrackingCode}");
            Console.WriteLine();
            Console.WriteLine($"Same Object (ReferenceEquals) : {ReferenceEquals(shipment1, referenceAssigned)}");

            Shipment actualCopy = shipment1.CopyShipment();
            Console.WriteLine($"Same Object (actual copy)     : {ReferenceEquals(shipment1, actualCopy)}");
            Console.WriteLine();

            DeliveryUtilities.PrintSubSectionTitle("Shallow Copy");
            Console.WriteLine();

            Shipment shallowCopy = shipment1.ShallowCopy();
            Console.WriteLine($"Different Objects           : {!ReferenceEquals(shipment1, shallowCopy)}");
            Console.WriteLine($"Original Shipment Address   : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address     : {shallowCopy.DeliveryAddress.City}");
            Console.WriteLine();
            Console.WriteLine("Changing copied shipment address...");
            Console.WriteLine();
            shallowCopy.DeliveryAddress.City = "Giza";
            Console.WriteLine($"Original Shipment Address   : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address     : {shallowCopy.DeliveryAddress.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment1.DeliveryAddress, shallowCopy.DeliveryAddress)}");
            Console.WriteLine();

            shipment1.DeliveryAddress.City = "Cairo";

            DeliveryUtilities.PrintSubSectionTitle("Deep Copy");
            Console.WriteLine();

            Shipment deepCopy = shipment1.DeepCopy();
            Console.WriteLine($"Original Shipment Address   : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address     : {deepCopy.DeliveryAddress.City}");
            Console.WriteLine();
            Console.WriteLine("Changing copied shipment address...");
            Console.WriteLine();
            deepCopy.DeliveryAddress.City = "Giza";
            Console.WriteLine($"Original Shipment Address   : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address     : {deepCopy.DeliveryAddress.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment1.DeliveryAddress, deepCopy.DeliveryAddress)}");
            Console.WriteLine();

            DeliveryUtilities.PrintSectionTitle("Extension Methods");
            Console.WriteLine();

            Console.WriteLine(shipment1.GetSummary());
            Console.WriteLine(shipment2Source.GetSummary());
            Console.WriteLine(shipment3.GetSummary());
            Console.WriteLine();
            Console.WriteLine($"SH001 Is Delivered : {shipment1.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {shipment3.IsDelivered()}");
            Console.WriteLine();

            DeliveryUtilities.PrintSectionTitle("Tracking Status");
            Console.WriteLine();
            shipment2Source.UpdateTrackingStatus("Out For Delivery");
            Console.WriteLine();

            // -------------------------------------------------------------
            // 4, 5, 6, 7) Static Utilities
            // -------------------------------------------------------------
            DeliveryUtilities.PrintSectionTitle("Static Utilities");
            Console.WriteLine();
            DeliveryUtilities.PrintSubSectionTitle("Delivery Center");
            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();

            DeliveryUtilities.PrintSectionTitle("Partial Method");
            Console.WriteLine();
            shipment1.UpdateTrackingStatus("Delivered");
            Console.WriteLine();

            DeliveryUtilities.PrintSectionTitle("Assignment Completed");
        }
    }
}
