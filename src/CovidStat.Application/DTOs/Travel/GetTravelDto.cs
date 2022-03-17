using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.Travel
{
    public class GetTravelDto
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public DateTime DateOfDepature { get; set; }
        public DateTime DateOfArrival { get; set; }
    }
}
