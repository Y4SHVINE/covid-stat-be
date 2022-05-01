using System.Threading.Tasks;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using CovidStat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Repositories
{
    public class SideEffectRepository : Repository<SideEffect>, ISideEffectRepository
    {
        private readonly ApplicationDbContext _context;
        public SideEffectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

