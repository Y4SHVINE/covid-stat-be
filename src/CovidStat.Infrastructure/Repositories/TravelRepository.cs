using System.Threading.Tasks;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using CovidStat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Repositories
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {
        private readonly ApplicationDbContext _context;
        public TravelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Travel> GetByNic(string nic)
        {
            return _context.Travels.FirstOrDefaultAsync(a => a.Profile.NIC == nic);
        }
    }
}

