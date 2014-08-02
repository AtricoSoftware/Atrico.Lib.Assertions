// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public class ConstraintProviders : ConstraintProviderBase, IConstraintProviders, IAsCollectionConstraintProviders
	{
		/// <summary>
		///     Constructor
		/// </summary>
		public ConstraintProviders(params IAdapter[] adapters)
			: base("", adapters)
		{
		}

		IDoesWithNotConstraintProvider IConstraintProviders.Does
		{
			get { return new DoesConstraintProvider(Adapters); }
		}

		public IConstraintProviders Count
		{
			get { return new ConstraintProviders(Adapters).AddAdapter(new CountAdapter()); }
		}

		IIsWithNotConstraintProvider IConstraintProviders.Is
		{
			get { return new IsConstraintProvider(Adapters); }
		}

		IAsCollectionDoesWithNotConstraintProvider IAsCollectionConstraintProviders.Does
		{
			get { return new DoesConstraintProvider(Adapters); }
		}

		IAsCollectionIsWithNotConstraintProvider IAsCollectionConstraintProviders.Is
		{
			get { return new IsConstraintProvider(Adapters); }
		}
	}
}