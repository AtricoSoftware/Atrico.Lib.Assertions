using Atrico.Lib.Assertions.zzImplementation.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal class AtLeastOneConstraintElement<TItem> : ValueConstraintElement<TItem>
    {
        public AtLeastOneConstraintElement(Decorator decorator)
            : base(decorator.Append(new AtLeastOneDecorator()))
        {
        }
    }
}