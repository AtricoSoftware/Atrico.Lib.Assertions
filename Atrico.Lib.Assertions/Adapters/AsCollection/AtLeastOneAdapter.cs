using System.Collections;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public class AtLeastOneAdapter : IAdapter
	{
		public IAssertConstraint Decorate(IAssertConstraint constraint)
		{
			return new AtleastOneDecorater(constraint);
		}

		public override string ToString()
		{
			return "AtLeastOneAdapter";
		}

		private class AtleastOneDecorater : NameDecorater
		{
			public AtleastOneDecorater(IAssertConstraint constraint)
				: base("AtLeastOne", constraint)
			{
			}

			public override bool Test(object actual)
			{
				if (actual is IEnumerable)
					return (actual as IEnumerable).Cast<object>().Any(item => Constraint.Test(item));
				return false;
			}

			public override string ToString()
			{
				return "AtleastOneDecorater";
			}
		}
	}
}