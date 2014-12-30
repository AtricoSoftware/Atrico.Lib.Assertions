// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public delegate IAssertConstraint DecoratorFunction(IAssertConstraint child);

	/// <summary>
	///     Container for constraints that syntactically use is (Is.Equal, Is.OfType, etc)
	/// </summary>
	public class DoesConstraintProvider : ConstraintProviderBase, IDoesWithNotConstraintProvider, IAsCollectionDoesWithNotConstraintProvider
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="decorator">Decorator from previous provider</param>
		public DoesConstraintProvider(DecoratorFunction decorator = null)
			: base(decorator)
		{
			AppendDecorator(NameDecorator.Create("Does"));
		}

		public IImplementConstraintProvider Implement
		{
			get { return new ImplementConstraintProvider(Decorator); }
		}

		public ISatisfyConstraintProvider Satisfy
		{
			get { return new SatisfyConstraintProvider(Decorator); }
		}

		public IAssertConstraint Contain<TExpected>(TExpected item)
		{
			return Decorator(new ContainConstraint(item));
		}

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IDoesConstraintProvider INotProvider<IDoesConstraintProvider>.Not
		{
			get
			{
				AppendDecorator(NotDecorator.Create());
				return this;
			}
		}

		/// <summary>
		///     Negate
		/// </summary>
		/// <returns>Constraint</returns>
		IAsCollectionDoesConstraintProvider INotProvider<IAsCollectionDoesConstraintProvider>.Not
		{
			get
			{
				AppendDecorator(NotDecorator.Create());
				return this;
			}
		}
	}
}
