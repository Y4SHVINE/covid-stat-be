using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.ChronicDisease;

namespace CovidStat.Application.DTOs.Profile
{
    public class CreateProfileDto
    {
        [Required(ErrorMessage = "NIC is required")]
        [StringLength(12, ErrorMessage = "Maximum length is 12")]
        public string NIC { get; set; }
        [StringLength(200, ErrorMessage = "Maximum length is 200")]
        public string FullName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MartialStatus { get; set; }
        public string Location { get; set; }

        public List<CreateChronicDiseaseDto> ChronicDiseases { get; set; }
    }
}
