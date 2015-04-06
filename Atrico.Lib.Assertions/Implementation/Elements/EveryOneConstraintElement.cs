using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal class EveryOneConstraintElement<TItem> : ConstraintElement<TItem>, IValueConstraintElement<TItem>
    {
        public EveryOneConstraintElement(Decorator decorator)
            : base(decorator.Append(new EveryOneDecorator()))
        {
        }
    }
}