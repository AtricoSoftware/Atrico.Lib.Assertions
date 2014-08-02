using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values between 2 values
	/// </summary>
	internal class BetweenConstraint<T> : AssertConstraintBinaryBase<BetweenConstraint<T>.Range>
		where T : IComparable<T>
	{
		public class Range
		{
			public T LowerLimit { get; private set; }
			public T UpperLimit { get; private set; }

			public Range(T lowerLimit, T upperLimit)
			{
				LowerLimit = lowerLimit;
				UpperLimit = upperLimit;
			}

			public override string ToString()
			{
				return string.Format("{0} -> {1}", LowerLimit, UpperLimit);
			}
		}

		/// <summary>
		///     Constructor
		/// </summary>
		public BetweenConstraint(T lowerLimit, T upperLimit)
			: base(new Range(lowerLimit, upperLimit))
		{
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(Range expected, object actual)
		{
			var actualT = actual as IComparable<T>;
			return !ReferenceEquals(actualT, null) && actualT.CompareTo(expected.LowerLimit) >= 0 &&
			       actualT.CompareTo(expected.UpperLimit) <= 0;
		}
	}
}