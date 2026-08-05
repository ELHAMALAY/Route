using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System
{
    public struct DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return $"{BuildingNumber}, {Street}, {City}";
        }
    }
}
