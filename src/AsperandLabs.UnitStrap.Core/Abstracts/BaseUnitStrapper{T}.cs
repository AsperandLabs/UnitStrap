using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public abstract class BaseUnitStrapper<T> : DependencyAnalyzer
    {
        public abstract IServiceCollection RegisterDependencies(IServiceCollection services, T config);
    }
}