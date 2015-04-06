namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class ReferenceEqualToConstraint<T> : BinaryConstraint<T> where T : class
    {
        private readonly object _expected;

        public ReferenceEqualToConstraint(Decorator decorator, object expected)
            : base(decorator, expected)
        {
            _expected = expected;
        }

        protected override bool TestImpl(T actual)
        {
            return ReferenceEquals(actual, _expected);
        }
    }
}