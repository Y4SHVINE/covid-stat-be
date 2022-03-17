using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using CovidStat.Infrastructure.Context;

namespace CovidStat.Infrastructure.Repositories
{
    public class HeroRepository : Repository<Hero>, IHeroRepository
    {
        public HeroRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}

