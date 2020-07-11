using System.Collections.Generic;

namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public class DependencyContext
    {
        public string BaseNamespace { get; set; }
        public IEnumerable<string> UsedTypes { get; set; }
    }
}