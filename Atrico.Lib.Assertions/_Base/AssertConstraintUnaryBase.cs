// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Base for an assertion constraint with unary test
	/// </summary>
	public abstract class AssertConstraintUnaryBase<TActual> : AssertConstraintBase<TActual>
	{
		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new UnaryErrorMessageProvider(); }
		}
	}
}
