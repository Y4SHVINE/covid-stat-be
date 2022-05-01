using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.DTOs.SideEffect
{
    public class GetSideEffectDto
    {
        public Guid Id { get; set; }
        public string Detail { get; set; }
    }
}
