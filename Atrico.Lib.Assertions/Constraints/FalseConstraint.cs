// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match to false
	/// </summary>
	public class FalseConstraint : AssertConstraintUnaryBase<bool>
	{
		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new NoErrorMessageProvider(); }
		}

		public override bool TestImpl(bool actual)
		{
			return !actual;
		}
	}
}
