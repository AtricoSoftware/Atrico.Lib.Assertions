using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using less than
	/// </summary>
	internal class LessThanConstraint<T> : AssertConstraintBinaryBase<T> where T : IComparable<T>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public LessThanConstraint(T expected)
			: base(expected)
		{
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(T expected, object actual)
		{
			var actualT = actual as IComparable<T>;
			return !ReferenceEquals(actualT, null) && actualT.CompareTo(expected) < 0;
		}
	}
}