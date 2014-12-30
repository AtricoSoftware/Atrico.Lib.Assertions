using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using Equals
	/// </summary>
	internal class TypeOfConstraint : AssertConstraintBinaryBase<object, Type>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected type</param>
		public TypeOfConstraint(Type expected)
			: base(expected)
		{
		}

		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new TypeOfErrorMessageProvider(); }
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(Type expected, object actual)
		{
			return actual != null && actual.GetType() == expected;
		}

		public override string Name
		{
			get { return string.Format("TypeOf<{0}>", Expected); }
		}
	}
}
