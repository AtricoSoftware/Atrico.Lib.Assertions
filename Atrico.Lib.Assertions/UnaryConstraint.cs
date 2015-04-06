using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions
{
    public abstract class UnaryConstraint<T> : Constraint<T>
    {
        protected UnaryConstraint(Decorator decorator, string actualFormat = null)
            : base(decorator.Append(new UnaryErrorMessageDecorator(actualFormat)))
        {
        }
    }
}