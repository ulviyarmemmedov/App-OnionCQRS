using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence
{
    public static class Registration
    {
        public static void Registration(this IServiceColletion services,IConfiguration config)
        {
            services.AddDbContext<MyDbContext>(opt=>opt.Use)
        }
    }
}
