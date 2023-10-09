



using App.Applcation.Interfaces.IServices;
using App.Applcation.Services.Pagination;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Extensions
{
    public static class IServicesCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IPaginationService<,>),typeof(PaginationService<,>));

        }
    }
}
