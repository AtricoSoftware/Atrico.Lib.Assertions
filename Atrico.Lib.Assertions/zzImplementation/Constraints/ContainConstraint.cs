using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Atrico.Lib.Assertions.zzImplementation.Constraints
{
    internal sealed class ContainConstraint<TItem> : UnaryConstraint<IEnumerable<TItem>>
    {
        private readonly TItem _item;

        public ContainConstraint(Decorator decorator, TItem item)
            : base(decorator)
        {
            _item = item;
        }

        protected override bool TestImpl(IEnumerable<TItem> actual)
        {
            return actual.Contains(_item);
        }

        protected override IEnumerable CreateElementNameArguments
        {
            get { return new[] {_item}; }
        }
    }
}