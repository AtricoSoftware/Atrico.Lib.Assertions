using System;
using System.Collections;

namespace Atrico.Lib.Assertions.zzImplementation.Constraints
{
    internal sealed class InterfaceConstraint<T> : Constraint<T> where T : class
    {
        private readonly Type _expected;

        public InterfaceConstraint(Decorator decorator, Type expected)
            : base(decorator)
        {
            _expected = expected;
        }

        protected override bool TestImpl(T actual)
        {
            return !ReferenceEquals(actual, null) && _expected.IsInstanceOfType(actual);
        }

        protected override IEnumerable CreateElementNameArguments
        {
            get { return new[] {_expected}; }
        }

        protected override string CreateElementOpenBrace
        {
            get { return "<"; }
        }

        protected override string CreateElementCloseBrace
        {
            get { return ">"; }
        }
    }
}