using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentAPI.Application.Queries.Student;

namespace StudentAPI.Application
{
    public static class DIConfig
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(List.Handler).Assembly);

            return services;
        }
    }
}

