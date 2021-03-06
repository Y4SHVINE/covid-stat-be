using System.Linq;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Interfaces;
using CovidStat.Domain.Entities;

namespace CovidStat.Domain.Repositories
{
    public interface ITravelRepository : IRepository<Travel>
    {
        Task<Travel> GetByNic(string nic);
    }
}
