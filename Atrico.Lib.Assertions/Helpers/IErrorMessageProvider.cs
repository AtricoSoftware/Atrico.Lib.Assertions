// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public interface IErrorMessageProvider
	{
		/// <summary>
		/// Creates the error message for the specified object
		/// </summary>
		/// <param name="actual">Actual object to test</param>
		/// <returns>Error message</returns>
		string CreateErrorMessage(object actual);
	}
}
