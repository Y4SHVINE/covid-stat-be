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
    public class Travel : Entity
    {
        [Required]
        public string Country { get; set; }
        public DateTime DateOfDepature { get; set; }
        public DateTime DateOfArrival { get; set; }

        [ForeignKey("ProfileId")]
        public virtual UserProfile Profile { get; set; }
    }
}

