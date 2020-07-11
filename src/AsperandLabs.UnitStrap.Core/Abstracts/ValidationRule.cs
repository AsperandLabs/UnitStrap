namespace AsperandLabs.UnitStrap.Core.Abstracts
{
    public abstract class ValidationRule
    {
        public abstract bool ValidateDependency(string fullTypeName, string baseNamespace);
    }
}