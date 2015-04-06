using System;
using System.Collections;

namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class BetweenConstraint<T> : UnaryConstraint<T>
    {
        private readonly Range _range;

        public class Range
        {
            private readonly IComparable<T> _lowerLimit;
            private readonly IComparable<T> _upperLimit;

            public Range(IComparable<T> lowerLimit, IComparable<T> upperLimit)
            {
                _lowerLimit = lowerLimit;
                _upperLimit = upperLimit;
            }

            public bool IsWithin(T actual)
            {
                return !ReferenceEquals(actual, null)
                       && _lowerLimit.CompareTo(actual) <= 0
                       && _upperLimit.CompareTo(actual) >= 0;
            }

            public override string ToString()
            {
                return string.Format("{0} -> {1}", _lowerLimit, _upperLimit);
            }
        }

        public BetweenConstraint(Decorator decorator, IComparable<T> lowerLimit, IComparable<T> upperLimit)
            : base(decorator)
        {
            _range = new Range(lowerLimit, upperLimit);
        }

        protected override bool TestImpl(T actual)
        {
            return _range.IsWithin(actual);
        }

        protected override IEnumerable CreateElementNameArguments
        {
            get { return new[] {_range}; }
        }
    }
}