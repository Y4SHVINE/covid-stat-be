using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Entities;

namespace CovidStat.Domain.Entities
{
    public class UserProfile : Entity
    {
        [Required]
        public string NIC { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
        public string Location { get; set; }

        public virtual List<ChronicDisease> ChronicDiseases { get; set; }
        public virtual List<Travel> Travels { get; set; }
    }
}

