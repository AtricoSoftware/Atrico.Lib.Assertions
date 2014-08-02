// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public class DoesConstraintProvider : ConstraintProviderBase, IDoesWithNotConstraintProvider,
		IAsCollectionDoesWithNotConstraintProvider
	{
		/// <summary>
		///     Constructor
		/// </summary>
		public DoesConstraintProvider(params IAdapter[] adapters)
			: base(adapters)
		{
		}

		public IImplementConstraintProvider Implement
		{
			get { return new ImplementConstraintProvider(Adapters); }
		}

		public ISatisfyConstraintProvider Satisfy
		{
			get { return new SatisfyConstraintProvider(Adapters); }
		}

		public IAssertConstraint Contain<TExpected>(TExpected item)
		{
			return Adapt(new ContainConstraint(item));
		}

		#region Adapters

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IDoesConstraintProvider INotAdapterProvider<IDoesConstraintProvider>.Not
		{
			get { return new DoesConstraintProvider().AddAdapter(new NotAdapter()); }
		}

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IAsCollectionDoesConstraintProvider INotAdapterProvider<IAsCollectionDoesConstraintProvider>.Not
		{
			get { return new DoesConstraintProvider().AddAdapter(new NotAdapter()); }
		}

		#endregion
	}
}