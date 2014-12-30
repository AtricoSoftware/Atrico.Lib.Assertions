using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values implementing interface
	/// </summary>
	internal class InterfaceConstraint : AssertConstraintBinaryBase<object, Type>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected interface</param>
		public InterfaceConstraint(Type expected)
			: base(expected)
		{
		}

		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new UnaryErrorMessageProvider(""); }
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(Type expected, object actual)
		{
			return actual != null && expected.IsInstanceOfType(actual);
		}

		public override string Name
		{
			get { return string.Format("Interface<{0}>", Expected); }
		}
	}
}
