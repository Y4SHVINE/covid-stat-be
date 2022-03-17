using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using ISession = CovidStat.Domain.Auth.Interfaces.ISession;

namespace CovidStat.Application.Auth
{
    public class Session : ISession
    {
        public Guid UserId { get; private set; }

        public DateTime Now => DateTime.Now;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

            if (nameIdentifier != null)
            {
                UserId = new Guid(nameIdentifier.Value);
            }
        }

    }
}
