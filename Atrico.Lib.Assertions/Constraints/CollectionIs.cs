using System.Collections.Generic;
using Atrico.Lib.Assertions.zzImplementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class CollectionIs
    {
        /// <summary>
        ///     Match lists ignoring order
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <returns>Constraint</returns>
        public static Constraint<IEnumerable<TItem>> EquivalentTo<TItem>(this IConstraintElement<IEnumerable<TItem>> previous, IEnumerable<TItem> expected)
        {
            return new EquivalentToConstraint<TItem>(previous.Decorator, expected);
        }

        /// <summary>
        ///     Match lists ignoring order
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <param name="comparer">Custom comparison predicate</param>
        /// <returns>Constraint</returns>
        public static Constraint<IEnumerable<TItem>> EquivalentTo<TItem>(this IConstraintElement<IEnumerable<TItem>> previous, IEnumerable<TItem> expected, EqualsDelegate<TItem> comparer)
        {
            return new EquivalentToConstraint<TItem>(previous.Decorator, expected, comparer);
        }
    }
}