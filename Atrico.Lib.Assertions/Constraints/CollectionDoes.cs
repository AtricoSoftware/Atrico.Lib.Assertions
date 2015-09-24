using System.Collections.Generic;
using Atrico.Lib.Assertions.zzImplementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class CollectionDoes
    {
        public static Constraint<IEnumerable<TItem>> Contain<TItem>(this IConstraintElement<IEnumerable<TItem>> previous, TItem item)
        {
            return new ContainConstraint<TItem>(previous.Decorator, item);
        }
    }
}