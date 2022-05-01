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
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<SideEffect> SideEffects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChronicDiseaseConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new VaccinationConfiguration());

            modelBuilder.Entity<UserProfile>()
                .HasMany(a => a.ChronicDiseases)
                .WithOne(x => x.Profile)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserProfile>()
                .HasMany(a => a.Travels)
                .WithOne(x => x.Profile)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Vaccination>()
            //    .HasMany(a => a.SideEffects)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
