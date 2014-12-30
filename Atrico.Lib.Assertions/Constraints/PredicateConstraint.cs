using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public class PredicateConstraint<TActual> : AssertConstraintUnaryBase<TActual>
	{
		private readonly Func<TActual, bool> _predicate;

		/// <summary>
		///     Constructor
		/// </summary>
		public PredicateConstraint(Func<TActual, bool> predicate)
		{
			_predicate = predicate;
		}

		protected override IErrorMessageProvider ErrorMessageProvider
		{
			get { return new UnaryErrorMessageProvider("Subject:<{0}>"); }
		}

		public override bool TestImpl(TActual actual)
		{
			try
			{
				return _predicate(actual);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
