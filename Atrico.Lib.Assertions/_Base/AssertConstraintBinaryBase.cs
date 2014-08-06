using System.Collections;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion constraint with binary test
	/// </summary>
	public abstract class AssertConstraintBinaryBase<TExpected> : AssertConstraintBase
	{
		protected TExpected Expected { get; private set; }

		public override bool Test(object actual)
		{
			return Test(Expected, actual);
		}

		public override string CreateErrorMessage(object actual)
		{
			return CreateFormattedActual(actual);
		}

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		protected AssertConstraintBinaryBase(TExpected expected)
		{
			Expected = expected;
		}

		protected abstract bool Test(TExpected expected, object actual);

		protected string CreateFormattedExpected(TExpected expected)
		{
			return string.Format(ExpectedFormat, ExpectedToStringNullProtected(expected));
		}

		public override string Name
		{
			get { return string.Format("{0}({1})", base.Name, ExpectedToStringNullProtected(Expected)); }
		}

		protected virtual string ExpectedFormat
		{
			get { return "Expected:<{0}>"; }
		}

		private string ExpectedToStringNullProtected(TExpected expected)
		{
			return ReferenceEquals(expected, null) ? "null" : ExpectedToString(expected);
		}

		protected virtual string ExpectedToString(TExpected expected)
		{
			if (expected is IEnumerable && !(expected is string))
				return FormatCollection(expected as IEnumerable);
			return expected.ToString();
		}
	}
}