namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to null
	/// </summary>
	public class NullConstraint : AssertConstraintUnaryBase
	{
		public override bool Test(object actual)
		{
			return ReferenceEquals(actual, null);
		}

		public override string CreateErrorMessage(object actual)
		{
			return ReferenceEquals(actual, null) ? "" : base.CreateErrorMessage(actual);
		}
	}
}