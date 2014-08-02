using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public interface IIsConstraintProvider
	{
		#region Boolean

		/// <summary>
		///     Match to true
		/// </summary>
		/// <returns>Constraint</returns>
		IAssertConstraint True { get; }

		/// <summary>
		///     Match to false
		/// </summary>
		/// <returns>Constraint</returns>
		IAssertConstraint False { get; }

		#endregion

		#region Comparison

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint EqualTo(object expected);

		/// <summary>
		///     Match values using less than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint LessThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>;

		/// <summary>
		///     Match values using less thanor equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint LessThanOrEqualTo<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>;

		/// <summary>
		///     Match values using greater than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint GreaterThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>;

		/// <summary>
		///     Match values using greater than or equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		IAssertConstraint GreaterThanOrEqualTo<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>;

		/// <summary>
		///     Match values between limits
		/// </summary>
		/// <returns>Constraint</returns>
		IAssertConstraint Between<TExpected>(TExpected lowerLimit, TExpected upperLimit)
			where TExpected : IComparable<TExpected>;

		#endregion

		#region Types

		/// <summary>
		///     Match null
		/// </summary>
		/// <returns>Constraint</returns>
		IAssertConstraint Null { get; }

		/// <summary>
		///     Match type
		/// </summary>
		/// <param name="expected">Expected type</param>
		/// <returns>Constraint</returns>
		IAssertConstraint TypeOf(Type expected);

		/// <summary>
		///     Match type
		/// </summary>
		/// <typeparam name="T">Expected type</typeparam>
		/// <returns>Constraint</returns>
		IAssertConstraint TypeOf<T>();

		#endregion
	}
}