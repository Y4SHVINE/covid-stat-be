using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.Statistics
{
    public class DiseaseSideEffectDto
    {
        public List<string> ChronicDiseases { get; set; }
        public List<string> SideEffects { get; set; }
    }
}
