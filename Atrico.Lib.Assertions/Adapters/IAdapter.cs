namespace Atrico.Lib.Assertions
{
	public interface IAdapter
	{
		IAssertConstraint Decorate(IAssertConstraint constraint);
	}
}