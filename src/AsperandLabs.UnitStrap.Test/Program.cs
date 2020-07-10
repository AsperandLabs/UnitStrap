using AsperandLabs.UnitStrap.Core.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new BootstrapperBuilder<TestBootstrapper>();
            var serviceProvider = builder.BuildServiceProvider();
            serviceProvider.GetService<EntryPoint>().Run();
        }
    }
}