using System;

namespace SmartDeliveryManagementSystem.Models
{
    public class DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        public DeliveryAddress(string city, string street = "Unknown Street", string country = "Egypt")
        {
            City = city;
            Street = street;
            Country = country;
        }

        // Used by DeepCopy() to build a brand new, independent address object.
        public DeliveryAddress Clone()
        {
            return new DeliveryAddress(City, Street, Country);
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {Country}";
        }
    }
}
