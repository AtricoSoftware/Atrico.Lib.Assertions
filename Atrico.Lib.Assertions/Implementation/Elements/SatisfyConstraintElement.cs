using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class SatisfyConstraintElement<T> : ConstraintElement<T>, ISatisfyConstraintElement<T>
    {
        public SatisfyConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Satisfy")))
        {
        }
    }
}