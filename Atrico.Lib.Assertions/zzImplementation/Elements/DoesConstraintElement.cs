using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal sealed class DoesConstraintElement<T> : ConstraintElement<T>, IDoesWithNotConstraintElement<T>
    {
        public DoesConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Does")))
        {
        }
    }
}