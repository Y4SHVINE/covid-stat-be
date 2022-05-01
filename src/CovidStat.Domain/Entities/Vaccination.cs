using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Entities;

namespace CovidStat.Domain.Entities
{
    public class Vaccination : Entity
    {
        [Required]
        public string NIC { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Vaccine { get; set; }
        [Required]
        public DateTime DateOfVaccination { get; set; }
        public string BatchNumber { get; set; }
        public string Remarks { get; set; }

        public virtual List<SideEffect> SideEffects { get; set; }
    }
}

