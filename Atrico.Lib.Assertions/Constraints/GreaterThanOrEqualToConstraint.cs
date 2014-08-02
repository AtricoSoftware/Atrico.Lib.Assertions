﻿using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using greater than
	/// </summary>
	internal class GreaterThanOrEqualToConstraint<T> : AssertConstraintBinaryBase<T> where T : IComparable<T>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public GreaterThanOrEqualToConstraint(T expected)
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
			return !ReferenceEquals(actualT, null) && actualT.CompareTo(expected) >= 0;
		}
	}
}