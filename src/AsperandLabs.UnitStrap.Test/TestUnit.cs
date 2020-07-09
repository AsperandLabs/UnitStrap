using AsperandLabs.UnitStrap.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Test
{
    public class TestUnit: BaseUnitStrapper
    {
        public override string Namespace => GetType().Namespace;
        public override IServiceCollection RegisterDependencies(IServiceCollection services)
        {
            throw new System.NotImplementedException();
        }
    }
}