using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core
{
    public class UnitStrapperContext
    {
        public IServiceCollection UnitRegistrations { get; set; }
        public string BaseNamespace { get; set; }
    }
}