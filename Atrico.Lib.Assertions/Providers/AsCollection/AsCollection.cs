// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that use AsCollection (AsCollection.Count.Is.Equal, AsCollection.AtLeastOne)
	/// </summary>
	public static class AsCollection
	{
		public static IConstraintProviders Count
		{
			get { return new AsCollectionConstraintProvider().Count; }
		}

		public static IConstraintProviders AtLeastOne
		{
			get { return new AsCollectionConstraintProvider().AtLeastOne; }
		}

		public static IConstraintProviders EveryOne
		{
			get { return new AsCollectionConstraintProvider().EveryOne; }
		}

		public static IAsCollectionDoesWithNotConstraintProvider Does
		{
			get { return new AsCollectionConstraintProvider().Does; }
		}

		public static IAsCollectionIsWithNotConstraintProvider Is
		{
			get { return new AsCollectionConstraintProvider().Is; }
		}
	}
}
