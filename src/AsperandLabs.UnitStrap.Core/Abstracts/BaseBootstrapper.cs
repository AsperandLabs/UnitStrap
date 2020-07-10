using System.Collections.Generic;
using AsperandLabs.UnitStrap.Core.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public abstract class BaseBootstrapper
    {
        private UnitContainer _units;
        internal IEnumerable<DependencyAnalyzer> RequestedUnits => (_units ?? (_units = RegisterUnits(new UnitContainer()))).Units;

        public abstract IServiceCollection RegisterDependencies(IServiceCollection services);
        public abstract UnitContainer RegisterUnits(UnitContainer units);

        internal BootstrapperInfo Info(IServiceCollection services) => new BootstrapperInfo
        {
            BootstrapperRegistrations = RegisterDependencies(services),
            Units = RequestedUnits
        };

        internal BootstrapperInfo Info() => Info(new ServiceCollection());
    }
}