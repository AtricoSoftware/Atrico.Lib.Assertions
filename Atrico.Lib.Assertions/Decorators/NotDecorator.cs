// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Decorator to invert result
	/// </summary>
	public sealed class NotDecorator : DecoratorBase
	{
		public static DecoratorFunction Create()
		{
			return NameDecorator.Create("Not")
				.Append(n => new NotDecorator(n));
		}

		private NotDecorator(IAssertConstraint child)
			: base(child)
		{
		}

		public override bool Test(object actual)
		{
			return !base.Test(actual);
		}
	}
}
