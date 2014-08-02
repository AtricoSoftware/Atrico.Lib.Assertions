using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public interface IImplementConstraintProvider : IHasAdaptersBase
	{
		/// <summary>
		///     Implements an interface
		/// </summary>
		/// <param name="expected">Expected interface</param>
		/// <returns>Constraint</returns>
		IAssertConstraint Interface(Type expected);

		/// <summary>
		///     Implements an interface
		/// </summary>
		/// <typeparam name="T">Expected type</typeparam>
		/// <returns>Constraint</returns>
		IAssertConstraint Interface<T>();
	}
}