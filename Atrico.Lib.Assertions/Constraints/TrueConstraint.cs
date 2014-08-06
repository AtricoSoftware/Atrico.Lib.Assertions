// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to true
	/// </summary>
	public class TrueConstraint : TrueOrFalseConstraintBase
	{
		public override bool Test(object actual)
		{
			return actual is bool && (bool)actual;
		}
	}
}