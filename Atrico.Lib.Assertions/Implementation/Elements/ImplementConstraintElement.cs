using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class ImplementConstraintElement<T> : ConstraintElement<T>, IImplementConstraintElement<T>
    {
        public ImplementConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Implement")))
        {
        }
    }
}