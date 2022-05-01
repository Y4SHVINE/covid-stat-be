using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.SideEffect;
using CovidStat.Application.DTOs.Vaccination;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Filters;

namespace CovidStat.Application.Interfaces
{
    public interface IVaccinationService : IDisposable
    {
        public Task<PaginatedList<GetVaccinationDto>> GetAllVaccinations(GetVaccinationsFilter filter);
        public List<GetVaccinationDto> GetVaccinationsById(string nic);
        public Task<GetVaccinationDto> CreateVaccination(CreateVaccinationDto vaccination);
        public Task<GetSideEffectDto> CreateSideEffect(Guid id, CreateSideEffect sideEffect);
        public Task<GetVaccinationDto> UpdateVaccination(Guid id, UpdateVaccinationDto updatedVaccination);
        public Task<GetSideEffectDto> UpdateSideEffect(Guid id, UpdateSideEffectDto updatedSideEffect);
        public Task<bool> DeleteVaccination(string nic);
        public Task<bool> DeleteSideEffect(Guid id);
    }
}