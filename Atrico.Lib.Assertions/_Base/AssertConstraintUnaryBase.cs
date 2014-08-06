// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion constraint with unary test
	/// </summary>
	public abstract class AssertConstraintUnaryBase : AssertConstraintBase
	{
		public override string CreateErrorMessage(object actual)
		{
			return CreateFormattedActual(actual);
		}
	}
}