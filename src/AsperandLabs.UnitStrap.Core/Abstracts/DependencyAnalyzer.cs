using System;
using AsperandLabs.UnitStrap.Core.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public abstract class DependencyAnalyzer
    {
        private Func<IServiceCollection, IServiceCollection> _registerExpression;
        public abstract string Namespace { get; }

        internal void SetupRegisterCallback(Func<IServiceCollection, IServiceCollection> registerExpression)
        {
            if (_registerExpression != null)
                ExceptionHelper.ThrowInvalidOperation("This was already setup... someone is doing something naughty...");

            _registerExpression = registerExpression;
        }
        
        internal IServiceCollection Register(IServiceCollection services) => _registerExpression(services);
        internal UnitStrapperContext CreateContext()
        {
            //return _scopedContainer.AnalyzeRegistrations(provider);
            return default;
        }
        
        
    }
}