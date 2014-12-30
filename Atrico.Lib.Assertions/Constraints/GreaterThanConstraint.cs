using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using greater than
	/// </summary>
	internal class GreaterThanConstraint<TExpected> : AssertConstraintBinaryBase<object, TExpected> where TExpected : IComparable<TExpected>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public GreaterThanConstraint(TExpected expected)
			: base(expected)
		{
		}

		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new UnaryErrorMessageProvider(); }
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(TExpected expected, object actual)
		{
			var actualT = actual as IComparable<TExpected>;
			return !ReferenceEquals(actualT, null) && actualT.CompareTo(expected) > 0;
		}
	}
}
