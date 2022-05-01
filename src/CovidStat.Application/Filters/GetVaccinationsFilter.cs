using System;
using CovidStat.Domain.Entities.Enums;

namespace CovidStat.Application.Filters
{
    public class GetVaccinationsFilter : PaginationInfoFilter
    {
        public string NIC { get; set; }
        public string Location { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public string BatchNumber { get; set; }
        public string Remarks { get; set; }
    }
}
