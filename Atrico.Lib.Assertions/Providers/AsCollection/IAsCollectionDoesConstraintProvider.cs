namespace Atrico.Lib.Assertions
{
	public interface IAsCollectionDoesConstraintProvider : IDoesConstraintProvider
	{
		IAssertConstraint Contain<TExpected>(TExpected item);
	}
}