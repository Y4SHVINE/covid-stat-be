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
    public class ChronicDisease : Entity
    {
        [Required]
        public string Disease { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProfileId")]
        public virtual UserProfile Profile { get; set; }
    }
}

