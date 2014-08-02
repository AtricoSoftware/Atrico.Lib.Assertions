// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public interface IConstraintProviders : IHasAdaptersBase
	{
		IIsWithNotConstraintProvider Is { get; }
		IDoesWithNotConstraintProvider Does { get; }
	}
}