using System;
using System.Collections;

namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class GreaterThanConstraint<T> : UnaryConstraint<T>
    {
        private readonly IComparable<T> _expected;

        public GreaterThanConstraint(Decorator decorator, IComparable<T> expected)
            : base(decorator)
        {
            _expected = expected;
        }

        protected override bool TestImpl(T actual)
        {
            return _expected.CompareTo(actual) < 0;
        }

        protected override IEnumerable CreateElementNameArguments
        {
            get { return new[] {_expected}; }
        }
    }
}