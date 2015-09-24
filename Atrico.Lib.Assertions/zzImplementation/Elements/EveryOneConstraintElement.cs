using Atrico.Lib.Assertions.zzImplementation.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal class EveryOneConstraintElement<TItem> : ValueConstraintElement<TItem>
    {
        public EveryOneConstraintElement(Decorator decorator)
            : base(decorator.Append(new EveryOneDecorator()))
        {
        }
    }
}