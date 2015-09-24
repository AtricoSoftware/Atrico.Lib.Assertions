using System.Collections.Generic;
using Atrico.Lib.Assertions.zzImplementation.Decorators;

namespace Atrico.Lib.Assertions.zzImplementation.Elements
{
    internal sealed class DistinctConstraintElement<TItem> : ValueConstraintElement<IEnumerable<TItem>>
    {
        public DistinctConstraintElement(Decorator decorator)
            : base(decorator.Append(new DistinctDecorator<TItem>()))
        {
        }
    }
}