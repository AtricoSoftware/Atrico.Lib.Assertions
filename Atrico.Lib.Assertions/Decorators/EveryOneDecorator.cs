using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Assertions.Helpers;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Decorator to check that every member of collection satisfies the constraint
	/// </summary>
	public sealed class EveryOneDecorator : DecoratorBase
	{
		// Not nice but...
		private IEnumerable _lastTest;
		private readonly IList<object> _lastTestFailures = new List<object>();

		public static DecoratorFunction Create()
		{
			return NameDecorator.Create("EveryOne")
				.Append(n => new EveryOneDecorator(n));
		}

		private EveryOneDecorator(IAssertConstraint child)
			: base(child)
		{
		}

		public override bool Test(object actualObj)
		{
			_lastTest = (actualObj as IEnumerable) ?? new object[] {};
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
