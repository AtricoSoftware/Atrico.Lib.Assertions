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
		/// <param name="decorator">Decorator from previous provider</param>
		public IsConstraintProvider(DecoratorFunction decorator = null)
			: base(decorator)
		{
			AppendDecorator(NameDecorator.Create("Is"));
		}

		#region Boolean

		/// <summary>
		///     Match to true
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint True
		{
			get { return Decorator(new TrueConstraint()); }
		}

		/// <summary>
		///     Match to false
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint False
		{
			get { return Decorator(new FalseConstraint()); }
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
			return Decorator(new EqualToConstraint(expected));
		}

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="predicate">Custom comparison predicate</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint EqualTo(object expected, Func<object, object, bool> predicate)
		{
			return Decorator(new EqualToConstraint(expected, predicate));
		}

		/// <summary>
		///     Match values using Equals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="comparer">Custom comparer</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint EqualTo(object expected, IComparer comparer)
		{
			return Decorator(new EqualToConstraint(expected, comparer));
		}

		/// <summary>
		///     Match values using ReferenceEquals
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint ReferenceEqualTo(object expected)
		{
			return Decorator(new ReferenceEqualToConstraint(expected));
		}

		/// <summary>
		///     Match values using less than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint LessThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Decorator(new LessThanConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values using less thanor equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint LessThanOrEqualTo<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Decorator(new LessThanOrEqualToConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values using greater than
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint GreaterThan<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Decorator(new GreaterThanConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values using greater than or equal to
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint GreaterThanOrEqualTo<TExpected>(TExpected expected) where TExpected : IComparable<TExpected>
		{
			return Decorator(new GreaterThanOrEqualToConstraint<TExpected>(expected));
		}

		/// <summary>
		///     Match values between limits
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint Between<TExpected>(TExpected lowerLimit, TExpected upperLimit)
			where TExpected : IComparable<TExpected>
		{
			return Decorator(new BetweenConstraint<TExpected>(lowerLimit, upperLimit));
		}

		#endregion

		#region Types

		/// <summary>
		///     Match null
		/// </summary>
		/// <returns>Constraint</returns>
		public IAssertConstraint Null
		{
			get { return Decorator(new NullConstraint()); }
		}

		/// <summary>
		///     Match type
		/// </summary>
		/// <param name="expected">Expected type</param>
		/// <returns>Constraint</returns>
		public IAssertConstraint TypeOf(Type expected)
		{
			return Decorator(new TypeOfConstraint(expected));
		}

		/// <summary>
		///     Match type
		/// </summary>
		/// <typeparam name="TExpected">Expected type</typeparam>
		/// <returns>Constraint</returns>
		public IAssertConstraint TypeOf<TExpected>()
		{
			return Decorator(new TypeOfConstraint(typeof (TExpected)));
		}

		#endregion

		#region AsCollection

		public IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected)
		{
			return Decorator(new EquivalentToConstraint<T>(expected));
		}

		public IAssertConstraint EquivalentTo<T>(params T[] expected)
		{
			return Decorator(new EquivalentToConstraint<T>(expected));
		}

		public IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected, Func<object, T, bool> predicate)
		{
			return Decorator(new EquivalentToConstraint<T>(expected, predicate));
		}

		public IAssertConstraint EquivalentTo<T>(IEnumerable<T> expected, IComparer comparer)
		{
			return Decorator(new EquivalentToConstraint<T>(expected, comparer));
		}

		#endregion

		#region Not

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IIsConstraintProvider INotProvider<IIsConstraintProvider>.Not
		{
			get
			{
				AppendDecorator(NotDecorator.Create());
				return this;
			}
		}

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IAsCollectionIsConstraintProvider INotProvider<IAsCollectionIsConstraintProvider>.Not
		{
			get
			{
				AppendDecorator(NotDecorator.Create());
				return this;
			}
		}

		#endregion
	}
}
