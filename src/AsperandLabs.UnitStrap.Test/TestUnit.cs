using System;
using AsperandLabs.UnitStrap.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Test
{
    public class TestUnit: BaseUnitStrapper
    {
        public override IServiceCollection RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<EntryPoint>();

            return services;
        }
    }
}