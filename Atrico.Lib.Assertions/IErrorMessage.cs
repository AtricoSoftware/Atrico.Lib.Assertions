namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface to object that creates an error message
	/// </summary>
	public interface IErrorMessage
	{
		string CreateErrorMessage(object actual);
	}
}