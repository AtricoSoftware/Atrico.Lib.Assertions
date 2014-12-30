// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion constraint with binary test
	/// </summary>
	public abstract class AssertConstraintBinaryBase<TActual, TExpected> : AssertConstraintBase<TActual>
	{
		protected TExpected Expected { get; private set; }

		public override bool TestImpl(TActual actual)
		{
			return Test(Expected, actual);
		}

		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new BinaryErrorMessageProvider<TExpected>(Expected); }
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

		public override string Name
		{
			get { return string.Format("{0}({1})", base.Name, UnaryErrorMessageProvider.FormatObject(Expected)); }
		}
	}
}
