using System;
using Atrico.Lib.Assertions.zzImplementation.Elements;

namespace Atrico.Lib.Assertions.Elements
{
    public static class Misc
    {
        public static IValueConstraintElement<T> WithinTimeout<T>(this IValueConstraintElement<T> previous, TimeSpan timeout)
        {
            return new WithinTimeoutConstraintElement<T>(previous.Decorator, timeout);
        }
    }
}