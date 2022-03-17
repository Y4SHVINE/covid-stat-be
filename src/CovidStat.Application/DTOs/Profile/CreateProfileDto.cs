using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.Profile
{
    public class CreateProfileDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "NIC is required")]
        [StringLength(11, ErrorMessage = "Maximum length is 11")]
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
    }
}
