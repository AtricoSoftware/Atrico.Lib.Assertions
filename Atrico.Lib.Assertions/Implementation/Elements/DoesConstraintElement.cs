using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class DoesConstraintElement<T> : ConstraintElement<T>, IDoesWithNotConstraintElement<T>
    {
        public DoesConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Does")))
        {
        }
    }
}