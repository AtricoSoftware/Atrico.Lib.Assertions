// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public class ConstraintProviders : ConstraintProviderBase, IConstraintProviders, IAsCollectionConstraintProviders
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="decorator">Decorator from previous provider</param>
		public ConstraintProviders(DecoratorFunction decorator = null)
			: base(decorator)
		{
		}

		IDoesWithNotConstraintProvider IConstraintProviders.Does
		{
			get { return new DoesConstraintProvider(Decorator); }
		}

		public IConstraintProviders Count
		{
			get
			{
				AppendDecorator(CountDecorator.Create());
				return this;
			}
		}

		IIsWithNotConstraintProvider IConstraintProviders.Is
		{
			get { return new IsConstraintProvider(Decorator); }
		}

		IAsCollectionDoesWithNotConstraintProvider IAsCollectionConstraintProviders.Does
		{
			get { return new DoesConstraintProvider(Decorator); }
		}

		IAsCollectionIsWithNotConstraintProvider IAsCollectionConstraintProviders.Is
		{
			get { return new IsConstraintProvider(Decorator); }
		}
	}
}
