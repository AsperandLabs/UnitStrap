using System;
using System.Collections.Generic;

namespace AsperandLabs.UnitStrap.Core
{
    public class RegistrationAnalysis
    {
        public string BaseNamespace { get; set; }
        public List<Type> InScopeRegisteredTypes { get; set; }
        public List<Type> InScopeUnregisteredTypes { get; set; }
        public List<Type> InScopeUnusedRegisteredTypes { get; set; }
        public List<Type> OutOfScopeUnregisteredTypes { get; set; }
        public List<Type> OutOfScopeRegisteredTypes { get; set; }
        public List<Type> OutOfScopeUnusedRegisteredTypes { get; set; }
    }
}