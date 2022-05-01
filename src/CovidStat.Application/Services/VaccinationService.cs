using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.SideEffect;
using CovidStat.Application.DTOs.Vaccination;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Extensions;
using CovidStat.Application.Filters;
using CovidStat.Application.Interfaces;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Application.Services
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IVaccinationRepository _vaccinationRepository;
        private readonly ISideEffectRepository _sideEffectRepository;

        private readonly IMapper _mapper;

        public VaccinationService(IMapper mapper, IVaccinationRepository vaccinationRepository, ISideEffectRepository effectRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _vaccinationRepository = vaccinationRepository ?? throw new ArgumentNullException(nameof(vaccinationRepository));
            _sideEffectRepository = effectRepository ?? throw new ArgumentNullException(nameof(effectRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _vaccinationRepository.Dispose();
        }

        #region Vaccination Methods

        public async Task<PaginatedList<GetVaccinationDto>> GetAllVaccinations(GetVaccinationsFilter filter)
        {
            filter ??= new GetVaccinationsFilter();
            var vaccinations = _vaccinationRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter.NIC), x => EF.Functions.Like(x.NIC, $"%{filter.NIC}%")).OrderBy(a=> a.DateOfVaccination);

            return await _mapper.ProjectTo<GetVaccinationDto>(vaccinations).ToPaginatedListAsync(filter.Page, filter.PageSize);
        }

        public List<GetVaccinationDto> GetVaccinationsById(string nic)
        {
            var vaccinations = _vaccinationRepository
                .GetAllByNic(nic);

            return _mapper.Map<List<GetVaccinationDto>>(vaccinations);
        }

        public async Task<GetVaccinationDto> CreateVaccination(CreateVaccinationDto vaccination)
        {
            var created = _vaccinationRepository.Create(_mapper.Map<Vaccination>(vaccination));
            await _vaccinationRepository.SaveChangesAsync();
            return _mapper.Map<GetVaccinationDto>(created);
        }

        public async Task<GetSideEffectDto> CreateSideEffect(Guid id, CreateSideEffect sideEffect)
        {
            SideEffect newSideEffect = _mapper.Map<SideEffect>(sideEffect);
            newSideEffect.Vaccination = await _vaccinationRepository.GetByIdWithTracking(id);

            var created = _sideEffectRepository.Create(newSideEffect);
            await _sideEffectRepository.SaveChangesAsync();
            return _mapper.Map<GetSideEffectDto>(created);
        }

        public async Task<GetVaccinationDto> UpdateVaccination(Guid id, UpdateVaccinationDto updatedVaccination)
        {
            var originalVaccination = await _vaccinationRepository.GetById(id);
            if (originalVaccination == null) return null;

            originalVaccination.Location = updatedVaccination.Location;
            originalVaccination.Vaccine = updatedVaccination.Vaccine;
            originalVaccination.DateOfVaccination = updatedVaccination.DateOfVaccination;
            originalVaccination.BatchNumber = updatedVaccination.BatchNumber;
            originalVaccination.Remarks = updatedVaccination.Remarks;

            _vaccinationRepository.Update(originalVaccination);
            await _vaccinationRepository.SaveChangesAsync();
            return _mapper.Map<GetVaccinationDto>(originalVaccination);
        }

        public async Task<GetSideEffectDto> UpdateSideEffect(Guid id, UpdateSideEffectDto updatedSideEffect)
        {
            var originalSideEffect = await _sideEffectRepository.GetById(id);
            if (originalSideEffect == null) return null;

            originalSideEffect.Detail = updatedSideEffect.Detail;

            _sideEffectRepository.Update(originalSideEffect);
            await _sideEffectRepository.SaveChangesAsync();
            return _mapper.Map<GetSideEffectDto>(originalSideEffect);
        }

        public async Task<bool> DeleteVaccination(string nic)
        {
            _vaccinationRepository.DeleteByNic(nic);
            return await _vaccinationRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSideEffect(Guid id)
        {
            await _sideEffectRepository.Delete(id);
            return await _sideEffectRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
