// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Helper to format an error message for unary constraint
	/// </summary>
	public class TypeOfErrorMessageProvider : IErrorMessageProvider
	{
		private readonly string _actualFormat;

		public TypeOfErrorMessageProvider()
		{
			_actualFormat = "Actual:<{0}>";
		}

		/// <summary>
		/// Throw error with actual, format specified
		/// </summary>
		/// <param name="actual">Actual value</param>
		public string CreateErrorMessage(object actual)
		{
			return string.Format(_actualFormat, FormatObject(actual));
		}

		internal static string FormatObject(object obj)
		{
			return ReferenceEquals(obj, null) ? "null" : obj.GetType().ToString();
		}
	}
}
