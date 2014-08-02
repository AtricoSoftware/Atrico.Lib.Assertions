using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Constraint based assertion
	/// </summary>
	public static class Assert
	{
		/// <summary>
		///     Main method for asserting
		/// </summary>
		/// <param name="actual">Value to assert upon</param>
		/// <param name="constraint">Constraint to match</param>
		/// <param name="message">Optional message for assertion (format/args)</param>
		/// <param name="args">Message arguments</param>
		public static void That(object actual, IAssertConstraint constraint, string message = null, params object[] args)
		{
			IErrorMessage errorMessageCreator;
			try
			{
				if (constraint.Test(actual)) return;
				errorMessageCreator = constraint;
			}
			catch (Exception ex)
			{
				// Convert exception to MSTest assert exception
				errorMessageCreator = new ExceptionErrorMessageWrapper(ex.Message);
			}
			throw new AssertFailedException(FormatErrorMessage(constraint.Name, errorMessageCreator, actual, message, args));
		}

		private static string FormatErrorMessage(string name, IErrorMessage errorMessage, object actual,
			string message = null, params object[] args)
		{
			var text = new StringBuilder();
			// Name
			if (name != null) text.AppendFormat("{0} failed.", name);
			else text.Append("Failed.");
			var errorMsg = errorMessage.CreateErrorMessage(actual);
			if (errorMsg.Length > 0) text.AppendFormat(" {0}", errorMsg);
			if (message != null) text.AppendFormat(" ({0})", string.Format(message, args));
			throw new AssertFailedException(text.ToString());
		}

		private class ExceptionErrorMessageWrapper : IErrorMessage
		{
			private readonly string _message;

			public ExceptionErrorMessageWrapper(string message)
			{
				_message = message;
			}

			public string CreateErrorMessage(object actual)
			{
				return string.Format("Exception: {0}", _message);
			}
		}

		public static object Fail(string message = null, params object[] args)
		{
			var msg = new StringBuilder("Failed.");
			if (message != null) msg.AppendFormat(" ({0})", string.Format(message, args));
			throw new AssertFailedException(msg.ToString());
		}
				
	}
}