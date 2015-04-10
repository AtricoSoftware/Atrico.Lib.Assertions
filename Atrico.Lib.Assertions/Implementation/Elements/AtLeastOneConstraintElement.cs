using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal class AtLeastOneConstraintElement<TItem> : ValueConstraintElement<TItem>
    {
        public AtLeastOneConstraintElement(Decorator decorator)
            : base(decorator.Append(new AtLeastOneDecorator()))
        {
        }
    }
}