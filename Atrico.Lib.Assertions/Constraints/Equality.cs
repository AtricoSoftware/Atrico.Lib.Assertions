using Atrico.Lib.Assertions.zzImplementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class Equality
    {
        public static Constraint<T> EqualTo<T>(this IIsConstraintElement<T> previous, object expected)
        {
            return new EqualToConstraint<T>(previous.Decorator, expected);
        }

        public static Constraint<T> EqualTo<T>(this IIsConstraintElement<T> previous, object expected, EqualsObjectDelegate<T> comparer)
        {
            return new EqualToConstraint<T>(previous.Decorator, expected, comparer);
        }
    }
}