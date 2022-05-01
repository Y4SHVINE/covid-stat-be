using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.Statistics
{
    public class GetStatisticsDto
    {
        public string Vaccine { get; set; }
        public List<SideEffectStatics> SideEffectStatics { get; set; }
    }

    public class SideEffectStatics
    {
        public string SideEffect { get; set; }
        public int Count { get; set; }
    }
}
