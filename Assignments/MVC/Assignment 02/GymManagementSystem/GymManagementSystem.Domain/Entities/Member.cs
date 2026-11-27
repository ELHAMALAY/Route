using GymManagementSystem.Domain.Common;
using GymManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Domain.Entities
{
    public class Member : GymUser
    {
        // Name, Email, PhoneNumber, Address, DateOfBirth , Photo
        public DateTime JoinDate { get; set; }
        public string? Photo { get; set; }
        public ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();
    }
}
