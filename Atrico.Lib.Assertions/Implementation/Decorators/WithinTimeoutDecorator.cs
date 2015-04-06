using System;
using System.Threading.Tasks;

namespace Atrico.Lib.Assertions.Implementation.Decorators
{
    internal sealed class WithinTimeoutDecorator : Decorator
    {
        private readonly TimeSpan _timeout;

        public WithinTimeoutDecorator(TimeSpan timeout)
        {
            _timeout = timeout;
        }

        public override bool Test(object actual)
        {
            var task = Task.Run(() => base.Test(actual));
            return task.Wait(_timeout) && task.Result;
        }
    }
}