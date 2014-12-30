using System.Collections;

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
		/// <param name="decorator">Decorator from previous provider</param>
		public AsCollectionConstraintProvider(DecoratorFunction decorator = null)
			: base(decorator)
		{
			AppendDecorator(NameDecorator.Create("AsCollection"));
			AppendDecorator(TypeChangeDecorator<IEnumerable>.Create());
		}

		public IConstraintProviders Count
		{
			get { return new ConstraintProviders(Decorator.Append(CountDecorator.Create())); }
		}

		public IConstraintProviders AtLeastOne
		{
			get { return new ConstraintProviders(Decorator.Append(AtLeastOneDecorator.Create())); }
		}

		public IConstraintProviders EveryOne
		{
			get { return new ConstraintProviders(Decorator.Append(EveryOneDecorator.Create())); }
		}

		public IAsCollectionDoesWithNotConstraintProvider Does
		{
			get { return new DoesConstraintProvider(Decorator); }
		}

		public IAsCollectionIsWithNotConstraintProvider Is
		{
			get { return new IsConstraintProvider(Decorator); }
		}
	}
}
