using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.Statistics;
using CovidStat.Application.Filters;

namespace CovidStat.Application.Interfaces
{
    public interface IStatisticsService : IDisposable
    {
        public List<GetStatisticsDto> GetStatistics();
    }
}