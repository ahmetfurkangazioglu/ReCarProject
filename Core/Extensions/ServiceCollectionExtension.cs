using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{    
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
                ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }

    }
}