using System.Collections;
using System.Linq;

namespace Atrico.Lib.Assertions.Implementation.Decorators
{
    internal sealed class AtLeastOneDecorator : Decorator
    {
        public override bool Test(object actual)
        {
            return (actual as IEnumerable).Cast<object>().Any(item => base.Test(item));
        }
    }
}