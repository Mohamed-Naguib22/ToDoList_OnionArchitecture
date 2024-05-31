using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application;
using OnionArchitecture.Application.Behaviours;
using OnionArchitecture.Application.Contract.IRepositories.ICommon;
using OnionArchitecture.Application.Dtos.AssignmentDtos;
using OnionArchitecture.Persistence.Context;
using OnionArchitecture.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence
{
    public static class ServiceExternsions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<OnionArchitectureContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
