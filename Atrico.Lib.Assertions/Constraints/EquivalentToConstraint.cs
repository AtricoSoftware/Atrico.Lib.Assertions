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
	internal class EquivalentToConstraint<TExpected> : AssertConstraintBinaryBase<object, IEnumerable<TExpected>>
	{
		private readonly Func<object, TExpected, bool> _predicate;

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		public EquivalentToConstraint(IEnumerable<TExpected> expected)
			: this(expected, (x, y) => x.Equals(y))
		{
		}

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="comparer">Custom comparer</param>
		public EquivalentToConstraint(IEnumerable<TExpected> expected, IComparer comparer)
			: this(expected, (x, y) => comparer.Compare(x, y) == 0)
		{
		}

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="predicate">Custom comparison predicate</param>
		public EquivalentToConstraint(IEnumerable<TExpected> expected, Func<object, TExpected, bool> predicate)
			: base(expected)
		{
			_predicate = predicate;
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actualObj">Actual value</param>
		protected override bool Test(IEnumerable<TExpected> expected, object actualObj)
		{
			var actual = actualObj as IEnumerable;
			if (ReferenceEquals(expected, actual))
			{
				return true;
			}
			if (ReferenceEquals(actual, null))
			{
				return false;
			}
			return CompareCollections(expected.ToList(), actual.Cast<object>().ToList());
		}

		private bool CompareCollections(ICollection<TExpected> expected, ICollection<object> actual)
		{
			if (actual.Count != expected.Count)
			{
				return false;
			}
			return expected.All(itemE => actual.Any(itemA => _predicate(itemA, itemE)));
		}

		public override string Name
		{
			get { return "EquivalentTo"; }
		}

		//public override string CreateErrorMessage(object actual)
		//{
		//	var message = new StringBuilder();
		//	message.AppendFormat("{0}, {1}", CreateFormattedExpected(Expected), CreateFormattedActual(actual));
		//	var actC = actual as IEnumerable;
		//	if (!ReferenceEquals(Expected, null) && !ReferenceEquals(actC, null))
		//	{
		//		var extra = CollectionErrorMessage.Message(actC, Expected);
		//		if (extra.Length > 0) message.AppendFormat(": {0}", extra);
		//	}
		//	return message.ToString();
		//}
	}
}
