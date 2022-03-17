using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Domain.Entities;

namespace CovidStat.Application.DTOs.Profile
{
    public class GetProfileDto
    {
        public Guid Id { get; set; }
        public string NIC { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }

        //public List<ChronicDisease> ChronicDiseases { get; set; }
        public List<GetTravelDto> Travels { get; set; }
    }
}
