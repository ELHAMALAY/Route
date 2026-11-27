using GymManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Domain.Entities
{
    public class Trainer : GymUser
    {
        // Name, Email, PhoneNumber, Address, DateOfBirth , Gender
        public DateTime HireDate { get; set; }
        public string Speciality { get; set; }
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    }
}
