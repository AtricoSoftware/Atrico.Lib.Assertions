// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using Equals
	/// </summary>
	internal class ReferenceEqualToConstraint : AssertConstraintBinaryBase<object, object>
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
	}
}
