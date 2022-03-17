using System.Linq;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Interfaces;
using CovidStat.Domain.Entities;

namespace CovidStat.Domain.Repositories
{
    public interface IProfileRepository : IRepository<UserProfile>
    {
        Task<UserProfile> GetByNic(string nic);
        void DeleteByNic(string nic);
    }
}
