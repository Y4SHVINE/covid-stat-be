using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.SideEffect;

namespace CovidStat.Application.DTOs.Vaccination
{
    public class GetVaccinationDto
    {
        public Guid Id { get; set; }
        public string NIC { get; set; }
        public string Location { get; set; }
        public string Vaccine { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public string BatchNumber { get; set; }
        public string Remarks { get; set; }
        public List<GetSideEffectDto> SideEffects { get; set; }
    }
}
