using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CovidStat.Application.DTOs.ChronicDisease;
using CovidStat.Application.DTOs.Hero;
using CovidStat.Application.DTOs.Profile;
using CovidStat.Application.DTOs.SideEffect;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.DTOs.User;
using CovidStat.Application.DTOs.Vaccination;
using CovidStat.Domain.Auth;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Entities.Enums;
using Profile = AutoMapper.Profile;

namespace CovidStat.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Hero Map
            CreateMap<Hero, GetHeroDto>().ReverseMap();
            CreateMap<CreateHeroDto, Hero>();
            CreateMap<UpdateHeroDto, Hero>();

            // Profile Travel Map
            CreateMap<Travel, GetTravelDto>().ReverseMap();
            CreateMap<CreateTravelDto, Travel>();
            CreateMap<UpdateTravelDto, Travel>();

            // Profile Chronic Disease Map
            CreateMap<ChronicDisease, GetChronicDiseaseDto>().ReverseMap();
            CreateMap<CreateChronicDiseaseDto, ChronicDisease>();

            // Profile Map
            CreateMap<UserProfile, GetProfileDto>().ReverseMap();
            CreateMap<CreateProfileDto, UserProfile>();
            CreateMap<UpdateProfileDto, UserProfile>();

            // Vaccination SideEffcet Map
            CreateMap<SideEffect, GetSideEffectDto>().ReverseMap();
            CreateMap<CreateSideEffect, SideEffect>();

            // Vaccination Map
            CreateMap<Vaccination, GetVaccinationDto>().ReverseMap();
            CreateMap<CreateVaccinationDto, Vaccination>();
            CreateMap<UpdateVaccinationDto, Vaccination>();

            // User Map
            CreateMap<User, GetUserDto>().ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(x => x.Role == Roles.Admin)).ReverseMap();
            CreateMap<CreateUserDto, User>().ForMember(dest => dest.Role,
                opt => opt.MapFrom(org => org.IsAdmin ? Roles.Admin : Roles.User));
            CreateMap<UpdatePasswordDto, User>();
        }
    }
}
