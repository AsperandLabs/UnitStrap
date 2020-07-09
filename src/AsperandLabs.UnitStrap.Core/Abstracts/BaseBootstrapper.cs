using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public abstract class BaseBootstrapper
    {
        private readonly IServiceCollection _services;
        private UnitContainer _units;

        internal IEnumerable<DependencyAnalyzer> RequestedUnits => (_units ?? (_units = RegisterUnits(new UnitContainer()))).Units;

        public BaseBootstrapper(IServiceCollection services)
        {
            _services = services;
        }
        
        public abstract IServiceCollection RegisterDependencies(IServiceCollection services);
        public abstract UnitContainer RegisterUnits(UnitContainer units);

        public IServiceCollection Build()
        {
            foreach (var item in RequestedUnits)
            {
                item.Register(_services);
            }
            
            return _services;
        }

        internal BootstrapperContext CreateContext()
        {
            return new BootstrapperContext
            {
                BootstrapperRegistrations = RegisterDependencies(_services),
                Units = RequestedUnits
            };
        }
    }
}