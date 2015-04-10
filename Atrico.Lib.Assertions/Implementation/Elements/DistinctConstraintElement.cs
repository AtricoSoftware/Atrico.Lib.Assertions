using System.Collections.Generic;
using Atrico.Lib.Assertions.Implementation.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Elements
{
    internal sealed class DistinctConstraintElement<TItem> : ValueConstraintElement<IEnumerable<TItem>>
    {
        public DistinctConstraintElement(Decorator decorator)
            : base(decorator.Append(new DistinctDecorator<TItem>()))
        {
        }
    }
}