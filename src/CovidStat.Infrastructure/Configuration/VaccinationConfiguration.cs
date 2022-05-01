using System;
using CovidStat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidStat.Infrastructure.Configuration
{
    public class VaccinationConfiguration : IEntityTypeConfiguration<Vaccination>
    {
        public void Configure(EntityTypeBuilder<Vaccination> builder)
        {
            builder.Property(x => x.NIC).IsRequired().HasMaxLength(12);
        }
    }
}
