using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Atrico.Lib.Assertions.zzImplementation.Decorators
{
    internal sealed class DistinctDecorator<TItem> : RefValueModifierDecorator<IEnumerable<TItem>>
    {
        protected override IEnumerable<TItem> ModifyValue(object actual)
        {
            return (actual is IEnumerable) ? (actual as IEnumerable).Cast<TItem>().Distinct().ToArray() : null;
        }
    }
}