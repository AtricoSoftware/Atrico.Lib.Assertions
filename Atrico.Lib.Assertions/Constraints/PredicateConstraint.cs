using System;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public class PredicateConstraint<TActual> : AssertConstraintUnaryBase
	{
		private readonly Func<TActual, bool> _predicate;

		/// <summary>
		///     Constructor
		/// </summary>
		public PredicateConstraint(Func<TActual, bool> predicate)
		{
			_predicate = predicate;
		}

		public override bool Test(object actual)
		{
			try
			{
				var actualT = (TActual)actual;
				return _predicate(actualT);
			}
			catch (Exception)
			{
				return false;
			}
		}

		protected override string ActualFormat
		{
			get { return "Subject:<{0}>"; }
		}
	}
}