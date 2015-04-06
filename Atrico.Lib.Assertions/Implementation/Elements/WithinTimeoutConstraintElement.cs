using System;
using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class WithinTimeoutConstraintElement<T> : ConstraintElement<T>, IValueConstraintElement<T>
    {
        public WithinTimeoutConstraintElement(Decorator decorator, TimeSpan timeout)
            : base(decorator.Append(new WithinTimeoutDecorator(timeout)))
        {
        }
    }
}