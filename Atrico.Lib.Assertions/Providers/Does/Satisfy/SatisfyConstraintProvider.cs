using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public class SatisfyConstraintProvider : ConstraintProviderBase, ISatisfyConstraintProvider
	{
		/// <summary>
		///     Constructor
		/// </summary>
		public SatisfyConstraintProvider(params IAdapter[] adapters)
			: base(adapters)
		{
		}

		/// <summary>
		///     Match predicate
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint Predicate<T>(Func<T, bool> predicate)
		{
			return Adapt(new PredicateConstraint<T>(predicate));
		}
	}
}