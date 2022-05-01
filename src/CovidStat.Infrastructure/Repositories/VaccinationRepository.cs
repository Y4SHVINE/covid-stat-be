using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using CovidStat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Repositories
{
    public class VaccinationRepository : Repository<Vaccination>, IVaccinationRepository
    {
        private readonly ApplicationDbContext _context;
        public VaccinationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Vaccination> GetAllByNic(string nic)
        {
            return _context.Vaccinations.Where(a => a.NIC == nic).OrderBy(a=>a.DateOfVaccination).ToList();
        }

        public async Task<Vaccination> GetByNic(string nic)
        {
            return await _context.Vaccinations.FirstOrDefaultAsync(a => a.NIC == nic);
        }

        public void DeleteByNic(string nic)
        {
            var entities = _context.Vaccinations.Where(a => a.NIC == nic);
            if (entities.Any()) DbSet.RemoveRange(entities);
        }
    }
}

