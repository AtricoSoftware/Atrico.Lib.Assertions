using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal class EveryOneConstraintElement<TItem> : ValueConstraintElement<TItem>
    {
        public EveryOneConstraintElement(Decorator decorator)
            : base(decorator.Append(new EveryOneDecorator()))
        {
        }
    }
}