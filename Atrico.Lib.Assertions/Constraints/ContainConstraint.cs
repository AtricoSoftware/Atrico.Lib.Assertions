using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Match collections containing item
	/// </summary>
	internal class ContainConstraint : AssertConstraintBinaryBase<object>
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="expected">Expected item</param>
		public ContainConstraint(object expected)
			: base(expected)
		{
		}

		/// <summary>
		///     Test this value
		/// </summary>
		/// <param name="expected">Expected value</param>
		/// <param name="actual">Actual value</param>
		protected override bool Test(object expected, object actual)
		{
			if (actual is IEnumerable)
			{
				var set = new HashSet<object>((actual as IEnumerable).Cast<object>());
				return set.Contains(expected);
			}
			return false;
		}

		public override string CreateErrorMessage(object actual)
		{
			return "";
		}
	}
}