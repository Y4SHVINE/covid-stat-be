using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.SideEffect;

namespace CovidStat.Application.DTOs.Vaccination
{
    public class CreateVaccinationDto
    {
        [Required(ErrorMessage = "NIC is required")]
        [StringLength(12, ErrorMessage = "Maximum length is 12")]
        public string NIC { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Vaccine is required")]
        public string Vaccine { get; set; }
        [Required(ErrorMessage = "DateOfVaccination is required")]
        public DateTime DateOfVaccination { get; set; }
        public string BatchNumber { get; set; }
        public string Remarks { get; set; }

        public List<CreateSideEffect> SideEffects { get; set; }
    }
}
