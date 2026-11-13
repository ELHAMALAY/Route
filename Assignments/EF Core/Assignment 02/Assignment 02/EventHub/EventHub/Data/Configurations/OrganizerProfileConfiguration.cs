using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub.Data.Configurations
{
    public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder
                .HasOne(p => p.Organizer)
                .WithOne(o => o.OrganizerProfile)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                .IsRequired();
        }
    }
}
