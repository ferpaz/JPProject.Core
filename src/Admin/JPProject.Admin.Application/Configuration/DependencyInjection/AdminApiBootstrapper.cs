using JPProject.Admin.Application.Configuration;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Configuration;
using JPProject.Domain.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AdminApiBootstrapper
    {
        /// <summary>
        /// Configure IdentityServer4 Administration services
        /// </summary>
        public static IJpProjectConfigurationBuilder ConfigureJpAdminServices<TUser>(this IServiceCollection services)
            where TUser : class, ISystemUser
        {
            // Domain Bus (Mediator)
            services.TryAddScoped<IMediatorHandler, InMemoryBus>();
            services.TryAddScoped<ISystemUser, TUser>();
            services
                .AddApplicationServices()
                .AddDomainEventsServices()
                .AddDomainCommandsServices();

            return new JpProjectBuilder(services);
        }

        /// <summary>
        /// Configure IdentityServer4 Administration services
        /// </summary>
        public static IJpProjectConfigurationBuilder ConfigureJpAdmin<TUser>(this IJpProjectConfigurationBuilder builder)
           where TUser : class, ISystemUser
        {
            // Domain Bus (Mediator)
            builder.Services.TryAddScoped<IMediatorHandler, InMemoryBus>();
            builder.Services.TryAddScoped<ISystemUser, TUser>();
            builder.Services
                .AddApplicationServices()
                .AddDomainEventsServices()
                .AddDomainCommandsServices();

            return builder;
        }
    }

}