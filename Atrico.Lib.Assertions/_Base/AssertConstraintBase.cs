using Atrico.Lib.Common;
using Atrico.Lib.Common.NamesByConvention;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion constraint with binary test
	/// </summary>
	public abstract class AssertConstraintBase<TActual> : IAssertConstraint
	{
		private readonly NameByConvention _name;

		protected abstract IErrorMessageProvider ErrorMessageProvider { get; }

		/// <summary>
		///     Constructor
		/// </summary>
		protected AssertConstraintBase()
		{
			_name = new EverythingBefore(GetType().Name, "Constraint");
		}

		public virtual string Name
		{
			get { return _name; }
		}

		public bool Test(object actual)
		{
			return TestImpl((TActual) actual);
		}

		public abstract bool TestImpl(TActual actual);

		public virtual object CreateConstraintOperand(object actual)
		{
			return Conversion.Convert<TActual>(actual);
		}

		public virtual string CreateErrorMessage(object actual)
		{
			return ErrorMessageProvider.CreateErrorMessage(actual);
		}
	}
}
