using GymManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GymManagementSystem.Domain.Common
{
    public class GymUser : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; } = null!;
    }
}
