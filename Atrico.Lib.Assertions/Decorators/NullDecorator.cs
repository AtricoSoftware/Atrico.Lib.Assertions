// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public sealed class NullDecorator : DecoratorBase
	{
		public static DecoratorFunction Create()
		{
			return child => new NullDecorator(child);
		}

		private NullDecorator(IAssertConstraint child)
			: base(child)
		{
		}
	}
}
