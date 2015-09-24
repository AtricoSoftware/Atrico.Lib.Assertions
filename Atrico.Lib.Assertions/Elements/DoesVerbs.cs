using Atrico.Lib.Assertions.zzImplementation.Elements;

namespace Atrico.Lib.Assertions.Elements
{
    public static class DoesVerbs
    {
        public static ISatisfyConstraintElement<T> Satisfy<T>(this IDoesConstraintElement<T> previous)
        {
            return new SatisfyConstraintElement<T>(previous.Decorator);
        }

        public static IImplementConstraintElement<T> Implement<T>(this IDoesConstraintElement<T> previous)
        {
            return new ImplementConstraintElement<T>(previous.Decorator);
        }
    }
}