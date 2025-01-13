using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.UseCases.AuthUseCases;
using DeveloperToolTip.Application.UseCases.DeveloperUseCases;
using DeveloperToolTip.Application.UseCases.RoleUseCases;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperToolTip.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Developer User Cases
            services.AddScoped<IGetAllDevelopersUseCase, GetAllDevelopersUseCase>();
            services.AddScoped<ICreateDeveloperUseCase, CreateDeveloperUseCase>();
            services.AddScoped<IDeleteDeveloperUseCase, DeleteDeveloperUseCase>();
            services.AddScoped<IGetDeveloperByIdUseCase, GetDeveloperByIdUseCase>();
            services.AddScoped<IUpdateDeveloperUseCase, UpdateDeveloperUseCase>();

            // Role User Cases
            services.AddScoped<IGetRoleDeveloperByIdUseCase, GetRoleDeveloperByIdUseCase>();
            services.AddScoped<IGetAllRolesDeveloperUseCase, GetAllRolesDeveloperUseCase>();
            services.AddScoped<ICreateRoleDeveloperUseCase, CreateRoleDeveloperUseCase>();
            services.AddScoped<IDeleteRoleDevelperUseCase, DeleteRoleDevelperUseCase>();
            services.AddScoped<IUpdateRoleDeveloperUseCase, UpdateRoleDeveloperUseCase>();

            //Topic Category Use Cases
            services.AddScoped<IGetAllTopicCategoryUseCase, GetAllTopicCategoryUseCase>();
            services.AddScoped<IGetTopicCategoryByIdUseCase, GetTopicCategoryByIdUseCase>();
            services.AddScoped<ICreateTopicCategoryUseCase, CreateTopicCategoryUseCase>();
            services.AddScoped<IUpdateTopicCategoryUseCase, UpdateTopicCategoryUseCase>();
            services.AddScoped<IDeleteTopicCategoryUseCase, DeleteTopicCategoryUseCase>();


            //Topic Use Cases
            services.AddScoped<IGetAllTopicUseCase, GetAllTopicUseCase>();
            services.AddScoped<IGetTopicByIdUseCase, GetTopicByIdUseCase>();
            services.AddScoped<ICreateTopicUseCase, CreateTopicUseCase>();
            services.AddScoped<IDeleteTopicUseCase, DeleteTopicUseCase>();
            services.AddScoped<IUpdateTopicUseCase, UpdateTopicUseCase>();

            //Topic Content Use Cases
            services.AddScoped<IGetAllTopicContentsUseCase,GetAllTopicContentsUseCase>();
            services.AddScoped<IGetAllTopicContentsWithRelationsUseCase, GetAllTopicContentsWithRelationsUseCase>();
            services.AddScoped<IGetTopicContentByIdUseCase, GetTopicContentByIdUseCase>();
            services.AddScoped<ICreateTopicContentUseCase, CreateTopicContentUseCase>();
            services.AddScoped<IUpdateTopicContentUseCase, UpdateTopicContentUseCase>();
            services.AddScoped<IDeleteTopicContentUseCase, DeleteTopicContentUseCase>();

            //Authentication Use Cases
            services.AddScoped<IAuthenticateDeveloperUseCase, AuthenticateDeveloperUseCase>();

            return services;
        }
    }
}
