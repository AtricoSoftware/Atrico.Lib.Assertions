namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion cotnstraint
	/// </summary>
	public interface IAssertConstraint : IErrorMessage
	{
		/// <summary>
		///     Name of constraint
		/// </summary>
		string Name { get; }

		/// <summary>
		///     Method to test this value against the constraint/expectation
		/// </summary>
		/// <param name="actual">Value to test against constraint</param>
		/// <returns>True if constraint was met by value</returns>
		bool Test(object actual);
	}
}