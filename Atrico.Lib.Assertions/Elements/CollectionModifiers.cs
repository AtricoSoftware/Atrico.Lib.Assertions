using System.Collections.Generic;
using Atrico.Lib.Assertions.Implementation.Elements;

namespace Atrico.Lib.Assertions.Elements
{
    public static class CollectionModifiers
    {
        public static IValueConstraintElement<TItem> EveryOne<TItem>(this IConstraintElement<IEnumerable<TItem>> previous)
        {
            return new EveryOneConstraintElement<TItem>(previous.Decorator);
        }

        public static IValueConstraintElement<TItem> AtLeastOne<TItem>(this IConstraintElement<IEnumerable<TItem>> previous)
        {
            return new AtLeastOneConstraintElement<TItem>(previous.Decorator);
        }

        public static IValueConstraintElement<int> Count<TItem>(this IConstraintElement<IEnumerable<TItem>> previous)
        {
            return new CountConstraintElement(previous.Decorator);
        }

        public static IValueConstraintElement<IEnumerable<TItem>> Distinct<TItem>(this IConstraintElement<IEnumerable<TItem>> previous)
        {
            return new DistinctConstraintElement<TItem>(previous.Decorator);
        }
    }
}