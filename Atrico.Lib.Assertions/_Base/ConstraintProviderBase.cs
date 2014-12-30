// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public abstract class ConstraintProviderBase
	{
		protected DecoratorFunction Decorator { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="decorator">Decorator from previous provider + new adapters for this provider</param>
		protected ConstraintProviderBase(DecoratorFunction decorator)
		{
			Decorator = decorator;
		}

		/// <summary>
		/// Append a decorator to this provider
		/// </summary>
		/// <param name="decorator">Decorator to append</param>
		protected void AppendDecorator(DecoratorFunction decorator)
		{
			Decorator = Decorator.Append(decorator);
		}
	}
}
