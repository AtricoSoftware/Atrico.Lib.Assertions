// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public interface IAsCollectionConstraintProviders
	{
		IConstraintProviders Count { get; }
		IAsCollectionIsWithNotConstraintProvider Is { get; }
		IAsCollectionDoesWithNotConstraintProvider Does { get; }
	}
}
