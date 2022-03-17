using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.Profile;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Filters;

namespace CovidStat.Application.Interfaces
{
    public interface IProfileService : IDisposable
    {
        public Task<PaginatedList<GetProfileDto>> GetAllProfiles(GetProfilesFilter filter);
        public Task<GetProfileDto> GetProfileById(string nic);
        public Task<GetProfileDto> CreateProfile(CreateProfileDto profile);
        public Task<GetTravelDto> CreateTravelProfile(string nic, CreateTravelDto travel);
        public Task<GetProfileDto> UpdateProfile(string nic, UpdateProfileDto updatedProfile);
        public Task<GetTravelDto> UpdateTravel(Guid id, UpdateTravelDto updatedTravel);
        public Task<bool> DeleteTravel(Guid id);
        public Task<bool> DeleteProfile(string nic);
    }
}