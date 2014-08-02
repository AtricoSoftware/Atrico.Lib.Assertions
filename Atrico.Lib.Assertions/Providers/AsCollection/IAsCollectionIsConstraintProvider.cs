using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public interface IAsCollectionIsConstraintProvider : IIsConstraintProvider
	{
		/// <summary>
		///     Match lists ignoring order
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint EquivalentTo<T>(params T[] expected);

		/// <summary>
		///     Match lists ignoring order
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected);
	}
}