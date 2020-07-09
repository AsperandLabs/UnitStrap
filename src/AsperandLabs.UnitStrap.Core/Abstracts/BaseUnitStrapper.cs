using System;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public abstract class BaseUnitStrapper : DependencyAnalyzer
    {
        public abstract IServiceCollection RegisterDependencies(IServiceCollection services);
    }
}