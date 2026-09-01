using Microsoft.Extensions.DependencyInjection;
using SubscriberManagementSystem.Infrastructure.Services.Beneficiaries;
using SubscriberManagementSystem.Infrastructure.Services.BeneficiaryInformations;
using SubscriberManagementSystem.Infrastructure.Services.Childrens;
using SubscriberManagementSystem.Infrastructure.Services.Constants;
using SubscriberManagementSystem.Infrastructure.Services.Pages;
using SubscriberManagementSystem.Infrastructure.Services.UserPermissions;
using SubscriberManagementSystem.Infrastructure.Services.Users;
using SubscriberManagementSystem.Infrastructure.Services.UserTypes;
using SubscriberManagementSystem.Infrastructure.Services.Wives;

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
            services.AddTransient<IWivesService, WivesService>();
            services.AddTransient<IChildrensService, ChildrensService>();
            services.AddTransient<IPagesService, PagesService>();
            services.AddTransient<IUserTypesService, UserTypesService>();
            services.AddTransient<IUserPermissionsService, UserPermissionsService>();
            return services;
        }
    }
}