using System;
using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Tests._Helpers
{
    public static class DummyExtension
    {
        public static Constraint<T> GetName<T>(this IConstraintElement<T> previous)
        {
            return new DummyConstraint<T>(previous.Decorator);
        }

        public static Constraint<T> GetTestValue<T>(this IConstraintElement<T> previous, Action<T> getValue)
        {
            return new DummyConstraint<T>(previous.Decorator, getValue);
        }

        public static Constraint<T> GetErrorMessageValue<T>(this IConstraintElement<T> previous, Action<T> getValue)
        {
            return new DummyConstraint<T>(previous.Decorator, getErrorValue: getValue);
        }

        public static Constraint<T> ConstraintPredicate<T>(this IConstraintElement<T> previous, Predicate<T> predicate)
        {
            return new DummyConstraint<T>(previous.Decorator, predicate: predicate);
        }

        private class DummyConstraint<T> : Constraint<T>
        {
            private readonly Action<T> _getTestValue;
            private readonly Predicate<T> _predicate;

            public DummyConstraint(Decorator decorator, Action<T> getTestValue = null, Action<T> getErrorValue = null, Predicate<T> predicate = null)
                : base(decorator.Append(new GetErrorMessageValueDecorator(getErrorValue)))
            {
                _getTestValue = getTestValue;
                _predicate = predicate;
            }

            protected override string CreateElementName()
            {
                return string.Empty;
            }

            protected override bool TestImpl(T actual)
            {
                if (_getTestValue != null) _getTestValue(actual);
                return _predicate != null && _predicate(actual);
            }

            private class GetErrorMessageValueDecorator : NameLessDecorator
            {
                private readonly Action<T> _getErrorValue;

                public GetErrorMessageValueDecorator(Action<T> getErrorValue)
                {
                    _getErrorValue = getErrorValue;
                }

                public override string CreateErrorMessage(object actual)
                {
                    if (_getErrorValue != null) _getErrorValue((T) actual);
                    return base.CreateErrorMessage(actual);
                }
            }
        }
    }
}