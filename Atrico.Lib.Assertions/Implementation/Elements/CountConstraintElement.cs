using System;
using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class CountConstraintElement<TItem> : ValueConstraintElement<int>
    {
        public CountConstraintElement(Decorator decorator, Predicate<TItem> predicate)
            : base(decorator.Append(new CountDecorator<TItem>(predicate)))
        {
        }
    }
}