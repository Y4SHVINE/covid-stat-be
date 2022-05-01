using System;
using System.Linq;
using System.Threading.Tasks;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using CovidStat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Repositories
{
    public class ProfileRepository : Repository<UserProfile>, IProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UserProfile> GetAllWithSubTables()
        {
            return _context.UserProfiles
                .Include(c => c.ChronicDiseases)
                .Include(t => t.Travels)
                .AsNoTracking();
        }

        public Task<UserProfile> GetByNic(string nic)
        {
            return _context.UserProfiles
                .Include(c => c.ChronicDiseases)
                .Include(t => t.Travels)
                .FirstOrDefaultAsync(a => a.NIC == nic);
        }

        public void DeleteByNic(string nic)
        {
            var entity = _context.UserProfiles.FirstOrDefault(a => a.NIC == nic);
            if (entity != null) DbSet.Remove(entity);
        }
    }
}

