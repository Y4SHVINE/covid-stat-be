using System;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.SideEffect;
using CovidStat.Application.DTOs.Statistics;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Filters;
using CovidStat.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidStat.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }


        /// <summary>
        /// Returns all statistics in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Vaccine")]
        [Authorize]
        public async Task<ActionResult<PaginatedList<GetStatisticsDto>>> GetStatisticses()
        {
            return Ok(_statisticsService.GetStatistics());
        }
    }
}
