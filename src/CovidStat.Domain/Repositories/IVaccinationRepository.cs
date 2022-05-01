using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Interfaces;
using CovidStat.Domain.Entities;

namespace CovidStat.Domain.Repositories
{
    public interface IVaccinationRepository : IRepository<Vaccination>
    {
        List<Vaccination> GetAllByNic(string nic);
        Task<Vaccination> GetByNic(string nic);
        void DeleteByNic(string nic);
    }
}
