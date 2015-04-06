using Atrico.Lib.Assertions.Implementation.Elements;

namespace Atrico.Lib.Assertions.Elements
{
    public static class Modifiers
    {
        public static IIsConstraintElement<T> Not<T>(this IIsWithNotConstraintElement<T> previous)
        {
            return new IsDoesNotConstraintElementIsWrapper<T>(new NotConstraintElement<T>(previous.Decorator));
        }

        public static IDoesConstraintElement<T> Not<T>(this IDoesWithNotConstraintElement<T> previous)
        {
            return new IsDoesNotConstraintElementIsWrapper<T>(new NotConstraintElement<T>(previous.Decorator));
        }

        private class IsDoesNotConstraintElementIsWrapper<T> : IIsConstraintElement<T>, IDoesConstraintElement<T>
        {
            private readonly NotConstraintElement<T> _not;

            public IsDoesNotConstraintElementIsWrapper(NotConstraintElement<T> not)
            {
                _not = not;
            }

            public Decorator Decorator
            {
                get { return _not.Decorator; }
            }
        }
    }
}