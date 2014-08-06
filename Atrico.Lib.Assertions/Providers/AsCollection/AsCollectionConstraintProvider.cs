// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public class AsCollectionConstraintProvider : ConstraintProviderBase
	{
		/// <summary>
		///     Constructor
		/// </summary>
		public AsCollectionConstraintProvider(params IAdapter[] adapters)
			: base(adapters)
		{
		}

		public IConstraintProviders Count
		{
			get { return new ConstraintProviders(Adapters).AddAdapter(new CountAdapter()); }
		}

		public IConstraintProviders AtLeastOne
		{
			get { return new ConstraintProviders(Adapters).AddAdapter(new AtLeastOneAdapter()); }
		}

		public IConstraintProviders EveryOne
		{
			get { return new ConstraintProviders(Adapters).AddAdapter(new EveryOneAdapter()); }
		}

		public IAsCollectionDoesWithNotConstraintProvider Does
		{
			get { return new DoesConstraintProvider(Adapters); }
		}

		public IAsCollectionIsWithNotConstraintProvider Is
		{
			get { return new IsConstraintProvider(Adapters); }
		}
	}
}