using CRM.DataAccess;
using CRM.DataAccess.Interface;
using CRM.Facade.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CRM.Facade
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCrmFacade(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseFacade, CourseFacade>();

            
            return services;
        }
    }
}
