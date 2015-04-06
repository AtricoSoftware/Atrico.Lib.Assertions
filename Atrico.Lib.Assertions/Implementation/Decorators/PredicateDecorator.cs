using System;
using Atrico.Lib.Assertions.Decorators;

namespace Atrico.Lib.Assertions.Implementation.Decorators
{
    internal sealed class PredicateDecorator<T> : NameLessDecorator
    {
        private readonly Predicate<T> _predicate;

        public PredicateDecorator(Predicate<T> predicate)
        {
            _predicate = predicate;
        }

        public override bool Test(object actual)
        {
            return _predicate((T) actual);
        }
    }
}