// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public interface IConstraintProviders
	{
		IIsWithNotConstraintProvider Is { get; }
		IDoesWithNotConstraintProvider Does { get; }
	}
}
