namespace Atrico.Lib.Assertions
{
	public interface IAsCollectionConstraintProviders : IHasAdaptersBase
	{
		IConstraintProviders Count { get; }
		IAsCollectionIsWithNotConstraintProvider Is { get; }
		IAsCollectionDoesWithNotConstraintProvider Does { get; }
	}
}