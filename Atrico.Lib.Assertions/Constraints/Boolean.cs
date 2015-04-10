using Atrico.Lib.Assertions.Implementation.Constraints;
using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class Boolean
    {
        public static Constraint<bool> True(this IIsConstraintElement<bool> previous)
        {
            return new TrueConstraint(previous.Decorator);
        }

        public static Constraint<bool> False(this IIsConstraintElement<bool> previous)
        {
            return new FalseConstraint(previous.Decorator);
        }
        public static Constraint<bool> True(this IIsConstraintElement<bool?> previous)
        {
            return new TrueConstraint(previous.Decorator.Append(new NullableValueDecorator<bool>()));
        }

        public static Constraint<bool> False(this IIsConstraintElement<bool?> previous)
        {
            return new FalseConstraint(previous.Decorator.Append(new NullableValueDecorator<bool>()));
        }
    }
}