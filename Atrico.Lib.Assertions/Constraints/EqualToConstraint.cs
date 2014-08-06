using System.Collections;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using Equals
	/// </summary>
	internal class EqualToConstraint : AssertConstraintBinaryBase<object>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public EqualToConstraint(object expected)
			: base(expected)
		{
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(object expected, object actual)
		{
			if (ReferenceEquals(expected, actual))
				return true;
			if (ReferenceEquals(actual, null))
				return false;
			if (expected is IEnumerable && actual is IEnumerable)
				return CollectionEquals((expected as IEnumerable).Cast<object>().ToArray(), (actual as IEnumerable).Cast<object>().ToArray());
			return actual.Equals(expected);
		}

		private static bool CollectionEquals(object[] expected, object[] actual)
		{
			if (expected.Length != actual.Length) return false;
			return !actual.Where((t, i) => !t.Equals(expected[i])).Any();
		}

		public override string Name
		{
			get { return "EqualTo"; }
		}

		public override string CreateErrorMessage(object actual)
		{
			return string.Format("{0}, {1}", CreateFormattedExpected(Expected), CreateFormattedActual(actual));
		}
	}

	/// <summary>
	///     Match values using Equals
	/// </summary>
	internal class ReferenceEqualToConstraint : AssertConstraintBinaryBase<object>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public ReferenceEqualToConstraint(object expected)
			: base(expected)
		{
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(object expected, object actual)
		{
			return ReferenceEquals(expected, actual);
		}

		public override string Name
		{
			get { return "ReferenceEqualTo"; }
		}

		public override string CreateErrorMessage(object actual)
		{
			return string.Format("{0}, {1}", CreateFormattedExpected(Expected), CreateFormattedActual(actual));
		}
	}
}