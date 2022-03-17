using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidStat.Infrastructure.Configuration
{
    public class ChronicDiseaseConfiguration : IEntityTypeConfiguration<ChronicDisease>
    {
        public void Configure(EntityTypeBuilder<ChronicDisease> builder)
        {
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("now()");
        }
    }
}
