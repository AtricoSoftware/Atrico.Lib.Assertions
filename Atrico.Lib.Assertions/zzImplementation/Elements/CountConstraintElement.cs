using System;
using Atrico.Lib.Assertions.zzImplementation.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal sealed class CountConstraintElement<TItem> : ValueConstraintElement<int>
    {
        public CountConstraintElement(Decorator decorator, Predicate<TItem> predicate)
            : base(decorator.Append(new CountDecorator<TItem>(predicate)))
        {
        }
    }
}