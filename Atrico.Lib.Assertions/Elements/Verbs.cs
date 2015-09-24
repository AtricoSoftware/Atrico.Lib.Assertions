using Atrico.Lib.Assertions.zzImplementation.Elements;

namespace Atrico.Lib.Assertions.Elements
{
    public static class Verbs
    {
        public static IIsWithNotConstraintElement<T> Is<T>(this IValueConstraintElement<T> previous)
        {
            return new IsConstraintElement<T>(previous.Decorator);
        }

        public static IDoesWithNotConstraintElement<T> Does<T>(this IValueConstraintElement<T> previous)
        {
            return new DoesConstraintElement<T>(previous.Decorator);
        }
    }
}