using Atrico.Lib.Assertions.zzImplementation.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal class NotConstraintElement<T> : ConstraintElement<T>
    {
        public NotConstraintElement(Decorator decorator)
            : base(decorator.Append(new NotDecorator()))
        {
        }
    }
}