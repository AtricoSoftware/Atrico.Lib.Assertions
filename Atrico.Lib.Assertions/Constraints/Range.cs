using System;
using Atrico.Lib.Assertions.zzImplementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class Range
    {
        /// <summary>
        ///     Match values using less than
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <returns>Constraint</returns>
        public static Constraint<T> LessThan<T>(this IIsConstraintElement<T> previous, IComparable<T> expected)
        {
            return new LessThanConstraint<T>(previous.Decorator, expected);
        }

        /// <summary>
        ///     Match values using less thanor equal to
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <returns>Constraint</returns>
        public static Constraint<T> LessThanOrEqualTo<T>(this IIsConstraintElement<T> previous, IComparable<T> expected)

        {
            return new LessThanOrEqualToConstraint<T>(previous.Decorator, expected);
        }

        /// <summary>
        ///     Match values using greater than
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <returns>Constraint</returns>
        public static Constraint<T> GreaterThan<T>(this IIsConstraintElement<T> previous, IComparable<T> expected)
        {
            return new GreaterThanConstraint<T>(previous.Decorator, expected);
        }

        /// <summary>
        ///     Match values using greater than or equal to
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <returns>Constraint</returns>
        public static Constraint<T> GreaterThanOrEqualTo<T>(this IIsConstraintElement<T> previous, IComparable<T> expected)

        {
            return new GreaterThanOrEqualToConstraint<T>(previous.Decorator, expected);
        }

        /// <summary>
        ///     Match values between limits
        /// </summary>
        /// <returns>Constraint</returns>
        public static Constraint<T> Between<T>(this IIsConstraintElement<T> previous, IComparable<T> lowerLimit, IComparable<T> upperLimit)

        {
            return new BetweenConstraint<T>(previous.Decorator, lowerLimit, upperLimit);
        }
    }
}