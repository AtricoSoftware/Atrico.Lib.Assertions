using Atrico.Lib.Common;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Decorator to count members of collection
	/// </summary>
	public class TypeChangeDecorator<T> : DecoratorBase
	{
		public static DecoratorFunction Create()
		{
			return n => new TypeChangeDecorator<T>(n);
		}

		private TypeChangeDecorator(IAssertConstraint child)
			: base(child)
		{
		}

		public override object CreateConstraintOperand(object actual)
		{
			return Conversion.Convert<T>(actual);
		}
	}
}
