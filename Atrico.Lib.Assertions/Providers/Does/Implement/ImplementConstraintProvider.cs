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
		public ImplementConstraintProvider(params IAdapter[] adapters)
			: base(adapters)
		{
		}

		public IAssertConstraint Interface(Type expected)
		{
			return Adapt(new InterfaceConstraint(expected));
		}

		public IAssertConstraint Interface<T>()
		{
			return Adapt(new InterfaceConstraint(typeof(T)));
		}
	}
}