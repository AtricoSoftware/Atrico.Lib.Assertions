using System;
using System.Collections;
using System.Linq;

namespace Atrico.Lib.Assertions.Implementation.Decorators
{
    internal sealed class CountDecorator<TItem> : ValueModifierDecorator<int>
    {
        private readonly Func<TItem, bool> _predicate;

        public CountDecorator(Predicate<TItem> predicate)
        {
            _predicate = new Func<TItem, bool>(predicate);
        }

        protected override int? ModifyValue(object actual)
        {
            return (actual is IEnumerable) ? (actual as IEnumerable).Cast<TItem>().Count(_predicate) : (int?) null;
        }
    }
}