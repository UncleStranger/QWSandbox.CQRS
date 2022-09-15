using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using QWSandbox.CQRS.Web.Services;

namespace QWSandbox.CQRS.Web.Infrastructure.DI
{
    public static class DIExtensions
    {
        public static void AddQWServices(this IServiceCollection services)
        {
            Assembly currentAssembly = Assembly.GetAssembly(typeof(DIExtensions));
            
            services.AddAutoMapper(currentAssembly);
            services.AddMediatR(currentAssembly);

            // Вопрос именования нужно сразу обсудить. UserService а не UsersService
            services.AddTransient<IUserService, IUserService>();
        }
    }
}
