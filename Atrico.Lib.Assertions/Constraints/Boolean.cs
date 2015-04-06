using Atrico.Lib.Assertions.Implementation.Constraints;

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
    }
}