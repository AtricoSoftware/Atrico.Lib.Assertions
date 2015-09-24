using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal sealed class SatisfyConstraintElement<T> : ConstraintElement<T>, ISatisfyConstraintElement<T>
    {
        public SatisfyConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Satisfy")))
        {
        }
    }
}