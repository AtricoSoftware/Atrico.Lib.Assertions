// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public interface IDoesConstraintProvider : IHasAdaptersBase
	{
		IImplementConstraintProvider Implement { get; }
		ISatisfyConstraintProvider Satisfy { get; }
	}
}