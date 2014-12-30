using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values between 2 values
	/// </summary>
	internal class BetweenConstraint<TExpected> : AssertConstraintBinaryBase<object, BetweenConstraint<TExpected>.Range>
		where TExpected : IComparable<TExpected>
	{
		public class Range
		{
			private readonly TExpected _lowerLimit;
			private readonly TExpected _upperLimit;

			public Range(TExpected lowerLimit, TExpected upperLimit)
			{
				_lowerLimit = lowerLimit;
				_upperLimit = upperLimit;
			}

			public bool IsWithin(IComparable<TExpected> actual)
			{
				return !ReferenceEquals(actual, null)
				       && actual.CompareTo(_lowerLimit) >= 0
				       && actual.CompareTo(_upperLimit) <= 0;
			}

			public override string ToString()
			{
				return string.Format("{0} -> {1}", _lowerLimit, _upperLimit);
			}
		}

		/// <summary>
		///     Constructor
		/// </summary>
		public BetweenConstraint(TExpected lowerLimit, TExpected upperLimit)
			: base(new Range(lowerLimit, upperLimit))
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
		protected override bool Test(Range expected, object actual)
		{
			return expected.IsWithin(actual as IComparable<TExpected>);
		}
	}
}
