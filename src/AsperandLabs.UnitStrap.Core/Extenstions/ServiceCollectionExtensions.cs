using System;
using System.Collections.Generic;
using System.Linq;
using AsperandLabs.UnitStrap.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Extenstions
{
    public static class ServiceCollectionExtensions
    {
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