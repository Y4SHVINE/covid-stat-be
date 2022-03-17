using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.DTOs.Auth;
using CovidStat.Application.DTOs.User;
using CovidStat.Domain.Entities;

namespace CovidStat.Application.Interfaces
{
    public interface IAuthService
    {
        JwtDto GenerateToken(User user);
    }
}
