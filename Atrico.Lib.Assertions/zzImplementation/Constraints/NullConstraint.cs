using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Constraints
{
    internal sealed class NullConstraint<T> : Constraint<T> where T : class
    {
        public NullConstraint(Decorator decorator)
            : base(decorator.Append(new NullErrorMessageDecorator()))
        {
        }

        protected override bool TestImpl(T actual)
        {
            return ReferenceEquals(actual, null);
        }

        private class NullErrorMessageDecorator : UnaryErrorMessageDecorator
        {
            public override string CreateErrorMessage(object actual)
            {
                return ReferenceEquals(actual, null) ? "" : base.CreateErrorMessage(actual);
            }
        }
    }
}