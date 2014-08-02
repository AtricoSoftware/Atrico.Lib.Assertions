using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public interface ISatisfyConstraintProvider : IHasAdaptersBase
	{
		/// <summary>
		///     Match predicate
		/// </summary>
		/// <returns>Constraint</returns>
		IAssertConstraint Predicate<T>(Func<T, bool> predicate);
	}
}