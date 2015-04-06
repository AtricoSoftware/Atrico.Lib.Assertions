using System;
using Atrico.Lib.Assertions.Implementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class Reference
    {
        public static Constraint<T> Null<T>(this IIsConstraintElement<T> previous) where T : class
        {
            return new NullConstraint<T>(previous.Decorator);
        }

        /// <summary>
        ///     Match values using ReferenceEquals
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <returns>Constraint</returns>
        public static Constraint<T> ReferenceEqualTo<T>(this IIsConstraintElement<T> previous, object expected) where T : class
        {
            return new ReferenceEqualToConstraint<T>(previous.Decorator, expected);
        }

        public static Constraint<T> TypeOf<T>(this IIsConstraintElement<T> previous, Type expected)
        {
            return new TypeOfConstraint<T>(previous.Decorator, expected);
        }
    }
}