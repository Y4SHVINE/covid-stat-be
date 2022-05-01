using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.Profile;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Extensions;
using CovidStat.Application.Filters;
using CovidStat.Application.Interfaces;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ITravelRepository _travelRepository;

        private readonly IMapper _mapper;

        public ProfileService(IMapper mapper, IProfileRepository profileRepository, ITravelRepository travelRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
            _travelRepository = travelRepository ?? throw new ArgumentNullException(nameof(travelRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _profileRepository.Dispose();
        }

        #region Profile Methods

        public async Task<PaginatedList<GetProfileDto>> GetAllProfiles(GetProfilesFilter filter)
        {
            filter ??= new GetProfilesFilter();
            var profiles = _profileRepository
                .GetAllWithSubTables()
                .WhereIf(!string.IsNullOrEmpty(filter.NIC), x => EF.Functions.Like(x.NIC, $"%{filter.NIC}%"));

            return await _mapper.ProjectTo<GetProfileDto>(profiles).ToPaginatedListAsync(filter.Page, filter.PageSize);
        }

        public async Task<GetProfileDto> GetProfileById(string nic)
        {
            return _mapper.Map<GetProfileDto>(await _profileRepository.GetByNic(nic));
        }

        public async Task<GetProfileDto> CreateProfile(CreateProfileDto profile)
        {
            var created = _profileRepository.Create(_mapper.Map<UserProfile>(profile));
            await _profileRepository.SaveChangesAsync();
            return _mapper.Map<GetProfileDto>(created);
        }

        public async Task<GetTravelDto> CreateTravelProfile(string nic, CreateTravelDto travel)
        {
            Travel newTravel = _mapper.Map<Travel>(travel);
            newTravel.Profile = await _profileRepository.GetByNic(nic);

            var created = _travelRepository.Create(newTravel);
            await _travelRepository.SaveChangesAsync();
            return _mapper.Map<GetTravelDto>(created);
        }

        public async Task<GetProfileDto> UpdateProfile(string nic, UpdateProfileDto updatedProfile)
        {
            var originalProfile = await _profileRepository.GetByNic(nic);
            if (originalProfile == null) return null;

            originalProfile.FullName = updatedProfile.FullName;
            originalProfile.DOB = updatedProfile.DOB;
            originalProfile.Gender = updatedProfile.Gender;
            originalProfile.MartialStatus = updatedProfile.MartialStatus;
            originalProfile.Location = updatedProfile.Location;
            originalProfile.PhoneNumber = updatedProfile.PhoneNumber;

            if (updatedProfile.ChronicDiseases != null && updatedProfile.ChronicDiseases.Count > 0)
            {
                originalProfile.ChronicDiseases = updatedProfile.ChronicDiseases.Select(x => new ChronicDisease()
                {
                    Disease = x.Disease
                }).ToList();
            }

            _profileRepository.Update(originalProfile);
            await _profileRepository.SaveChangesAsync();
            return _mapper.Map<GetProfileDto>(originalProfile);
        }

        public async Task<GetTravelDto> UpdateTravel(Guid id, UpdateTravelDto updatedTravel)
        {
            var originalTravel = await _travelRepository.GetById(id);
            if (originalTravel == null) return null;

            originalTravel.Country = updatedTravel.Country;
            originalTravel.DateOfArrival = updatedTravel.DateOfArrival;
            originalTravel.DateOfDepature = updatedTravel.DateOfDepature;

            _travelRepository.Update(originalTravel);
            await _travelRepository.SaveChangesAsync();
            return _mapper.Map<GetTravelDto>(originalTravel);
        }

        public async Task<bool> DeleteTravel(Guid id)
        {
            await _travelRepository.Delete(id);
            return await _travelRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProfile(string nic)
        {
            _profileRepository.DeleteByNic(nic);
            return await _profileRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
