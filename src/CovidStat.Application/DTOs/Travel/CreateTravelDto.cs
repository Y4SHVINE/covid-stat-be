using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.Travel
{
    public class CreateTravelDto
    {
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        public DateTime DateOfDepature { get; set; }
        public DateTime DateOfArrival { get; set; }
    }
}
