using System;
using System.Collections;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Decorator to count members of collection
	/// </summary>
	public sealed class CountDecorator : DecoratorBase
	{
		public static DecoratorFunction Create()
		{
			return NameDecorator.Create("Count")
				.Append(n => new CountDecorator(n));
		}

		private CountDecorator(IAssertConstraint child)
			: base(child)
		{
		}

		public override bool Test(object actual)
		{
			var count = GetCount(actual);
			return base.Test(count);
		}

		public override string CreateErrorMessage(object actual)
		{
			var count = GetCount(actual);
			return base.CreateErrorMessage(count);
		}

		private static int GetCount(object actual)
		{
			if (actual is IEnumerable)
			{
				return (actual as IEnumerable).Cast<object>().Count();
			}
			throw new Exception(string.Format("'{0}' has no count", actual ?? "null"));
		}
	}
}
