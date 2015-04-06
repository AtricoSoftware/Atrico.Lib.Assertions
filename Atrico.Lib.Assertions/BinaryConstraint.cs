using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions
{
    public abstract class BinaryConstraint<T> : Constraint<T>
    {
        protected BinaryConstraint(Decorator decorator, object expected, string actualFormat = null, string expectedFormat = null)
            : base(decorator.Append(new BinaryErrorMessageDecorator(expected, actualFormat, expectedFormat)))
        {
        }
    }
}