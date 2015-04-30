using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class EqualToConstraint<T> : Constraint<T>
    {
        private readonly object _expected;
        private readonly EqualsObjectDelegate<T> _comparer;

        public EqualToConstraint(Decorator decorator, object expected)
            : this(decorator, expected, DefaultEquals)
        {
        }

        public EqualToConstraint(Decorator decorator, object expected, EqualsObjectDelegate<T> comparer)
            : base(decorator.Append(new BinaryErrorMessageWithTypeDecorator(expected)))
        {
            _expected = expected;
            _comparer = comparer;
        }

        protected override bool TestImpl(T actual)
        {
            return _comparer(actual, _expected);
        }

        private static bool DefaultEquals(T actual, object expected)
        {
            if (expected is IEnumerable && actual is IEnumerable)
            {
                return CollectionEquals((actual as IEnumerable).Cast<object>().ToArray(), (expected as IEnumerable).Cast<object>().ToArray());
            }
            return actual.Equals(expected);
        }

        private static bool CollectionEquals(ICollection<object> actual, IList<object> expected)
        {
            if (expected.Count != actual.Count)
            {
                return false;
            }
            return !actual.Where((t, i) => !t.Equals(expected[i])).Any();
        }
    }
}