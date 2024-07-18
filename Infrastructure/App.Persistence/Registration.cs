using App.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnetion")));
        }
    }
}
