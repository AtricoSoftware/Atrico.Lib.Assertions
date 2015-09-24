using System;
using Atrico.Lib.Assertions.zzImplementation.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal sealed class WithinTimeoutConstraintElement<T> : ValueConstraintElement<T>
    {
        public WithinTimeoutConstraintElement(Decorator decorator, TimeSpan timeout)
            : base(decorator.Append(new WithinTimeoutDecorator(timeout)))
        {
        }
    }
}