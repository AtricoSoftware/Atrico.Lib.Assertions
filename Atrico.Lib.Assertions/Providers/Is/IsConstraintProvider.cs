using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public class IsConstraintProvider : ConstraintProviderBase, IIsWithNotConstraintProvider,
		IAsCollectionIsWithNotConstraintProvider
	{
		/// <summary>
		///     Constructor
		/// </summary>
		public IsConstraintProvider(params IAdapter[] adapters)
			: base(adapters)
		{
		}

		#region Boolean

		/// <summary>
		///     Match to true
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint True
		{
			get { return Adapt(new TrueConstraint()); }
		}

		/// <summary>
		///     Match to false
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint False
		{
			get { return Adapt(new FalseConstraint()); }
		}

		#endregion

		#region Comparison

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint EqualTo(object expected)
		{
			return Adapt(new EqualToConstraint(expected));
		}

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="predicate">Custom comparison predicate</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint EqualTo(object expected, Func<object, object, bool> predicate)
		{
			return Adapt(new EqualToConstraint(expected, predicate));
		}

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="comparer">Custom comparer</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint EqualTo(object expected, IComparer comparer)
		{
			return Adapt(new EqualToConstraint(expected, comparer));
		}

		/// <summary>
		///     Match values using ReferenceEquals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint ReferenceEqualTo(object expected)
		{
			return Adapt(new ReferenceEqualToConstraint(expected));
		}

		/// <summary>
		///     Match values using less than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint LessThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Adapt(new LessThanConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values using less thanor equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint LessThanOrEqualTo<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Adapt(new LessThanOrEqualToConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values using greater than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint GreaterThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Adapt(new GreaterThanConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values using greater than or equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint GreaterThanOrEqualTo<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Adapt(new GreaterThanOrEqualToConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values between limits
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint Between<TExpected>(TExpected lowerLimit, TExpected upperLimit)
			where TExpected : IComparable<TExpected>
		{
			return Adapt(new BetweenConstraint<TExpected>(lowerLimit, upperLimit));
		}

		#endregion

		#region Types

		/// <summary>
		///     Match null
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint Null
		{
			get { return Adapt(new NullConstraint()); }
		}

		/// <summary>
		///     Match type
		/// </summary>
		/// <param name="expected">Expected type</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint TypeOf(Type expected)
		{
			return Adapt(new TypeOfConstraint(expected));
		}

		/// <summary>
		///     Match type
		/// </summary>
		/// <typeparam name="TExpected">Expected type</typeparam>
		/// <returns>Constraint</returns>
		public IAssertConstraint TypeOf<TExpected>()
		{
			return Adapt(new TypeOfConstraint(typeof(TExpected)));
		}

		#endregion

		#region AsCollection

		public IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected)
		{
			return Adapt(new EquivalentToConstraint<T>(expected));
		}

		public IAssertConstraint EquivalentTo<T>(params T[] expected)
		{
			return Adapt(new EquivalentToConstraint<T>(expected));
		}

		public IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected, Func<object, object, bool> predicate)
		{
			return Adapt(new EquivalentToConstraint<T>(expected, predicate));
		}

		public IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected, IComparer comparer)
		{
			return Adapt(new EquivalentToConstraint<T>(expected, comparer));
		}

		#endregion

		#region Adapters

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IIsConstraintProvider INotAdapterProvider<IIsConstraintProvider>.Not
		{
			get { return new IsConstraintProvider(Adapters).AddAdapter(new NotAdapter()); }
		}

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IAsCollectionIsConstraintProvider INotAdapterProvider<IAsCollectionIsConstraintProvider>.Not
		{
			get { return new IsConstraintProvider(Adapters).AddAdapter(new NotAdapter()); }
		}

		#endregion
	}
}