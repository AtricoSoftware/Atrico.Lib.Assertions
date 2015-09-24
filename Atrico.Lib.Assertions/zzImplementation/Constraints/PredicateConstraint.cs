using System;

namespace Atrico.Lib.Assertions.zzImplementation.Constraints
{
    internal sealed class PredicateConstraint<T> : UnaryConstraint<T>
    {
        private readonly Predicate<T> _predicate;

        public PredicateConstraint(Decorator decorator, Predicate<T> predicate)
            : base(decorator, "Subject:<{0}>")
        {
            _predicate = predicate;
        }

        protected override bool TestImpl(T actual)
        {
            return _predicate(actual);
        }
    }
}