using System.Collections;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public class CountAdapter : IAdapter
	{
		public IAssertConstraint Decorate(IAssertConstraint constraint)
		{
			return new CountDecorater(constraint);
		}

		public override string ToString()
		{
			return "CountAdapter";
		}

		private class CountDecorater : NameDecorater
		{
			public CountDecorater(IAssertConstraint constraint)
				: base("Count", constraint)
			{
			}

			public override string CreateErrorMessage(object actual)
			{
				var count = GetCount(actual);
				return count.HasValue ? Constraint.CreateErrorMessage(count) : string.Format("'{0}' has no count", actual ?? "null");
			}

			public override bool Test(object actual)
			{
				var count = GetCount(actual);
				return count.HasValue && Constraint.Test(count.Value);
			}

			public override string ToString()
			{
				return "CountDecorater";
			}

			private static int? GetCount(object actual)
			{
				if (actual is IEnumerable)
					return (actual as IEnumerable).Cast<object>().Count();
				return null;
			}
		}
	}
}