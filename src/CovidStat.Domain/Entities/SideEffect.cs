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
    public enum SideEffectName
    {
        Tiredness = 1,
        MusclePain = 2,
        Chills = 3,
        Nausea = 4,
        Fever = 5,
        Headache = 6
    }

    public class SideEffect : Entity
    {
        [Required]
        public string Detail { get; set; }

        [ForeignKey("VaccinationId")]
        public virtual Vaccination Vaccination { get; set; }
    }
}

