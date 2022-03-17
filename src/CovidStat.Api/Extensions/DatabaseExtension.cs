using System;
using CovidStat.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CovidStat.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
