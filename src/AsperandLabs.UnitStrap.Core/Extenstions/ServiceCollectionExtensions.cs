using System;
using System.Collections.Generic;
using System.Linq;
using AsperandLabs.UnitStrap.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitStrapper(this IServiceCollection services)
        {
            services.AddSingleton(services);
            services.AddTransient<ContainerValidator>();
            
            return services;
        }

        public static IServiceCollection AddUnit<T>(this IServiceCollection services, bool registerAnalyzer = false)
            where T : BaseUnitStrapper, new()
        {
            return new T().RegisterDependencies(services, registerAnalyzer);
        }


        public static IServiceCollection AddUnit<T, TT>(this IServiceCollection services, TT configuration, bool registerAnalyzer = false)
            where T : BaseUnitStrapper<TT>, new()
        {
            return new T().RegisterDependencies(services, configuration, registerAnalyzer);
        }

        internal static IEnumerable<Type> MapImplementationTypes(this IServiceCollection services, IEnumerable<Type> types)
        {
            return types.Select(t =>
            {
                var service = services.First(s => s.ServiceType == t);
                if (service.ImplementationType == null)
                    return t;
                return service.ImplementationType;
            });
        }
    }
}