using System;
using CovidStat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidStat.Infrastructure.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(x => x.NIC).IsRequired().HasMaxLength(11);
            builder.HasIndex(x => x.NIC).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
