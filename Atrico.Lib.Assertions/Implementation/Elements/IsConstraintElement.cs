using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class IsConstraintElement<T> : ConstraintElement<T>, IIsWithNotConstraintElement<T>
    {
        public IsConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Is")))
        {
        }
    }
}