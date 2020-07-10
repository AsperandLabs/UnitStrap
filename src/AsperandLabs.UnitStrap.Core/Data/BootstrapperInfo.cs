using System.Collections.Generic;
using AsperandLabs.UnitStrap.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Data
{
    internal class BootstrapperInfo
    {
        internal IEnumerable<DependencyAnalyzer> Units { get; set; }
        internal IServiceCollection BootstrapperRegistrations { get; set; }
    }
}