using JPProject.Domain.Core.Interfaces;
using JPProject.Sso.AspNetIdentity.Models.Identity;
using JPProject.Sso.AspNetIdentity.Services;
using JPProject.Sso.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JPProject.Sso.AspNetIdentity.Configuration
{
    public static class IdentityConfiguration
    {
        public static IJpProjectConfigurationBuilder ConfigureIdentity<TUser, TRole, TKey, TRoleFactory, TUserFactory>(this IJpProjectConfigurationBuilder services)
            where TUser : IdentityUser<TKey>, IDomainUser
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
            where TRoleFactory : class, IRoleFactory<TRole>
            where TUserFactory : class, IIdentityFactory<TUser>
        {
            services.Services.AddScoped<IUserService, UserService<TUser, TRole, TKey>>();
            services.Services.AddScoped<IRoleService, RoleService<TRole, TKey>>();
            services.Services.AddScoped<IIdentityFactory<TUser>, TUserFactory>();
            services.Services.AddScoped<IRoleFactory<TRole>, TRoleFactory>();

            return services;
        }

        public static IJpProjectConfigurationBuilder AddDefaultAspNetIdentityServices(this IJpProjectConfigurationBuilder services)
        {
            // Infra - Identity Services
            services.Services.AddScoped<IUserService, UserService<UserIdentity, RoleIdentity, string>>();
            services.Services.AddScoped<IRoleService, RoleService<RoleIdentity, string>>();
            services.Services.AddScoped<IIdentityFactory<UserIdentity>, IdentityFactory>();
            services.Services.AddScoped<IRoleFactory<RoleIdentity>, IdentityFactory>();

            return services;
        }

    }
}
