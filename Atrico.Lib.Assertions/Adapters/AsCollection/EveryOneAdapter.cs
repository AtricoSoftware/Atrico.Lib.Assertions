using System.Collections;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public class EveryOneAdapter : IAdapter
	{
		public IAssertConstraint Decorate(IAssertConstraint constraint)
		{
			return new EveryOneDecorater(constraint);
		}

		public override string ToString()
		{
			return "EveryOneAdapter";
		}

		private class EveryOneDecorater : NameDecorater
		{
			public EveryOneDecorater(IAssertConstraint constraint)
				: base("EveryOne", constraint)
			{
			}

			public override bool Test(object actual)
			{
				if (actual is IEnumerable)
					return (actual as IEnumerable).Cast<object>().All(item => Constraint.Test(item));
				return false;
			}

			public override string ToString()
			{
				return "EveryOneDecorater";
			}
		}
	}
}