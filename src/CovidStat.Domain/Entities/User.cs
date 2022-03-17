using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CovidStat.Domain.Core.Entities;
using CovidStat.Domain.Entities;

namespace CovidStat.Domain.Entities
{
    public class User : Entity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string NIC { get; set; }
    }
}

