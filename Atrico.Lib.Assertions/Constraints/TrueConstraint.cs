// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to true
	/// </summary>
	public class TrueConstraint : AssertConstraintUnaryBase<bool>
	{
		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new NoErrorMessageProvider(); }
		}

		public override bool TestImpl(bool actual)
		{
			return actual;
		}
	}
}
