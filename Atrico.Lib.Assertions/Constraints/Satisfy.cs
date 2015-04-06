using System;
using Atrico.Lib.Assertions.Implementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class Satisfy
    {
        public static Constraint<T> Predicate<T>(this ISatisfyConstraintElement<T> previous, Predicate<T> predicate)
        {
            return new PredicateConstraint<T>(previous.Decorator, predicate);
        }
    }
}