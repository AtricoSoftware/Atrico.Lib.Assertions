using System;
using System.Collections;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public static class Is
	{
		#region Boolean

		/// <summary>
		///     Match to true
		/// </summary>
		/// <returns>Constraint</returns>
		public static IAssertConstraint True
		{
			get { return new IsConstraintProvider().True; }
		}

		/// <summary>
		///     Match to false
		/// </summary>
		/// <returns>Constraint</returns>
		public static IAssertConstraint False
		{
			get { return new IsConstraintProvider().False; }
		}

		#endregion

		#region Comparison

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint EqualTo(object expected)
		{
			return new IsConstraintProvider().EqualTo(expected);
		}

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="predicate">Custom comparison predicate</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint EqualTo(object expected, Func<object, object, bool> predicate)
		{
			return new IsConstraintProvider().EqualTo(expected, predicate);
		}

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="comparer">Custom comparer</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint EqualTo(object expected, IComparer comparer)
		{
			return new IsConstraintProvider().EqualTo(expected, comparer);
		}

		/// <summary>
		///     Match values using ReferenceEquals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint ReferenceEqualTo(object expected)
		{
			return new IsConstraintProvider().ReferenceEqualTo(expected);
		}

		/// <summary>
		///     Match values using less than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint LessThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return new IsConstraintProvider().LessThan(expected);
		}

		/// <summary>
		///     Match values using less thanor equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint LessThanOrEqualTo<TExpected>(TExpected expected)
			where TExpected : IComparable<TExpected>
		{
			return new IsConstraintProvider().LessThanOrEqualTo(expected);
		}

		/// <summary>
		///     Match values using greater than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint GreaterThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return new IsConstraintProvider().GreaterThan(expected);
		}

		/// <summary>
		///     Match values using greater than or equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint GreaterThanOrEqualTo<TExpected>(TExpected expected)
			where TExpected : IComparable<TExpected>
		{
			return new IsConstraintProvider().GreaterThanOrEqualTo(expected);
		}

		/// <summary>
		///     Match values between limits
		/// </summary>
		/// <returns>Constraint</returns>
		public static IAssertConstraint Between<TExpected>(TExpected lowerLimit, TExpected upperLimit)
			where TExpected : IComparable<TExpected>
		{
			return new IsConstraintProvider().Between(lowerLimit, upperLimit);
		}

		#endregion

		#region Types

		/// <summary>
		///     Match null
		/// </summary>
		/// <returns>Constraint</returns>
		public static IAssertConstraint Null
		{
			get { return new IsConstraintProvider().Null; }
		}

		/// <summary>
		///     Match type
		/// </summary>
		/// <param name="expected">Expected type</param>
		/// <returns>Constraint</returns>
		public static IAssertConstraint TypeOf(Type expected)
		{
			return new IsConstraintProvider().TypeOf(expected);
		}

		/// <summary>
		///     Match type
		/// </summary>
		/// <typeparam name="T">Expected type</typeparam>
		/// <returns>Constraint</returns>
		public static IAssertConstraint TypeOf<T>()
		{
			return new IsConstraintProvider().TypeOf(typeof (T));
		}

		#endregion

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		public static IIsConstraintProvider Not
		{
			get { return (new IsConstraintProvider() as IIsWithNotConstraintProvider).Not; }
		}
	}
}
