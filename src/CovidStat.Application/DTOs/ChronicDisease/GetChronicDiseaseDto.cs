using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.ChronicDisease
{
    public class GetChronicDiseaseDto
    {
        public string Disease { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
