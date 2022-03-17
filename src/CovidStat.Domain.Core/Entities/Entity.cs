using System;
using System.ComponentModel.DataAnnotations;

namespace CovidStat.Domain.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
