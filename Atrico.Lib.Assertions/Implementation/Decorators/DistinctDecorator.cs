using System.Collections;
using System.Linq;

namespace Atrico.Lib.Assertions.Implementation.Decorators
{
    internal sealed class DistinctDecorator<TItem> : Decorator
    {
        public override bool Test(object actual)
        {
            return base.Test(RemoveDuplicates(actual));
        }

        public override string CreateErrorMessage(object actual)
        {
            return base.CreateErrorMessage(RemoveDuplicates(actual));
        }

        private static IEnumerable RemoveDuplicates(object actual)
        {
            return (actual as IEnumerable).Cast<TItem>().Distinct().ToArray();
        }
    }
}