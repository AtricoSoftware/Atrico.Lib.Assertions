using System;
using System.Collections;
using System.Text;
using Atrico.Lib.Common.Collections;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Helper to format an error message for unary constraint
	/// </summary>
	public class BinaryErrorMessageProvider<TExpected> : UnaryErrorMessageProvider
	{
		private readonly TExpected _expected;
		private readonly Lazy<string> _expectedMessage;

		public BinaryErrorMessageProvider(TExpected expected, string actualFormat = null, string expectedFormat = null)
			: base(actualFormat)
		{
			_expected = expected;
			_expectedMessage = new Lazy<string>(() => string.Format(expectedFormat ?? "Expected:<{0}>", FormatObject(expected)));
		}

		/// <summary>
		/// Error with actual, format specified
		/// </summary>
		/// <param name="actual">Actual value</param>
		public override string CreateErrorMessage(object actual)
		{
			var actualError = base.CreateErrorMessage(actual);
			var sep = _expectedMessage.Value.Length > 0 && actualError.Length > 0 ? ", " : "";
			var text = new StringBuilder();
			text.AppendFormat("{0}{1}{2}", _expectedMessage.Value, sep, actualError);
			var collection = CollectionComparer.Differences(actual as IEnumerable, _expected as IEnumerable).ToString();
			sep = text.Length > 0 && collection.Length > 0 ? ": " : "";
			text.AppendFormat("{0}{1}", sep, collection);

			return text.ToString();
		}
	}
}
