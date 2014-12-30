// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to null
	/// </summary>
	public class NullConstraint : AssertConstraintUnaryBase<object>
	{
		public override bool TestImpl(object actual)
		{
			return ReferenceEquals(actual, null);
		}

		public override string CreateErrorMessage(object actual)
		{
			return ReferenceEquals(actual, null) ? "" : base.CreateErrorMessage(actual);
		}
	}
}
