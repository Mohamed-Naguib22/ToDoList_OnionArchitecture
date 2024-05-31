using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Behaviours;
using OnionArchitecture.Application.Contract.IFeatures.IAssignment;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using OnionArchitecture.Application.Features_Imp.Assignment_Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IAssignmentService, AssignmentService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IValidator<AddAssignmentDto>, AddAssignmentValidator>();
        }
    }
}
