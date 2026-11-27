using GymManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Domain.Entities
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();
    }
}
