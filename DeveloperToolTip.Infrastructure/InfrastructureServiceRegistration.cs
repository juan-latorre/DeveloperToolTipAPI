using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.InterfacesApp;
using DeveloperToolTip.Application.UseCases;
using DeveloperToolTip.Core.Interfaces;
using DeveloperToolTip.Infrastructure.Repositories;
using DeveloperToolTip.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperToolTip.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Repository Registration 
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IDeveloperRoleRepository, DeveloperRoleRepository>();
            services.AddScoped<ITopicCategoryRepository, TopicCategoryRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();    
            services.AddScoped<ITopicContentRepository, TopicContentRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenService>();

            return services;
        }
    }
}
