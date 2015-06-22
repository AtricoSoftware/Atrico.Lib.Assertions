using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        /// <param name="constraint">Constraint to match</param>
        /// <param name="message">Optional message for assertion (format/args)</param>
        /// <param name="args">Message arguments</param>
        public static void That<T>(Constraint<T> constraint, string message = null, params object[] args)
        {
            string errorMessage = null;
            Exception innerException = null;
            // Test value
            try
            {
                if (!constraint.Check())
                {
                    errorMessage = constraint.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                innerException = ex;
            }
            if (!ReferenceEquals(errorMessage, null))
            {
                ThrowException(constraint.Name, errorMessage, innerException, message, args);
            }
        }

        private static void ThrowException(string name, string errorMessage, Exception innerException, string message = null, params object[] args)
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
            if (errorMessage.Length > 0)
            {
                text.AppendFormat(" {0}", errorMessage);
            }
            if (message != null)
            {
                text.Append(" (");
                    // Handle single curly braces innon-formatted message
                text.Append(args.Any() ? string.Format(message, args) : message);
                text.Append(')');
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