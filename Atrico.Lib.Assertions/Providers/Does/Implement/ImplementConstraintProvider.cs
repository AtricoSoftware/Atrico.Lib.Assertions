using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public class ImplementConstraintProvider : ConstraintProviderBase, IImplementConstraintProvider
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="decorator">Decorator from previous provider</param>
		public ImplementConstraintProvider(DecoratorFunction decorator)
			: base(decorator)

		{
			AppendDecorator(NameDecorator.Create("Implement"));
		}

		public IAssertConstraint Interface(Type expected)
		{
			return Decorator(new InterfaceConstraint(expected));
		}

		public IAssertConstraint Interface<T>()
		{
			return Decorator(new InterfaceConstraint(typeof (T)));
		}
	}
}
