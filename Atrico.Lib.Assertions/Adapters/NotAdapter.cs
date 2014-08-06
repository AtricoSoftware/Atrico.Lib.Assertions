// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public class NotAdapter : IAdapter
	{
		public IAssertConstraint Decorate(IAssertConstraint constraint)
		{
			return new NotDecorater(constraint);
		}

		public override string ToString()
		{
			return "NotAdapter";
		}

		private class NotDecorater : NameDecorater
		{
			public NotDecorater(IAssertConstraint constraint)
				: base("Not", constraint)
			{
			}

			public override bool Test(object actual)
			{
				return !Constraint.Test(actual);
			}

			public override string ToString()
			{
				return "NotDecorater";
			}
		}
	}
}