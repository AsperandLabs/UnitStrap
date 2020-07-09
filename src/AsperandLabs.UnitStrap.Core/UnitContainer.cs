using System;
using System.Collections.Generic;
using System.Linq;
using AsperandLabs.UnitStrap.Core.Abstracts;

namespace AsperandLabs.UnitStrap.Core
{
    public class UnitContainer
    {
        internal IEnumerable<DependencyAnalyzer> Units => _units.Select(a => a());
        private readonly List<Func<DependencyAnalyzer>> _units;
        
        public UnitContainer()
        {
            _units = new List<Func<DependencyAnalyzer>>();    
        }
        
        public void AddUnit<T>() where T : BaseUnitStrapper, new()
        {
            _units.Add(() =>
            {
                var unit = new T();
                unit.SetupRegisterCallback(s => unit.RegisterDependencies(s));
                return unit;
            });
        }
        
        public void AddUnit<T, TT>(TT config) where T : BaseUnitStrapper<TT>, new()
        {
            _units.Add(() =>
            {
                var unit = new T();
                unit.SetupRegisterCallback(s => unit.RegisterDependencies(s, config));
                return unit;
            });
        }
    }
}