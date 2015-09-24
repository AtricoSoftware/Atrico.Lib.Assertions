using System;
using System.Collections;
using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Constraints
{
    internal sealed class TypeOfConstraint<T> : Constraint<T>
    {
        private readonly Type _expected;

        public TypeOfConstraint(Decorator decorator, Type expected)
            : base(decorator.Append(new TypeOfErrorMessageDecorator()))
        {
            _expected = expected;
        }

        protected override bool TestImpl(T actual)
        {
            return !ReferenceEquals(actual, null) && actual.GetType() == _expected;
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

        private class TypeOfErrorMessageDecorator : NameLessDecorator
        {
            private readonly string _actualFormat;

            public TypeOfErrorMessageDecorator()
            {
                _actualFormat = "Actual:<{0}>";
            }

            /// <summary>
            ///     Throw error with actual, format specified
            /// </summary>
            /// <param name="actual">Actual value</param>
            public override string CreateErrorMessage(object actual)
            {
                return string.Format(_actualFormat, FormatObject(actual));
            }

            private static string FormatObject(object obj)
            {
                return ReferenceEquals(obj, null) ? "null" : obj.GetType().ToString();
            }
        }
    }
}