using System;

namespace CovidStat.Application.DTOs.User
{
    public class GetUserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public string NIC { get; set; }
    }
}
