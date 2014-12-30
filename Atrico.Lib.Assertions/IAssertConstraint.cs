using Atrico.Lib.Common;

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion constraint
	/// </summary>
	public interface IAssertConstraint : IErrorMessageProvider, INamedObject
	{
		/// <summary>
		///     Method to test this value against the constraint/expectation
		/// </summary>
		/// <param name="actual">Value to test against constraint</param>
		/// <returns>True if test passed, false otherwise</returns>
		bool Test(object actual);

		/// <summary>
		/// Create an operand of the correct type for constraint
		/// </summary>
		/// <param name="actual">Actual object to test</param>
		/// <returns>Object of correct type for constraint</returns>
		/// <exception cref="System.Exception">Throws exception if object can not be converted into correct type</exception>
		object CreateConstraintOperand(object actual);
	}
}
