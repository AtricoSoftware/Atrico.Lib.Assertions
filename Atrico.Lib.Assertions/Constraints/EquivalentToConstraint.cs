using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using Equals
	/// </summary>
	internal class EquivalentToConstraint<T> : AssertConstraintBinaryBase<IEnumerable<T>>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public EquivalentToConstraint(IEnumerable<T> expected)
			: base(expected)
		{
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(IEnumerable<T> expected, object actualObj)
		{
			var actual = actualObj as IEnumerable;
			if (ReferenceEquals(expected, actual))
				return true;
			if (ReferenceEquals(actual, null))
				return false;
			return CompareCollections(expected.ToList(), actual.Cast<object>().ToList());
		}

		private static bool CompareCollections(ICollection<T> expected, ICollection<object> actual)
		{
			return actual.Count == expected.Count && expected.All(item => actual.Remove(item));
		}

		public override string Name
		{
			get { return "EquivalentTo"; }
		}

		public override string CreateErrorMessage(object actual)
		{
			return string.Format("{0}, {1}", CreateFormattedExpected(Expected), CreateFormattedActual(actual));
		}
	}
}