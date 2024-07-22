using App.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapper
{
    public static class Registration
    {
        public static void AppCustomMapper(this IServiceCollection service)
        {
            service.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
