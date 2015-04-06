using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class CountConstraintElement : ConstraintElement<int>, IValueConstraintElement<int>
    {
        public CountConstraintElement(Decorator decorator)
            : base(decorator.Append(new CountDecorator()))
        {
        }
    }
}