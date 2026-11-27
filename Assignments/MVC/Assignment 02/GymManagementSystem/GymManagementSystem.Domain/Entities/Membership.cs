using GymManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive => EndDate > DateTime.Now;
    }
}
