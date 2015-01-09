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
	internal class EqualToConstraint : AssertConstraintBinaryBase<object, object>
	{
		private readonly Func<object, object, bool> _predicate;

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public EqualToConstraint(object expected)
			: this(expected, DefaultEquals)
		{
		}

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="comparer">Custom comparer</param>
		public EqualToConstraint(object expected, IComparer comparer)
			: this(expected, (x, y) => comparer.Compare(x, y) == 0)
		{
		}

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="predicate">Custom comparison predicate</param>
		public EqualToConstraint(object expected, Func<object, object, bool> predicate)
			: base(expected)
		{
			_predicate = predicate;
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(object expected, object actual)
		{
			if (ReferenceEquals(expected, actual))
			{
				return true;
			}
			if (ReferenceEquals(actual, null))
			{
				return false;
			}
			return _predicate(actual, expected);
		}

		private static bool DefaultEquals(object expected, object actual)
		{
			if (expected is IEnumerable && actual is IEnumerable)
			{
				return CollectionEquals((expected as IEnumerable).Cast<object>().ToArray(), (actual as IEnumerable).Cast<object>().ToArray());
			}
			return actual.Equals(expected);
		}

		private static bool CollectionEquals(IList<object> expected, ICollection<object> actual)
		{
			if (expected.Count != actual.Count)
			{
				return false;
			}
			return !actual.Where((t, i) => !t.Equals(expected[i])).Any();
		}

		public override string Name
		{
			get { return "EqualTo"; }
		}
	}
}
