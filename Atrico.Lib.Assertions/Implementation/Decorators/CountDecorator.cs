using System.Collections;
using System.Linq;

namespace Atrico.Lib.Assertions.Implementation.Decorators
{
    internal sealed class CountDecorator : Decorator
    {
        public override bool Test(object actual)
        {
            return base.Test(GetCount(actual));
        }

        public override string CreateErrorMessage(object actual)
        {
            return base.CreateErrorMessage(GetCount(actual));
        }

        private static int GetCount(object actual)
        {
            return (actual as IEnumerable).Cast<object>().Count();
        }
    }
}