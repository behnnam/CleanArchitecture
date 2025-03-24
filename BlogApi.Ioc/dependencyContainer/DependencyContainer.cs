using BlogApi.Application.Services.implementation;
using BlogApi.Application.Services.Interfaces;
using BlogApi.Domain.Interfaces;
using BlogApi.InfData.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.InfIoc.dependencyContainer
{
    public static class DependencyContainer
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IGetPostRepository, GetPostRepository>();



            services.AddScoped<IGetPostService, GetPostService>();


        }
    }
}
