using System;

namespace SmartDeliveryManagementSystem.Models
{
    public partial class Shipment
    {
        public string TrackingCode { get; set; }
        public string ShipmentType { get; set; }
        public double Weight { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public double EstimatedCost { get; private set; }

        public Shipment(string trackingCode, string shipmentType, double weight, DeliveryAddress deliveryAddress)
        {
            TrackingCode = trackingCode;
            ShipmentType = shipmentType;
            Weight = weight;
            DeliveryAddress = deliveryAddress;
            EstimatedCost = CalculateEstimatedCost(shipmentType, weight);

            TrackingStatus = "Pending";

            TotalShipmentsCreated++;
        }

        private double CalculateEstimatedCost(string shipmentType, double weight)
        {
            double baseRate;

            switch (shipmentType)
            {
                case "Standard":
                    baseRate = 5.0;
                    break;
                case "Express":
                    baseRate = 10.0;
                    break;
                case "International":
                    baseRate = 20.0;
                    break;
                default:
                    baseRate = 7.0;
                    break;
            }

            return Math.Round(baseRate * weight, 2);
        }

        public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code   : {TrackingCode}");
            Console.WriteLine($"Shipment Type   : {ShipmentType}");
            Console.WriteLine($"Weight          : {Weight} KG");
            Console.WriteLine($"Address         : {DeliveryAddress}");
            Console.WriteLine($"Estimated Cost  : {EstimatedCost:C}");
            Console.WriteLine($"Tracking Status : {TrackingStatus}");
        }

        public Shipment CopyShipment()
        {
            return (Shipment)this.MemberwiseClone();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }

        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)this.MemberwiseClone();
            copy.DeliveryAddress = this.DeliveryAddress.Clone();
            return copy;
        }

        public static int TotalShipmentsCreated { get; private set; }

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        partial void OnTrackingStatusChanged(string newStatus);
    }
}
