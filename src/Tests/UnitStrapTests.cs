using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsperandLabs.UnitStrap.Core;
using Tests.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    [TestClass]
    public class UnitStrapTests
    {
        [TestMethod]
        public void InScopeUnusedRegisteredTypesAreDetected()
        {
            var unitstrapper = new UnitStrapperContainer("Tests");
            var serviceCollection = unitstrapper.AddScoped<ITestWriter, TestWriter>();
            var provider = serviceCollection.BuildServiceProvider();
            var analysis = unitstrapper.AnalyzeRegistrations(provider);
            Assert.IsTrue(analysis.InScopeUnusedRegisteredTypes.Count == 1);
        }
    }
}
