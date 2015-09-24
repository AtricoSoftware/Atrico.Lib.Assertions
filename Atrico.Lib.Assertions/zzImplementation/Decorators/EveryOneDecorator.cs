using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Atrico.Lib.Assertions.zzImplementation.Decorators
{
    internal sealed class EveryOneDecorator : Decorator
    {
        // Not nice but...
        private IEnumerable _lastTest;
        private readonly IList<object> _lastTestFailures = new List<object>();


        public override bool Test(object actual)
        {
            _lastTest = (actual as IEnumerable) ?? new object[] {};
            _lastTestFailures.Clear();
            foreach (var item in _lastTest)
            {
                try
                {
                    if (!base.Test(item))
                    {
                        _lastTestFailures.Add(item);
                    }
                }
                catch (Exception)
                {
                    _lastTestFailures.Add(item);
                }
            }
            return !_lastTestFailures.Any();
        }

        public override string CreateErrorMessage(object actual)
        {
            return base.CreateErrorMessage(ReferenceEquals(actual, _lastTest) ? new CollectionWithHighlights(_lastTest, _lastTestFailures) : actual);
        }
    }
}