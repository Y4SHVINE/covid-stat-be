using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.ChronicDisease;

namespace CovidStat.Application.DTOs.Profile
{
    public class UpdateProfileDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
        public string Location { get; set; }
        public List<CreateChronicDiseaseDto> ChronicDiseases { get; set; }
    }
}
