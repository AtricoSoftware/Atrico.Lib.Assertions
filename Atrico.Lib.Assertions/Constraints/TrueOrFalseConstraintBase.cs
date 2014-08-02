namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to true
	/// </summary>
	public abstract class TrueOrFalseConstraintBase : AssertConstraintUnaryBase
	{
		public override string CreateErrorMessage(object actual)
		{
			return "";
		}
	}
}