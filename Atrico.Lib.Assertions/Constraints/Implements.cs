using System;
using Atrico.Lib.Assertions.Implementation.Constraints;

namespace Atrico.Lib.Assertions.Constraints
{
    public static class Implements
    {
        public static Constraint<T> Interface<T>(this IImplementConstraintElement<T> previous, Type expected) where T : class
        {
            return new InterfaceConstraint<T>(previous.Decorator, expected);
        }
    }
}