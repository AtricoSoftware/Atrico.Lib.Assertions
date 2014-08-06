// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use does
	/// </summary>
	public static class Does
	{
		public static ISatisfyConstraintProvider Satisfy
		{
			get { return new DoesConstraintProvider().Satisfy; }
		}

		public static IImplementConstraintProvider Implement
		{
			get { return new DoesConstraintProvider().Implement; }
		}

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		public static IDoesConstraintProvider Not
		{
			get { return (new DoesConstraintProvider() as INotAdapterProvider<IDoesConstraintProvider>).Not; }
		}
	}
}