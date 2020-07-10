using AsperandLabs.UnitStrap.Core;
using AsperandLabs.UnitStrap.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Test
{
    public class TestBootstrapper: BaseBootstrapper
    {
        public override IServiceCollection RegisterDependencies(IServiceCollection services)
        {
            //Root dependencies go here!
            
            //not units though, this doesnt work...
            //services.AddUnit<TestUnit>();

            return services;
        }

        public override UnitContainer RegisterUnits(UnitContainer units)
        {
            units.AddUnit<TestUnit>();
            
            return units;
        }
    }
}