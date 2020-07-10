using System;
using System.Linq;
using AsperandLabs.UnitStrap.Core.Abstracts;
using AsperandLabs.UnitStrap.Core.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Validation
{
    public class BootstrapperBuilder<T> where T : BaseBootstrapper, new()
    {
        private readonly T _bootstrapper;
        public BootstrapperBuilder()
        {
            _bootstrapper = new T();
        }

        public IServiceProvider BuildServiceProvider() => Merge().BuildServiceProvider();

        public IServiceProvider BuildServiceProvider(IServiceCollection services) => Merge(services).BuildServiceProvider();
        public IServiceCollection Merge() => Merge(new ServiceCollection());
        public IServiceCollection Merge(IServiceCollection services)
        {
            _bootstrapper.RegisterDependencies(services);
            RegisterUnitDependencies(services);
            return services;
        }

        private void RegisterUnitDependencies(IServiceCollection services)
        {
            foreach (var unit in _bootstrapper.RequestedUnits)
                unit.Register(services);
        }

        public ValidationResults Validate()
        {
            return default;
        }
    }
}