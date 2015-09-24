using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal sealed class IsConstraintElement<T> : ConstraintElement<T>, IIsWithNotConstraintElement<T>
    {
        public IsConstraintElement(Decorator decorator)
            : base(decorator.Append(NameDecorator.Create("Is")))
        {
        }
    }
}