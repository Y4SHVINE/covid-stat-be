using System;
using CovidStat.Domain.Entities.Enums;

namespace CovidStat.Application.Filters
{
    public class GetProfilesFilter : PaginationInfoFilter
    {
        public string NIC { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
    }
}
