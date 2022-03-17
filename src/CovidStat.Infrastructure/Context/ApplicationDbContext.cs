using CovidStat.Domain.Entities;
using CovidStat.Infrastructure.Configuration;
using CovidStat.Domain.Entities;
using CovidStat.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<ChronicDisease> ChronicDiseases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChronicDiseaseConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
        }
    }
}
