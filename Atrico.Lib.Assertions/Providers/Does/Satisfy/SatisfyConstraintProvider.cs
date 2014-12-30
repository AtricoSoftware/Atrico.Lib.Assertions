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
		/// <param name="decorator">Decorator from previous provider</param>
		public SatisfyConstraintProvider(DecoratorFunction decorator)
			: base(decorator)
		{
			AppendDecorator(NameDecorator.Create("Satisfy"));
		}

		/// <summary>
		///     Match predicate
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint Predicate<T>(Func<T, bool> predicate)
		{
			return Decorator(new PredicateConstraint<T>(predicate));
		}
	}
}
