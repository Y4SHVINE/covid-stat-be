using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.SideEffect;
using CovidStat.Application.DTOs.Statistics;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Extensions;
using CovidStat.Application.Filters;
using CovidStat.Application.Helpers;
using CovidStat.Application.Interfaces;
using CovidStat.Domain.Entities;
using CovidStat.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Application.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IVaccinationRepository _vaccinationRepository;
        private readonly ISideEffectRepository _sideEffectRepository;

        private readonly IMapper _mapper;

        public StatisticsService(IMapper mapper, IProfileRepository profileRepository, IVaccinationRepository vaccinationRepository,
            ISideEffectRepository effectRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
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
            if (disposing) _sideEffectRepository.Dispose();
        }

        #region Statistics Methods


        public List<GetStatisticsDto> GetStatistics()
        {
            List<GetStatisticsDto> statisticsList = new List<GetStatisticsDto>();
            List<SideEffectStatics> sideEffectStaticsList = ((SideEffectName[])Enum.GetValues(typeof(SideEffectName)))
                .Select(sideEffectName => new SideEffectStatics()
                {
                    SideEffect = Regex.Replace(sideEffectName.ToString(), "(\\B[A-Z])", " $1"),
                    Count = 0
                }).ToList();

            var vaccineGroups = _vaccinationRepository.GetAll().GroupBy(a => a.Vaccine).Select(b => new
            {
                Vaccine = b.Key,
                SideEffects = b.ToList().SelectMany(a => a.SideEffects).ToList()
            });

            foreach (var vaccineGroup in vaccineGroups)
            {
                var sideEffectGroup = vaccineGroup.SideEffects.GroupBy(s => s.Detail)
                    .Select(x => new SideEffectStatics()
                    {
                        SideEffect = x.Key,
                        Count = x.Count()
                    }).ToList();

                GetStatisticsDto statisticsDto = new GetStatisticsDto()
                {
                    Vaccine = vaccineGroup.Vaccine,
                    SideEffectStatics = sideEffectStaticsList
                        .Concat(sideEffectGroup)
                        .GroupBy(x => new { x.SideEffect })
                        .Select(g => new SideEffectStatics()
                        {
                            SideEffect = g.Key.SideEffect,
                            Count = g.Sum(x => x.Count)
                        }).ToList()
                };

                statisticsList.Add(statisticsDto);
            }

            return statisticsList;
        }


        #endregion
    }
}
