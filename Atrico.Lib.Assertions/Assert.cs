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
			Func<object, string> errorMessageCreator = null;
			Exception innerException = null;
			try
			{
				// Create operand of correct type
				var actualTyped = constraint.CreateConstraintOperand(actual);
				// Test value
				try
				{
					if (!constraint.Test(actualTyped))
					{
						errorMessageCreator = constraint.CreateErrorMessage;
					}
				}
				catch (Exception ex)
				{
					errorMessageCreator = act => ex.Message;
				}
			}
			catch (Exception ex)
			{
				innerException = ex;
				errorMessageCreator = act => string.Format("OPERAND TYPE: {0}", ex.Message);
			}
			if (!ReferenceEquals(errorMessageCreator, null))
			{
				ThrowException(constraint.Name, errorMessageCreator, actual, innerException, message, args);
			}
		}

		private static void ThrowException(string name, Func<object, string> errorMessage, object actual, Exception innerException, string message = null, params object[] args)
		{
			var text = new StringBuilder();
			// Name
			if (name != null)
			{
				text.AppendFormat("{0} failed.", name);
			}
			else
			{
				text.Append("Failed.");
			}
			var errorMsg = errorMessage(actual);
			if (errorMsg.Length > 0)
			{
				text.AppendFormat(" {0}", errorMsg);
			}
			if (message != null)
			{
				text.AppendFormat(" ({0})", string.Format(message, args));
			}
			throw new AssertFailedException(text.ToString(), innerException);
		}

		public static object Fail(string message = null, params object[] args)
		{
			var msg = new StringBuilder("Failed.");
			if (message != null)
			{
				msg.AppendFormat(" ({0})", string.Format(message, args));
			}
			throw new AssertFailedException(msg.ToString());
		}
	}
}
