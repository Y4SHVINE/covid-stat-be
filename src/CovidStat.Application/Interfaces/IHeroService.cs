using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.Hero;
using CovidStat.Application.Filters;

namespace CovidStat.Application.Interfaces
{
    public interface IHeroService : IDisposable
    {
        #region Hero Methods

        public Task<PaginatedList<GetHeroDto>> GetAllHeroes(GetHeroesFilter filter);

        public Task<GetHeroDto> GetHeroById(Guid id);

        public Task<GetHeroDto> CreateHero(CreateHeroDto hero);

        public Task<GetHeroDto> UpdateHero(Guid id, UpdateHeroDto updatedHero);

        public Task<bool> DeleteHero(Guid id);

        #endregion
    }
}