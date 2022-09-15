using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QWSandbox.CQRS.Web.Services;
using QWSandbox.CQRS.Web.Services.Default;
using QWSandbox.CQRS.Web.Infrastructure.Mediator.Behaviours;

namespace QWSandbox.CQRS.Web.Infrastructure.DI
{
    public static class DIExtensions
    {
        public static void AddQWServices(this IServiceCollection services)
        {
            Assembly currentAssembly = Assembly.GetAssembly(typeof(DIExtensions));
            
            services.AddAutoMapper(currentAssembly);
            services.AddMediatR(currentAssembly);
            services.AddValidatorsFromAssembly(currentAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            // Вопрос именования нужно сразу обсудить. UserService а не UsersService
            services.AddTransient<IUserDBService, UserDBService>();
            services.AddTransient<IUserCacheService, UserCacheService>();
        }
    }
}
