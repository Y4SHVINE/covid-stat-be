using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.Vaccination
{
    public class UpdateVaccinationDto
    {
        public string Location { get; set; }
        public string Vaccine { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public string BatchNumber { get; set; }
        public string Remarks { get; set; }
    }
}
