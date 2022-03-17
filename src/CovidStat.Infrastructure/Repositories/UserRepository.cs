using System.Threading.Tasks;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using CovidStat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(q => q.Email == email);
        }
    }
}
