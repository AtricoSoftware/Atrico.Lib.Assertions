using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Assertions.Constraints;

namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class EquivalentToConstraint<TItem> : BinaryConstraint<IEnumerable<TItem>>
    {
        private readonly TItem[] _expected;
        private readonly EqualsDelegate<TItem> _compare;

        public EquivalentToConstraint(Decorator decorator, IEnumerable<TItem> expected)
            : this(decorator, expected, DefaultEquals)
        {
        }

        public EquivalentToConstraint(Decorator decorator, IEnumerable<TItem> expected, EqualsDelegate<TItem> comparer)
            : base(decorator, expected)
        {
            _expected = expected.ToArray();
            _compare = comparer;
        }

        protected override bool TestImpl(IEnumerable<TItem> actual)
        {
            var actualA = actual.ToArray();
            if (actualA.Length != _expected.Length)
            {
                return false;
            }
            return _expected.All(itemE => actualA.Any(itemA => _compare(itemA, itemE)));
        }

        private static bool DefaultEquals(TItem actual, TItem expected)
        {
            return actual.Equals(expected);
        }
    }
}