using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions
{
    public static class Value
    {
        public static IValueConstraintElement<T> Of<T>(T actual)
        {
            return new ValueProvider<T>(actual);
        }

        private sealed class ValueProvider<T> : ValueConstraintElement<T>
        {
            public ValueProvider(T value)
                : base(new ValueProviderDecorator(value))
            {
            }

            private class ValueProviderDecorator : NameLessDecorator
            {
                private readonly T _value;

                public ValueProviderDecorator(T value)
                {
                    _value = value;
                }

                public override bool Test(object ignored)
                {
                    return base.Test(_value);
                }

                public override string CreateErrorMessage(object ignored)
                {
                    return base.CreateErrorMessage(_value);
                }
            }
        }
    }
}