using App.Applcation.Interfaces.IRepositories;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Common.Interfaces;
using App.Infrastrcuture.Middleware;
using App.Infrastrcuture.Persistence.Context;
using App.Infrastrcuture.Persistence.Repositories;
using App.Infrastrcuture.Services.Event;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastrcuture.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.
                AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("conn"))
            );
            services.AddRepositories();
           
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
