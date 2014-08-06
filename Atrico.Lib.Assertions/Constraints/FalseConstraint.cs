// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to false
	/// </summary>
	public class FalseConstraint : TrueOrFalseConstraintBase
	{
		public override bool Test(object actual)
		{
			return actual is bool && !(bool)actual;
		}
	}
}