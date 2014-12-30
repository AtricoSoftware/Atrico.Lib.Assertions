using System;
using System.Collections;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Decorator to check that at least one member of collection satisfies the constraint
	/// </summary>
	public sealed class AtLeastOneDecorator : DecoratorBase
	{
		public static DecoratorFunction Create()
		{
			return NameDecorator.Create("AtLeastOne")
				.Append(n => new AtLeastOneDecorator(n));
		}

		private AtLeastOneDecorator(IAssertConstraint child)
			: base(child)
		{
		}

		public override bool Test(object actualObj)
		{
			Exception ex = null;
			var actual = (actualObj as IEnumerable) ?? new Object[] {};
			foreach (var item in actual)
			{
				try
				{
					if (base.Test(item))
					{
						return true;
					}
				}
				catch (Exception ex2)
				{
					ex = ex2;
				}
			}
			if (ex != null)
			{
				throw new Exception(CreateErrorMessage(actual));
			}
			return false;
		}
	}
}
