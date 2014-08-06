using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match values using Equals
	/// </summary>
	internal class EquivalentToConstraint<T> : AssertConstraintBinaryBase<IEnumerable<T>>
	{
		private readonly Func<object, object, bool> _predicate;

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public EquivalentToConstraint(IEnumerable<T> expected)
			: this(expected, (x,y)=>x.Equals(y))
		{
		}
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="comparer">Custom comparer</param>
		public EquivalentToConstraint(IEnumerable<T> expected, IComparer comparer)
			: this(expected, (x, y) => comparer.Compare(x, y) == 0)
		{
		}

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="predicate">Custom comparison predicate</param>
		public EquivalentToConstraint(IEnumerable<T> expected, Func<object, object, bool> predicate)
			: base(expected)
		{
			_predicate = predicate;
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actualObj">Actual value</param>
		protected override bool Test(IEnumerable<T> expected, object actualObj)
		{
			var actual = actualObj as IEnumerable;
			if (ReferenceEquals(expected, actual))
				return true;
			if (ReferenceEquals(actual, null))
				return false;
			return CompareCollections(expected.ToList(), actual.Cast<object>().ToList());
		}

		private bool CompareCollections(ICollection<T> expected, ICollection<object> actual)
		{
			if (actual.Count != expected.Count) return false;
			foreach (var itemE in expected)
			{
				if (!actual.Any(itemA => _predicate(itemA, itemE))) return false;
			}
			return true;
		}

		public override string Name
		{
			get { return "EquivalentTo"; }
		}

		public override string CreateErrorMessage(object actual)
		{
			return string.Format("{0}, {1}", CreateFormattedExpected(Expected), CreateFormattedActual(actual));
		}
	}
}