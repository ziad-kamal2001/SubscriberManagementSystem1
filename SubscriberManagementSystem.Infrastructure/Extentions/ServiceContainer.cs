using Microsoft.Extensions.DependencyInjection;
using SubscriberManagementSystem.Infrastructure.Services.Beneficiaries;
using SubscriberManagementSystem.Infrastructure.Services.BeneficiaryInformations;
using SubscriberManagementSystem.Infrastructure.Services.Constants;
using SubscriberManagementSystem.Infrastructure.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IBeneficiariesService, BeneficiariesService>();
            services.AddTransient<IBeneficiaryInformationsService, BeneficiaryInformationsService>();
            services.AddTransient<IConstantsService, ConstantsService>();
            services.AddTransient<IUsersService, UsersService>();
            //services.AddTransient<IClaimsService, ClaimsService>();
            //services.AddTransient<IClaimsService, ClaimsService>();

            return services;
        }
    }
}
