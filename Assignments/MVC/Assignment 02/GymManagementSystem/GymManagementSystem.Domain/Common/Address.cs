using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Domain.Common
{
    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string BuildingNumber { get; set; } = null!;
    }
}
