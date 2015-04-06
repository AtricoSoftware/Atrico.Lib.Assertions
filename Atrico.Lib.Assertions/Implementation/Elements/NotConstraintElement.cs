using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal class NotConstraintElement<T> : ConstraintElement<T>
    {
        public NotConstraintElement(Decorator decorator)
            : base(decorator.Append(new NotDecorator()))
        {
        }
    }
}