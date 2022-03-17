using System;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Interfaces;
using CovidStat.Domain.Entities;

namespace CovidStat.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
